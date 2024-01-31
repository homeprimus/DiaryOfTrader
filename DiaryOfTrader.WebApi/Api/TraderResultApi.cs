using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderResultApi : Api<TraderResult, ITraderResultRepository>, IApi
  {
    public TraderResultApi(IOptions<EndPointConfiguration> config, ILogger<Api<TraderResult, ITraderResultRepository>> logger) : base(config, logger)
    {
    }
  }
}
