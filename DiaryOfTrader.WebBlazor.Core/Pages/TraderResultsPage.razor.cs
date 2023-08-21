using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TraderResultsPage
{
  public List<TraderResult> TraderResults { get; set; }

  [Inject] public ITraderResultHttpRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    TraderResults = await HttpRepo.GetTraderResults();
  }
}
