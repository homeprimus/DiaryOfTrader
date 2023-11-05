using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TradingStrategyApi:  Api<TradingStrategy, ITradingStrategyRepository>
  {
    public TradingStrategyApi(IOptions<EndPointConfiguration> config, ILogger<Api<TradingStrategy, ITradingStrategyRepository>> logger) : base(config, logger)
    {
    }
  }
}
