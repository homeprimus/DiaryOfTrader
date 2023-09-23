
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderExchangeRepositoryApi : RepositoryApi<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<TraderExchange>> logger) : base(config, client, logger)
    {
    }
  }
}
