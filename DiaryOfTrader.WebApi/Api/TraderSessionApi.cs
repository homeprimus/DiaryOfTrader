using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderSessionApi : Api<TraderSession, ITraderSessionRepository>, IApi
  {
    public TraderSessionApi(IOptions<EndPointConfiguration> config, ILogger<Api<TraderSession, ITraderSessionRepository>> logger) : base(config, logger)
    {
    }
  }
}
