
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TimeFrameRepositoryApi: RepositoryApi<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TimeFrame>> logger) : base(config, client, logger)
    {
    }
  }
}
