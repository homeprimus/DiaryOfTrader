using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public class WalletHttpRepository:IWalletHttpRepository
{
  private readonly HttpClient _client;
  private string _url = "wallets";
  
  public WalletHttpRepository(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<List<Wallet>> GetWallets()
  {
    return await _client.GetFromJsonAsync<List<Wallet>>(_url);
  }

  public async Task<Wallet?> GetWallet(long id)
  {
    return await _client.GetFromJsonAsync<Wallet>($"{_url}/{id}");
  }

  public async Task CreateWallet(Wallet wallet)
  {
    await _client.PostAsJsonAsync(_url, wallet);
  }

  public async Task UpdateWallet(Wallet wallet)
  {
    await _client.PutAsJsonAsync(Path.Combine(_url,
      wallet.ID.ToString()), wallet);
  }

  public async Task DeleteWallet(long id)
  {
    await _client.DeleteAsync($"{_url}/{id}");
  }
}
