
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class WalletRepositoryDb: RepositoryDb<Wallet>, IWalletRepository
  {
    public WalletRepositoryDb(DbContext data): base(data) { }
  }
}
