
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TrendRepositoryApi : RepositoryApi<Trend>, ITrendRepository
  {
    public TrendRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<Trend>> logger) : base(config, client, logger)
    {
    }
  }
}
