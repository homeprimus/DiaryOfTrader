using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderRegionApi : Api<TraderRegion, ITraderRegionRepository>, IApi
  {
    public TraderRegionApi(EndPointConfiguration config, ILogger<Api<TraderRegion, ITraderRegionRepository>> logger) : base(config, logger)
    {
    }
  }
}
