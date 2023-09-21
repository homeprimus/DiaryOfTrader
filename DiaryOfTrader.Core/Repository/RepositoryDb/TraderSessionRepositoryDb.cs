
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderSessionRepositoryDb: RepositoryDb<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryDb(DbContext data, ICache cache, ILogger<TraderSessionRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
