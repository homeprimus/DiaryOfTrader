using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class CatalogTable<TItem> where TItem : Entity
{
  [Inject] 
  public CatalogItemState CatalogItemState { get; set; }
  
  [Inject]
  public NavigationManager? NavigationManager { get; set; }
  
  [Parameter]
  public List<TItem>? Entities { get; set; } = new();
  
  [Parameter]
  public string RedirectEditUrl { get; set; } = string.Empty;
  
  public TItem SelectedItem { get; set; }
  
  private void Select(TItem selectedItem)
  {
    SelectedItem = selectedItem;
    CatalogItemState.SetItem(SelectedItem);
  }

  private void RedirectToEditPage(long id)
  {
    if(!string.IsNullOrEmpty(RedirectEditUrl))
      NavigationManager.NavigateTo($"{RedirectEditUrl}/{id}");
  }
}
