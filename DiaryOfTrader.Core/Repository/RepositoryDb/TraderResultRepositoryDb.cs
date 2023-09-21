
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderResultRepositoryDb: RepositoryDb<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryDb(DbContext data, ICache cache, ILogger<TraderResultRepositoryDb> logger) : base(data, cache, logger) { }

  }
}
