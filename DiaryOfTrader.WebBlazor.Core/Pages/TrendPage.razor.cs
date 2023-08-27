using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TrendPage
{
  public List<Trend> Trends { get; set; }

  [Inject] public ITrendHttpRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    Trends = await HttpRepo.GetTrends();
  }
}
