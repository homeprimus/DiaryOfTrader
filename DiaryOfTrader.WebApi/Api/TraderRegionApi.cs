using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderRegionApi : Api<TraderRegion, ITraderRegionRepository>, IApi
  {
    public TraderRegionApi(IOptions<EndPointConfiguration> config, ILogger<Api<TraderRegion, ITraderRegionRepository>> logger) : base(config, logger)
    {
    }
  }
}
