using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface ITrendHttpRepository
{
  Task<List<Trend>?> GetTrends();
  Task<Trend?> GetTrend(long id);
  Task CreateTrend(Trend traderResult);
  Task UpdateTrend(Trend traderResult);
  Task DeleteTrend(long id);
}
