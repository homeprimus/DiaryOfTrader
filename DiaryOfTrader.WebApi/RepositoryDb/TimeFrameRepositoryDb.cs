
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class TimeFrameRepositoryDb: RepositoryDb<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryDb(DbContext data) : base(data) { }
  }
}
