using System.Net.Http.Json;
using System.Web;
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class EconomicCalendarRepositoryApi: Disposable, IEconomicCalendarRepository
  {
    #region const
    private const string CALENDAR = "/calendar";
    private const string PERIOD = "period";
    private const string IMPORTANCE = "importance";
    private const string END_DATE = "enddate";
    private const string START_DATE = "startdate";
    private const string DATE_FORMAT = "YYYY-MM-dd";
    #endregion
    #region fields
    private readonly HttpClient _client = new ();
    private readonly string _endPoint;
    #endregion

    public EconomicCalendarRepositoryApi(string root)
    {
      _endPoint = root + CALENDAR;
    }

    public async Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      var uriBuilder = new UriBuilder(_endPoint);
      var query = HttpUtility.ParseQueryString(uriBuilder.Query);
      query[PERIOD] = period.ToString();
      query[IMPORTANCE] = importance.ToString();
      uriBuilder.Query = query.ToString();
      return await _client.GetFromJsonAsync<List<EventCalendar>>(uriBuilder.ToString());
    }

    public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      var uriBuilder = new UriBuilder(_endPoint);
      var query = HttpUtility.ParseQueryString(uriBuilder.Query);
      query[START_DATE] = startDate.ToString(DATE_FORMAT);
      query[END_DATE] = startDate.ToString(DATE_FORMAT);
      query[PERIOD] = period.ToString();
      query[IMPORTANCE] = importance.ToString();
      uriBuilder.Query = query.ToString();
      return await _client.GetFromJsonAsync<List<EventCalendar>>(uriBuilder.ToString());
    }
    protected override void Free()
    {
      base.Free();
      _client.Dispose();
    }

  }
}
