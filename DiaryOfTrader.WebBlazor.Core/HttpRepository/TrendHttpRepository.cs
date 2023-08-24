using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class TrendHttpRepository: ITrendHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "trend";

  public TrendHttpRepository(HttpClient client)
  {
    _client = client;
  }

  public async Task<List<Trend>?> GetTrends()
  {
    return await _client.GetFromJsonAsync<List<Trend>>(_url);
  }

  public async Task<Trend?> GetTrend(long id)
  {
    return await _client.GetFromJsonAsync<Trend>($"{_url}/{id}");
  }

  public async Task CreateTrend(Trend traderResult)
  {
    await _client.PostAsJsonAsync(_url, traderResult);
  }

  public async Task UpdateTrend(Trend traderResult)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      traderResult.ID.ToString()), traderResult);
  }

  public async Task DeleteTrend(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
