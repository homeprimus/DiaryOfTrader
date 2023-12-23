using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderRegionRepositoryApi: RepositoryApi<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TraderRegion>> logger) : base(config, client, logger)
    {
    }
  }
}
