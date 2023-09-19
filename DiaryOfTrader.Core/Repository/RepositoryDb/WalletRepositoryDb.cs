
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class WalletRepositoryDb: RepositoryDb<Wallet>, IWalletRepository
  {
    public WalletRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
