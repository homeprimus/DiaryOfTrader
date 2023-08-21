using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface IWalletHttpRepository
{
  Task<List<Wallet>> GetWallets();
  Task<Wallet?> GetWallet(long id);
  Task CreateWallet(Wallet wallet);
  Task UpdateWallet(Wallet wallet);
  Task DeleteWallet(long id);
}
