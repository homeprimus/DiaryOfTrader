using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TraderSessionPage
{
  public List<TraderSession>? TraderSessions { get; set; }

  [Inject] public ITraderSessionHttpRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    TraderSessions = await HttpRepo.GetTraderSessions();
  }
}
