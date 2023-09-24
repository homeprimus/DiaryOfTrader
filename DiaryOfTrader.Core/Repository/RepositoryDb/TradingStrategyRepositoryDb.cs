using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TradingStrategyRepositoryDb: RepositoryDb<TradingStrategy>, ITradingStrategyRepository
  {
    public TradingStrategyRepositoryDb(DbContext data, ICache cache, ILogger<RepositoryDb<TradingStrategy>> logger) : base(data, cache, logger)
    {
    }
  }
}
