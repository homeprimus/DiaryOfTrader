using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TraderRegionPage:IDisposable
{
  public List<TraderRegion?> TraderRegions { get; set; }
  
  [Inject]
  public ITraderRegionRepository HttpRepo { get; set; }
  
  [Inject] 
  public CatalogItemState CatalogItemState { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    TraderRegions = await HttpRepo.GetAllAsync();
  }
  
  protected override void OnInitialized()
  {
    CatalogItemState.OnChange += StateHasChanged;
  }

  public void Dispose()
  {
    CatalogItemState.OnChange -= StateHasChanged;
  }
}
