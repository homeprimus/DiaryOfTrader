
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TrendRepositoryApi : RepositoryApi<Trend>, ITrendRepository
  {
    public TrendRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<Trend>> logger) : base(config, client, logger)
    {
    }
  }
}
