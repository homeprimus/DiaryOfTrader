
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderExchangeRepositoryDb : RepositoryDb<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryDb(DbContext data) : base(data) { }
  }
}
