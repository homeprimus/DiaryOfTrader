using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class TraderResultHttpRepository:ITraderResultHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "traderresults";
  
  public TraderResultHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<List<TraderResult>> GetTraderResults()
  {
    return await _client.GetFromJsonAsync<List<TraderResult>>(_url);
  }

  public async Task<TraderResult?> GetTraderResult(long id)
  {
    return await _client.GetFromJsonAsync<TraderResult>($"{_url}/{id}");
  }

  public async Task CreateTraderResult(TraderResult traderResult)
  {
    await _client.PostAsJsonAsync(_url, traderResult);
  }

  public async Task UpdateTraderResult(TraderResult traderResult)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      traderResult.ID.ToString()), traderResult);
  }

  public async Task DeleteTraderResult(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
