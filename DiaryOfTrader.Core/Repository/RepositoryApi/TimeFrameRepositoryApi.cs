
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TimeFrameRepositoryApi: RepositoryApi<TimeFrame>, ITimeFrameRepository
  {
    public TimeFrameRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TimeFrame>> logger) : base(config, client, logger)
    {
    }
  }
}
