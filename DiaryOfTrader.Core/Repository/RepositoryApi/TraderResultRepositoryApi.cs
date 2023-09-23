using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderResultRepositoryApi: RepositoryApi<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TraderResult>> logger) : base(config, client, logger)
    {
    }
  }
}
