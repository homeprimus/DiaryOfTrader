using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TimeFrameApi : Api<TimeFrame, ITimeFrameRepository>, IApi
  {
    public TimeFrameApi(ILogger<RepositoryDb<TimeFrame>> logger) : base(logger)
    {
    }
  }
}

