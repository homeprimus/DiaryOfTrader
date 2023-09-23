using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class WalletApi : Api<Wallet, IWalletRepository>, IApi
  {
    public WalletApi(EndPointConfiguration config, ILogger<Api<Wallet, IWalletRepository>> logger) : base(config, logger)
    {
    }
  }
}
