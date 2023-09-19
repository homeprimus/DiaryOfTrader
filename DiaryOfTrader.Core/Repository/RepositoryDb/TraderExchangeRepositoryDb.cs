
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderExchangeRepositoryDb : RepositoryDb<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
