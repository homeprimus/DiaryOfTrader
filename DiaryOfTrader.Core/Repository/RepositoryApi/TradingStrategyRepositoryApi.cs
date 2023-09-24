
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TradingStrategyRepositoryApi : RepositoryApi<TradingStrategy>, ITradingStrategyRepository
  {
    public TradingStrategyRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TradingStrategy>> logger) : base(config, client, logger)
    {
    }
  }
}
