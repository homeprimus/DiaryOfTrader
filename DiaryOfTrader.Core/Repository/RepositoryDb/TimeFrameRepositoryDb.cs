
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TimeFrameRepositoryDb: RepositoryDb<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
