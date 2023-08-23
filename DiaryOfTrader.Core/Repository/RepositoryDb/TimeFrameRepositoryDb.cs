
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TimeFrameRepositoryDb: RepositoryDb<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryDb(DbContext data) : base(data) { }
  }
}
