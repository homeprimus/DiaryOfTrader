using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class TradingStrategyApi:  Api<TradingStrategy, ITradingStrategyRepository>
  {
    public TradingStrategyApi(EndPointConfiguration config, ILogger<Api<TradingStrategy, ITradingStrategyRepository>> logger) : base(config, logger)
    {
    }
  }
}
