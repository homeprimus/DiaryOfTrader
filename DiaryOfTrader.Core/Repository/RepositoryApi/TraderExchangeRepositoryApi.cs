
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderExchangeRepositoryApi : RepositoryApi<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TraderExchange>> logger) : base(config, client, logger)
    {
    }
  }
}
