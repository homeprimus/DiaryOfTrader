
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TradingStrategyRepositoryApi : RepositoryApi<TradingStrategy>, ITradingStrategyRepository
  {
    public TradingStrategyRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TradingStrategy>> logger) : base(config, client, logger)
    {
    }
  }
}
