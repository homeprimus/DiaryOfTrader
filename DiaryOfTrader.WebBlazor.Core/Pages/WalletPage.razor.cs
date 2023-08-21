using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class WalletPage
{
  public List<Wallet> Wallets { get; set; }

  [Inject] public IWalletHttpRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    Wallets = await HttpRepo.GetWallets();
  }
}
