using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface ITraderSessionHttpRepository
{
  Task<List<TraderSession>?> GetTraderSessions();
  Task<TraderSession?> GetTraderSession(long id);
  Task CreateTraderSession(TraderSession session);
  Task UpdateTraderSession(TraderSession session);
  Task DeleteTraderSession(long id);
}
