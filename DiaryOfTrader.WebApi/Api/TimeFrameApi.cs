using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TimeFrameApi : Api<TimeFrame, ITimeFrameRepository>, IApi
  {
    public TimeFrameApi(EndPointConfiguration config, ILogger<Api<TimeFrame, ITimeFrameRepository>> logger) : base(config, logger)
    {
    }
  }
}

