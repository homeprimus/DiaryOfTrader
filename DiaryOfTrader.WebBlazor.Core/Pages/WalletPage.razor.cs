using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class WalletPage
{
  public List<Wallet?> Wallets { get; set; }

  [Inject] public IWalletRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    Wallets = await HttpRepo.GetAllAsync();
  }
}
