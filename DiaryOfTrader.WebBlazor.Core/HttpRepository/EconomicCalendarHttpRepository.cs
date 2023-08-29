using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity.Economic;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class EconomicCalendarHttpRepository:IEconomicCalendarRepository
{
  [Inject] public HttpClient _client { get; set; }

  public EconomicCalendarHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public void Dispose()
  {
  }

  public async Task<List<EventCalendar>?> GetAsync(EconomicPeriod period, Importance importance)
  {
    var queryStringParam = new Dictionary<string, string>
    {
      ["startDate"] = null,
      ["endDate"] =null,
      ["period"] = period.ToString(),
      ["importance"] = importance.ToString()
    };

    return await _client.GetFromJsonAsync<List<EventCalendar>>(QueryHelpers.AddQueryString("calendar", queryStringParam));
  }

  public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
  {
    throw new NotImplementedException();
  }
}
