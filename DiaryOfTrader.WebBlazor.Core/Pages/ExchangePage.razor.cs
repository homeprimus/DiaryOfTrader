using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class ExchangePage
{
  public List<TraderExchange> Exchanges { get; set; }
  
    
  [Inject]
  public IExchangeHttpRepository HttpRepo { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    Exchanges = await HttpRepo.GetTraderExchanges();
  }

}
