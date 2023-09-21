
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderExchangeRepositoryDb : RepositoryDb<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryDb(DbContext data, ICache cache, ILogger<TraderExchangeRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
