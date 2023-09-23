using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class ExchangePage
{
  public List<TraderExchange?> Exchanges { get; set; }
  
    
  [Inject]
  public ITraderExchangeRepository ApiRepo { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    Exchanges = await ApiRepo.GetAllAsync();
  }

  private async Task DeleteExchange(long id)
  {
    await ApiRepo.DeleteAsync(id);
    Exchanges.Remove(Exchanges.FirstOrDefault(x => x.ID == id));
  }
}
