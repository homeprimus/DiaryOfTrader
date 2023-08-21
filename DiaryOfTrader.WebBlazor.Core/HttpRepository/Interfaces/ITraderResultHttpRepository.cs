using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface ITraderResultHttpRepository
{
  Task<List<TraderResult>> GetTraderResults();
  Task<TraderResult?> GetTraderResult(long id);
  Task CreateTraderResult(TraderResult traderResult);
  Task UpdateTraderResult(TraderResult traderResult);
  Task DeleteTraderResult(long id);
}
