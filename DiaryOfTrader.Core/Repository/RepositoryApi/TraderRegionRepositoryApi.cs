using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderRegionRepositoryApi: RepositoryApi<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TraderRegion>> logger) : base(config, client, logger)
    {
    }
  }
}
