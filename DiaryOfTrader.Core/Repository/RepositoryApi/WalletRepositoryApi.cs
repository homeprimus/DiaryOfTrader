
namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class WalletRepositoryApi : RepositoryApi<Wallet>, IWalletRepository
  {
    public WalletRepositoryApi(string root) : base(root)
    {
    }
  }
}
