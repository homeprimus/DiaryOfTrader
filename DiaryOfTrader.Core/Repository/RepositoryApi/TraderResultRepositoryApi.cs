using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderResultRepositoryApi: RepositoryApi<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TraderResult>> logger) : base(config, client, logger)
    {
    }
  }
}
