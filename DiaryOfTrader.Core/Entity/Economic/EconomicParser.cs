using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Entity.Economic
{
  public class EconomicParser
  {
    private DiaryOfTraderCtx? contex;
    private CancellationToken cancellationToken;
    public EconomicParser(DiaryOfTraderCtx? contex, CancellationToken cancellationToken)
    {
      this.contex = contex;
      this.cancellationToken = cancellationToken;
      EndPoint = "https://" + Resources.EconomicEndPointPrefix + "investing.com";
      CalendarFilteredData = "/economic-calendar/Service/getCalendarFilteredData";
    }

    public string EndPoint { get; set; }
    public string CalendarFilteredData { get; set; }


    public static void GetPeriodToDate(EconomicPeriod period, out DateTime startDate, out DateTime endDate)
    {
      startDate = DateTime.Today.Date;
      endDate = startDate;

      switch (period)
      {
        case EconomicPeriod.yesterday:
          startDate = DateTime.Today.Date.AddDays(-1);
          endDate = startDate;
          break;
        case EconomicPeriod.today:
          break;
        case EconomicPeriod.nextWeek:
          startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday + 7);
          endDate = startDate.AddDays(6);
          break;
        case EconomicPeriod.thisWeek:
          startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
          endDate = startDate.AddDays(6);
          break;
        case EconomicPeriod.tomorrow:
          startDate = startDate.AddDays(1);
          endDate = startDate;
          break;
      }
    }

    private void SetDefaultRequest(HttpWebRequest req)
    {
      req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36";

      req.Headers.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\"");
      req.Headers.Add("sec-ch-ua-mobile", "?0");
      req.Headers.Add("sec-ch-ua-platform", "\"Windows\"");

    }
    private async Task EventInfoAsync(EconomicSchedule schedule, bool reload = false)
    {

      if (!reload)
      {
        var ev = await contex.EconomicEvent.Where(e => e.LocalRef == schedule.HRef).FirstOrDefaultAsync();
        if (ev != null)
        {
          schedule.Event = ev;
          return;
        }
      }

      await DoEventInfoAsync(schedule);
      await contex.EconomicEvent.AddAsync(schedule.Event, cancellationToken);
    }

    public Task UpdateThisWeekAsync()
    {
      
      return Task.Run(() =>
      {

        GetPeriodToDate(EconomicPeriod.thisWeek, out DateTime startDate, out DateTime endDate);
        try
        {
          var exists = contex.EconomicSchedule
            .Any(e => e.Time.Date >= startDate && e.Time.Date <= endDate && e.Importance == (int)Importance.High);

          if (!exists)
          {
            var economicSchedules = ParseAsync(true, EconomicPeriod.thisWeek, Importance.High).Result;
          }

        }
        catch (Exception e)
        {
          Debug.WriteLine(e);
        }
      });

    }
    public void EventsAsync(List<EconomicSchedule> schedule, Action action, bool reload = false)
    {
      var tasks = new Task[schedule.Count];
      var i = 0;
      while(i < schedule.Count && !cancellationToken.IsCancellationRequested)
      {
        tasks[i] = EventInfoAsync(schedule[i], reload);
        i++;
      }
      if (!cancellationToken.IsCancellationRequested)
      {
        Task.WaitAll(tasks);
      }

      try
      {
        contex.SaveChanges();
      }
      catch (Exception e)
      {
        Debug.WriteLine(e);
      }

      action();
    }

    public async Task<List<EconomicSchedule>> ParseAsync(bool reload = false, EconomicPeriod period = EconomicPeriod.thisWeek, Importance importance = Importance.None)
    {
      GetPeriodToDate(period, out DateTime startDate, out DateTime endDate);
      return await ParseAsync(startDate, endDate, period, importance, reload);
    }
    public async Task<List<EconomicSchedule>> ParseAsync(DateTime startDate, DateTime endDate, EconomicPeriod period = EconomicPeriod.thisWeek, Importance importance = Importance.None, bool reload = false)
    {
      var noResultFlag = false;
      var orig = contex.EconomicSchedule
        .Where(e => 
          e.Time.Date >= startDate && 
          e.Time.Date <= endDate && 
          (importance == Importance.None || e.Importance == (int)importance)
          )
        .Include(e => e.Event).ToList();

      
      if (!reload && orig.Count > 0 && ((importance != Importance.None) || (orig.GroupBy(e => e.Importance).Count() == 3)))
      {
          return orig;
      }

      var result = await DoParseAsync(startDate, endDate, period, importance);
      if (!noResultFlag)
      {
        if (!cancellationToken.IsCancellationRequested)
        {
          orig.Where(e => !result.Contains(e)).ToList().ForEach(e => contex.EconomicSchedule.Remove(e));
          result.Where(e => !orig.Contains(e)).ToList().ForEach(e => contex.EconomicSchedule.Add(e));
        }

        await contex.SaveChangesAsync(cancellationToken);

      }

      return result;
    }

    public async Task<List<EconomicSchedule>> GetEconomicScheduleAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      var result = await DoParseAsync(startDate, endDate, period, importance);
      var tasks = new Task[result.Count];
      var i = 0;
      while (i < result.Count && !cancellationToken.IsCancellationRequested)
      {
        tasks[i] = DoEventInfoAsync(result[i]);
        i++;
      }
      if (!cancellationToken.IsCancellationRequested)
      {
        Task.WaitAll(tasks);
      }

      return result;
    }
    private async Task<List<EconomicSchedule>> DoParseAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      var result = new List<EconomicSchedule>();
      var data = new StringBuilder();

      if (importance != Importance.None)
      {
        if (data.Length != 0)
        {
          data.Append("&");
        }
        data.Append("importance%5B%5D=").Append(((int)importance).ToString());
      }

      if (period == EconomicPeriod.custom)
      {
        if (data.Length != 0)
        {
          data.Append("&");
        }
        data
          .Append("dateFrom=").Append(startDate.ToString("yyyy-MM-dd"))
          .Append("&dateTo").Append(startDate.ToString("yyyy-MM-dd"));
      }

      if (data.Length != 0)
      {
        data.Append("&");
      }

      data.Append("timeZone=55")
      .Append("&timeFilter=timeRemain")
      .Append("&currentTab=").Append(Enum.GetName(typeof(EconomicPeriod), period))
      .Append("&limit_from=0");


      var req = WebRequest.Create(EndPoint + CalendarFilteredData) as HttpWebRequest;
      SetDefaultRequest(req);

      req.Method = "POST";
      req.Accept = "*/*";
      req.AutomaticDecompression = DecompressionMethods.All;

      var bytes = Encoding.UTF8.GetBytes(data.ToString());
      var reqStream = req.GetRequestStream();
      reqStream.Write(bytes, 0, bytes.Length);
      req.ContentLength = bytes.Length;
      req.ContentType = "application/x-www-form-urlencoded";

      req.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
      req.Headers.Add("X-Requested-With", "XMLHttpRequest");

      req.Headers.Add("Sec-Fetch-Dest", "empty");
      req.Headers.Add("Sec-Fetch-Mode", "cors");
      req.Headers.Add("Sec-Fetch-User", "?1");
      req.Headers.Add("Sec-Fetch-Site", "same-origin");

      if (cancellationToken.IsCancellationRequested)
        return result;

      try
      {
        var resp = req.GetResponse();
        var stream = resp.GetResponseStream();
        var jsonData = new StreamReader(stream).ReadToEnd();
        var parse = JsonNode.Parse(jsonData);

        if (parse == null)
          return result;

        var html = (string)parse["data"]!;

        var tr = new Regex(@"<tr(?<class>.*?)>(?<value>.*?)<\/tr>");
        var td = new Regex(@"<td(?<class>.*?)>(?<value>.*?)<\/td>");
        var theDay = new Regex("id=\"theDay(?<value>[0-9]*)\"");
        var bull = new Regex("data-img_key=\"bull(?<value>[0-9])\"");
        var evReg = new Regex("<a href=\"(?<href>[^\"]*)\".*?>(?<value>.*?)<\\/a>");
        var prevReg = new Regex("<span title=\".*?\">(?<value>.*?)<\\/span>");
        var noResult = new Regex(@"class=""noResults center"">(?<value>.*?)<\/td>");

        var current = startDate.Date;

        var trMatch = tr.Match(html);

        while (trMatch.Success && !cancellationToken.IsCancellationRequested)
        {
          var trClass = trMatch.Result("${class}").Trim();
          var trValue = trMatch.Result("${value}").Trim();

          if (!trValue.Contains(Resources.EconomicWeekEnd + "</span>"))
          {

            if (trValue.Contains("class=\"theDay\""))
            {
              // day of year
              var dayMatch = theDay.Match(trValue);
              if (dayMatch.Success)
              {
                var unixTimeSeconds = long.Parse(dayMatch.Result("${value}"));
                current = DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).Date;
              }
            }
            else if (trValue.Contains("class=\"noResults center\""))
            {
              var noResultMath = noResult.Match(trValue);

              if (noResultMath.Success)
              {
                var ev = new EconomicSchedule
                {
                  Time = startDate,
                  Description = noResultMath.Result("${value}")
                };
                result.Add(ev);
              }
            }
            else
            {
              var tdMatch = td.Match(trValue);
              var ev = new EconomicSchedule();
              var col = 0;
              while (tdMatch.Success)
              {
                var tdClass = tdMatch.Result("${class}").Trim();
                var tdValue = tdMatch.Result("${value}").Trim();
                try
                {
                  switch (col)
                  {
                    case 0: // Time
                      if (!DateTime.TryParse(tdValue, out DateTime time))
                      {
                        time = current;
                      }

                      ev.Time = new DateTime(current.Year, current.Month, current.Day, time.Hour, time.Minute, 0);
                      break;
                    case 1: // Currency
                      //<span title="Великобритания" class="ceFlags United_Kingdom" data-img_key="United_Kingdom">&nbsp;</span> GBP
                      ev.Currency = tdValue.Substring(tdValue.LastIndexOf(">") + 1).Trim();
                      ;
                      break;
                    case 2: // Importance
                      // class="left textNum sentiment noWrap" title="Ожид. высокая волатильность" data-img_key="bull3"
                      var bullMatch = bull.Match(tdClass);
                      if (bullMatch.Success)
                      {
                        ev.Importance = int.Parse(bullMatch.Result("${value}").Trim());
                      }

                      break;
                    case 3: // Event
                      //<a href="/economic-calendar/german-manufacturing-pmi-136" target="_blank">  Индекс деловой активности в производственном секторе (PMI) Германии  (июль)</a>      &nbsp;<span class="smallGrayP" title="Предварительные данные" data-img_key="perliminary"></span>
                      var evMatch = evReg.Match(tdValue);
                      if (evMatch.Success)
                      {
                        ev.HRef = evMatch.Result("${href}").Trim();
                        ev.Description = evMatch.Result("${value}").Trim();
                      }

                      break;
                    case 4: // Fact
                      // class="bold act redFont event-478063-actual" title="Хуже ожидаемого" id="eventActual_478063"
                      ev.Factual = tdValue.Replace("&nbsp;", string.Empty);
                      break;
                    case 5: // Prognosis
                      ev.Prognosis = tdValue.Replace("&nbsp;", string.Empty);
                      break;
                    case 6: // Previous
                      // class="prev blackFont  event-478063-previous" id="eventPrevious_478063"
                      //<span title="">40,6</span>
                      var prevMatch = prevReg.Match(tdValue);
                      if (prevMatch.Success)
                      {
                        ev.Previous = prevMatch.Result("${value}").Trim().Replace("&nbsp;", string.Empty);
                      }

                      break;
                    case 7: // Last
                      // class="alert js-injected-user-alert-container "  data-name ="Индекс деловой активности в производственном секторе (PMI) Германии" data-event-id="136" data-status-enabled="0"
                      //<span class="js-plus-icon alertBellGrayPlus genToolTip oneliner" data-tooltip="Создать уведомление" data-tooltip-alt="Уведомление активно" data-reg_ep="add alert"></span>    
                      ev.Last = string.Empty; // tdValue;
                      break;
                  }
                }
                catch (Exception e)
                {
                  Debug.WriteLine($"tdValue = \"{tdValue}\"; tdClass = \"{tdClass}\"; " + e.ToString());
                }

                col++;
                tdMatch = tdMatch.NextMatch();
              }

              if (!string.IsNullOrEmpty(ev.Description))
              {
                result.Add(ev);
              }
            }
          }

          trMatch = trMatch.NextMatch();
        }
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.ToString());
      }

      return result;
    }

    private async Task DoEventInfoAsync(EconomicSchedule schedule)
    {
      string GetValue(string regex, string value)
      {
        var match = new Regex(regex).Match(value);
        if (match.Success)
        {
          return match.Result("${value}");
        }
        return string.Empty;
      }

      if (string.IsNullOrEmpty(schedule.HRef))
      {
        var result = new EconomicEvent
        {
          LocalRef = schedule.HRef,
          Description = Resources.NotPlannedEvents,
          Country = string.Empty,
          Currency = string.Empty,
          SourceRef = string.Empty
        };

        schedule.Event = result;
        return;
      }

      var req = WebRequest.Create(EndPoint + schedule.HRef) as HttpWebRequest;
      SetDefaultRequest(req);
      req.Method = "GET";
      req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
      req.Referer = "https://" + Resources.EconomicEndPointPrefix + "investing.com/economic-calendar/";
      req.AutomaticDecompression = DecompressionMethods.All;

      req.Host = Resources.EconomicEndPointPrefix + "investing.com";

      req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
      req.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");

      req.Headers.Add("Sec-Fetch-Dest", "document");
      req.Headers.Add("Sec-Fetch-Mode", "navigate");
      req.Headers.Add("Sec-Fetch-Site", "same-origin");
      req.Headers.Add("Sec-Fetch-User", "?1");
      req.Headers.Add("Upgrade-Insecure-Requests", "1");

      if (cancellationToken.IsCancellationRequested)
        return;

      try
      {
        var resp = req.GetResponse();
        var stream = resp.GetResponseStream();
        var html = new StreamReader(stream).ReadToEnd();
        if (!string.IsNullOrEmpty(html))
        {
          const string OVER_VIEW_BOX = @"<div id=""overViewBox"" class=""overViewBox event"">";
          var sourceInfo = @"<span>" + Resources.EconomicSource + "</span>";

          var i = html.IndexOf(OVER_VIEW_BOX, StringComparison.Ordinal);
          if (i > -1)
          {
            i += OVER_VIEW_BOX.Length;
            var y = html.IndexOf(sourceInfo, i, StringComparison.Ordinal) + sourceInfo.Length;
            y = html.IndexOf("</div>", y, StringComparison.Ordinal);
            var s = html.Substring(i, y - i);

            var result = new EconomicEvent
            {
              LocalRef = schedule.HRef,
              Description = GetValue(@"<div class=""left"">(?<value>.*?)\n?<\/div>", s),
              Country = GetValue(@"<span>" + Resources.EconomicCountry + @"<\/span>\n?<span><i title=""(?<value>.*?)""", s),
              Currency = GetValue(@"<span>" + Resources.EconomicCurency + @"<\/span>\n?<span>(?<value>.*?)<\/span>", s),
              SourceRef = GetValue(@"<span>" + Resources.EconomicSource + @"<\/span>\n?<span><a href=""(?<value>.*?)""", s)
            };

            if (string.IsNullOrEmpty(result.Description))
            {
              result.Description = schedule.Description;
            }

            schedule.Event = result;

          }
        }
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.ToString());
      }
    }
    )
  }
}
