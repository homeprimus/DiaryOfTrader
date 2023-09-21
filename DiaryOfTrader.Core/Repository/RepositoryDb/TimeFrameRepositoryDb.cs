
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TimeFrameRepositoryDb: RepositoryDb<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryDb(DbContext data, ICache cache, ILogger<TimeFrameRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
