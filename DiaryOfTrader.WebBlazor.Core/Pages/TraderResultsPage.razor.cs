using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TraderResultsPage
{
  public List<TraderResult?> TraderResults { get; set; }

  [Inject] public ITraderResultRepository HttpRepo { get; set; }


  protected override async Task OnInitializedAsync()
  {
    TraderResults = await HttpRepo.GetAllAsync();
  }

  private async Task DeleteTraderResult(long id)
  {
    await HttpRepo.DeleteAsync(id);
    TraderResults.Remove(TraderResults.FirstOrDefault(x => x.ID == id));
  }
}
