using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class ExchangeHttpRepository:IExchangeHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "traderexchanges";
  
  public ExchangeHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<List<TraderExchange>> GetTraderExchanges()
  {
     return await _client.GetFromJsonAsync<List<TraderExchange>>(_url);
  }

  public async Task<TraderExchange?> GetTraderExchange(long id)
  {
    return await _client.GetFromJsonAsync<TraderExchange>($"{_url}/{id}");
  }

  public async Task CreateTraderExchange(TraderExchange traderExchange)
  {
    await _client.PostAsJsonAsync(_url, traderExchange);
  }

  public async Task UpdateTraderExchange(TraderExchange traderExchange)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      traderExchange.ID.ToString()), traderExchange);
  }

  public async Task DeleteTraderExchange(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
