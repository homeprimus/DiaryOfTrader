using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Properties;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader.Core.Entity.Economic
{
  public class EconomicParser
  {
    private DiaryOfTraderCtx contex;
    public EconomicParser(DiaryOfTraderCtx contex)
    {
      this.contex = contex;
      EndPoint = "https://" + Resources.EconomicEndPointPrefix + "investing.com";
      CalendarFilteredData = "/economic-calendar/Service/getCalendarFilteredData";
    }

    public string EndPoint { get; set; }
    public string CalendarFilteredData { get; set; }

    private void SetDefaultRequest(HttpWebRequest req)
    {
      req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36";

      req.Headers.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\"");
      req.Headers.Add("sec-ch-ua-mobile", "?0");
      req.Headers.Add("sec-ch-ua-platform", "\"Windows\"");

    }
    private async Task EventInfoAsync(EconomicSchedule schedule, bool reload = false)
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

      if (!reload)
      {
        var ev = await contex.EconomicEvent.Where(e => e.LocalRef == schedule.HRef).FirstOrDefaultAsync();
        if (ev != null)
        {
          schedule.Event = ev;
          return;
        }
      }

      var req = WebRequest.Create(EndPoint + schedule.HRef) as HttpWebRequest;
      SetDefaultRequest(req);
      req.Method = "GET";
      req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
      req.Referer = "https://" + Resources.EconomicEndPointPrefix + "investing.com/economic-calendar/";

      req.Host = "ru.investing.com";

      req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
      req.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");

      req.Headers.Add("Sec-Fetch-Dest", "document");
      req.Headers.Add("Sec-Fetch-Mode", "navigate");
      req.Headers.Add("Sec-Fetch-Site", "same-origin");
      req.Headers.Add("Sec-Fetch-User", "?1");
      req.Headers.Add("Upgrade-Insecure-Requests", "1");

      try
      {
        var resp = await req.GetResponseAsync();
        var stream = resp.GetResponseStream();
        var html = await new StreamReader(stream).ReadToEndAsync();
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
              Description = GetValue(@"<div class=""left"">(?<value>.*?)\n?<\/div>", s).Replace("<BR />", Environment.NewLine),
              Country = GetValue(@"<span>" + Resources.EconomicCountry + @"<\/span>\n?<span><i title=""(?<value>.*?)""", s),
              Currency = GetValue(@"<span>" + Resources.EconomicCurency + @"<\/span>\n?<span>(?<value>.*?)<\/span>", s),
              SourceRef = GetValue(@"<span>" + Resources.EconomicSource + @"<\/span>\n?<span><a href=""(?<value>.*?)""", s)
            };
            if (string.IsNullOrEmpty(result.Description))
            {
              result.Description = schedule.Description;
            }

            schedule.Event = result;

            await contex.EconomicEvent.AddAsync(result);

          }
        }
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.ToString());
      }
    }
    public async Task EventsAsync(List<EconomicSchedule> schedule, bool reload = false)
    {
      var tasks = new Task[schedule.Count];
      for (var i = 0; i < schedule.Count; i++)
      {
        tasks[i] = EventInfoAsync(schedule[i], reload);
      }
      await Task.WhenAll(tasks);
      await contex.SaveChangesAsync();

    }
    public async Task<List<EconomicSchedule>> ParseAsync(bool reload = false, EconomicPeriod period = EconomicPeriod.thisWeek, Importance importance = Importance.Low)
    {
      var startDate = DateTime.Today.Date;
      var endDate = startDate;

      switch (period)
      {
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

      var orig = contex.EconomicSchedule
        .Where(e => e.Time.Date >= startDate && e.Time.Date <= endDate && (importance == Importance.None || e.Importance == (int)importance))
        .Include(e => e.Event).ToList();
      if (!reload)
      {

        if (orig.Count > 0)
          return orig;
      }

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

      try
      {
        var resp = await req.GetResponseAsync();
        var stream = resp.GetResponseStream();
        var jsonData = await new StreamReader(stream).ReadToEndAsync();
        var parse = JsonObject.Parse(jsonData);

        var html = (string)parse["data"];
        if (html != null)
        {
          var tr = new Regex(@"<tr(?<class>.*?)>(?<value>.*?)<\/tr>");
          var td = new Regex(@"<td(?<class>.*?)>(?<value>.*?)<\/td>");
          var theDay = new Regex("id=\"theDay(?<value>[0-9]*)\"");
          var bull = new Regex("data-img_key=\"bull(?<value>[0-9])\"");
          var evReg = new Regex("<a href=\"(?<href>[^\"]*)\".*?>(?<value>.*?)<\\/a>");
          var prevReg = new Regex("<span title=\".*?\">(?<value>.*?)<\\/span>");

          var current = DateTime.Now;
          var trMatch = tr.Match(html);

          while (trMatch.Success)
          {
            var trClass = trMatch.Result("${class}").Trim();
            var trValue = trMatch.Result("${value}").Trim();

            if (!trValue.Contains(Resources.EconomicWeekEnd +  "</span>"))
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
                        ev.Factual = tdValue;
                        break;
                      case 5: // Prognosis
                        ev.Prognosis = tdValue;
                        break;
                      case 6: // Previous
                        // class="prev blackFont  event-478063-previous" id="eventPrevious_478063"
                        //<span title="">40,6</span>
                        var prevMatch = prevReg.Match(tdValue);
                        if (prevMatch.Success)
                          ev.Previous = prevMatch.Result("${value}").Trim();
                        break;
                      case 7: // Last
                        // class="alert js-injected-user-alert-container "  data-name ="Индекс деловой активности в производственном секторе (PMI) Германии" data-event-id="136" data-status-enabled="0"
                        //<span class="js-plus-icon alertBellGrayPlus genToolTip oneliner" data-tooltip="Создать уведомление" data-tooltip-alt="Уведомление активно" data-reg_ep="add alert"></span>    
                        ev.Last = tdValue;
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
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.ToString());
      }

      orig.Where(e => !result.Contains(e)).ToList().ForEach(e => contex.EconomicSchedule.Remove(e));
      result.Where(e => !orig.Contains(e)).ToList().ForEach(e => contex.EconomicSchedule.Add(e));
      await contex.SaveChangesAsync();

      return result;
    }
  }
}
