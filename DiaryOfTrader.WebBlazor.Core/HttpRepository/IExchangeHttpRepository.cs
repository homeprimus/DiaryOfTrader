using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public interface IExchangeHttpRepository
{
  Task<List<TraderExchange>> GetTraderExchanges();
  Task<TraderExchange?> GetTraderExchange(long id);
  Task CreateTraderExchange(TraderExchange traderExchange);
  Task UpdateTraderExchange(TraderExchange errorCode);
  Task DeleteTraderExchange(long id);
}
