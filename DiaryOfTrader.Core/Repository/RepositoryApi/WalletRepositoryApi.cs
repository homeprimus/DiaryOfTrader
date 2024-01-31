
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class WalletRepositoryApi : RepositoryApi<Wallet>, IWalletRepository
  {
    public WalletRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<Wallet>> logger) : base(config, client, logger)
    {
    }
  }
}
