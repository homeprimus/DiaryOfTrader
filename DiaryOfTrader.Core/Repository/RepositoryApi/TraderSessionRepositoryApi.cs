
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderSessionRepositoryApi : RepositoryApi<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TraderSession>> logger) : base(config, client, logger)
    {
    }
  }
}
