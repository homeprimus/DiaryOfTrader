
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class WalletRepositoryDb: RepositoryDb<Wallet>, IWalletRepository
  {
    public WalletRepositoryDb(DbContext data, ICache cache, ILogger<WalletRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
