using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class WalletApi : Api<Wallet, IWalletRepository>, IApi
  {
    public WalletApi(ILogger<RepositoryDb<Wallet>> logger) : base(logger)
    {
    }
  }
}
