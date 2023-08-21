using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface IExchangeHttpRepository
{
  Task<List<TraderExchange>> GetTraderExchanges();
  Task<TraderExchange?> GetTraderExchange(long id);
  Task CreateTraderExchange(TraderExchange traderExchange);
  Task UpdateTraderExchange(TraderExchange traderExchange);
  Task DeleteTraderExchange(long id);
}
