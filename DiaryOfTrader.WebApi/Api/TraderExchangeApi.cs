using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderExchangeApi : Api<TraderExchange, ITraderExchangeRepository>, IApi
  {
    public TraderExchangeApi(IOptions<EndPointConfiguration> config, ILogger<Api<TraderExchange, ITraderExchangeRepository>> logger) : base(config, logger)
    {
    }
  }
}

