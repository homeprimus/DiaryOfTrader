
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TimeFrameRepository: Repository<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepository(DbContext data) : base(data) { }
  }
}
