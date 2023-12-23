
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderRepositoryApi : RepositoryApi<Trader>, ITraderRepository
  {
    public TraderRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<Trader>> logger) : base(config, client, logger)
    {
    }

    public Task<Trader> Search(string user, string password)
    {
      throw new NotImplementedException();
    }
  }
}
