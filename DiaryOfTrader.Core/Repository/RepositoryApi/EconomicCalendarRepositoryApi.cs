using System.Net.Http.Json;
using System.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
    private readonly HttpClient _client;
    private readonly string _endPoint;
    private readonly ILogger<EconomicCalendarRepositoryApi> _logger;
    #endregion

    public EconomicCalendarRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<EconomicCalendarRepositoryApi> logger)
    {
      var entity = CALENDAR;
      var url = new UriBuilder(config.Value.EndPoint) { Path = config.Value.Version(entity) + "/" + entity + "s" };
      _endPoint = url.ToString();
      _logger = logger;
      _client = client;
    }

    public async Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      var uriBuilder = new UriBuilder(_endPoint);
      var query = HttpUtility.ParseQueryString(uriBuilder.Query);
      query[PERIOD] = period.ToString();
      query[IMPORTANCE] = importance.ToString();
      uriBuilder.Query = query.ToString();
      var events =  await _client.GetFromJsonAsync<List<EconomicSchedule>>(uriBuilder.ToString());
      return EconomicParser.MakeEventCalendar(events);
    }

    public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period,
      Importance importance)
    {
      var uriBuilder = new UriBuilder(_endPoint);
      var query = HttpUtility.ParseQueryString(uriBuilder.Query);
      query[START_DATE] = startDate.ToString(DATE_FORMAT);
      query[END_DATE] = startDate.ToString(DATE_FORMAT);
      query[PERIOD] = period.ToString();
      query[IMPORTANCE] = importance.ToString();
      uriBuilder.Query = query.ToString();
      var events = await _client.GetFromJsonAsync<List<EconomicSchedule>>(uriBuilder.ToString());
      return EconomicParser.MakeEventCalendar(events);
    }

    protected override void Free()
    {
      base.Free();
      _client.Dispose();
    }

  }
}
