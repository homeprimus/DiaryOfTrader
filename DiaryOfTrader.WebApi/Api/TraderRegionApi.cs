using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderRegionApi : Api<TraderRegion, ITraderRegionRepository>, IApi
  {
    public TraderRegionApi(ILogger<RepositoryDb<TraderRegion>> logger) : base(logger)
    {
    }
  }
}
