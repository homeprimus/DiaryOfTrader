using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TimeFrameApi : Api<TimeFrame, ITimeFrameRepository>, IApi
  {
    public TimeFrameApi(IOptions<EndPointConfiguration> config, ILogger<Api<TimeFrame, ITimeFrameRepository>> logger) : base(config, logger)
    {
    }
  }
}

