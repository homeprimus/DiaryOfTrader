using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TraderSessionPage
{
  public List<TraderSession?> TraderSessions { get; set; }

  [Inject] public ITraderSessionRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    TraderSessions = await HttpRepo.GetAllAsync();
  }
}
