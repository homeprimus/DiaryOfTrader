using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderExchangeApi : Api<TraderExchange, ITraderExchangeRepository>, IApi
  {
    public TraderExchangeApi(EndPointConfiguration config, ILogger<Api<TraderExchange, ITraderExchangeRepository>> logger) : base(config, logger)
    {
    }
  }
}

