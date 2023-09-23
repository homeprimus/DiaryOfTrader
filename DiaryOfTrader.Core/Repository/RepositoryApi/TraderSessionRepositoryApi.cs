
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderSessionRepositoryApi : RepositoryApi<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TraderSession>> logger) : base(config, client, logger)
    {
    }
  }
}
