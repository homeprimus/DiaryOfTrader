
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class WalletRepositoryApi : RepositoryApi<Wallet>, IWalletRepository
  {
    public WalletRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<Wallet>> logger) : base(config, client, logger)
    {
    }
  }
}
