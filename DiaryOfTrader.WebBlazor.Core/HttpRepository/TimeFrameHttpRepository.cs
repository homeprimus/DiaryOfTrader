using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class TimeFrameHttpRepository:ITimeFrameHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "timeframes";
  
  public TimeFrameHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<List<TimeFrame>> GetTimeFrame()
  {
    return await _client.GetFromJsonAsync<List<TimeFrame>>(_url);
  }

  public async Task<TimeFrame?> GetTimeFrame(long id)
  {
    return await _client.GetFromJsonAsync<TimeFrame>($"{_url}/{id}");
  }

  public async Task CreateTimeFrame(TimeFrame timeFrame)
  {
    await _client.PostAsJsonAsync(_url, timeFrame);
  }

  public async Task UpdateTimeFrame(TimeFrame timeFrame)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      timeFrame.ID.ToString()), timeFrame);
  }

  public async Task DeleteTimeFrame(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
