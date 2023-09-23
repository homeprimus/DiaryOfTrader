using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TrendPage
{
  public List<Trend?> Trends { get; set; }

  [Inject] public ITrendRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    Trends = await HttpRepo.GetAllAsync();
  }

  private async Task DeleteTrend(long id)
  {
    await HttpRepo.DeleteAsync(id);
    Trends.Remove(Trends.FirstOrDefault(x => x.ID == id));
  }
}
