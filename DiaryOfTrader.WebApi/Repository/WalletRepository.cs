
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class WalletRepository: Repository<Wallet>, IWalletRepository
  {
    public WalletRepository(DbContext data): base(data) { }
  }
}
