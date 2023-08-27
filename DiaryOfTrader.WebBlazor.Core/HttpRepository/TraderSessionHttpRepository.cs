using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Repository.RepositoryApi;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class TraderSessionHttpRepository: ITraderSessionHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "tradersessions";

  public TraderSessionHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<List<TraderSession>?> GetTraderSessions()
  {
    return await _client.GetFromJsonAsync<List<TraderSession>>(_url);
  }

  public async Task<TraderSession?> GetTraderSession(long id)
  {
    return await _client.GetFromJsonAsync<TraderSession>($"{_url}/{id}");
  }

  public async Task CreateTraderSession(TraderSession session)
  {
    await _client.PostAsJsonAsync(_url, session);
  }

  public async Task UpdateTraderSession(TraderSession session)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      session.ID.ToString()), session);
  }

  public async Task DeleteTraderSession(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
