
namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class WalletRepositoryDb: RepositoryDb<Wallet>, IWalletRepository
  {
    public WalletRepositoryDb(DbContext data): base(data) { }
  }
}
