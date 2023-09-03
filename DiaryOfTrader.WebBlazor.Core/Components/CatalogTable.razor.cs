using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class CatalogTable<TItem> where TItem : Entity
{
  [Inject] 
  public CatalogItemState CatalogItemState { get; set; }
  
  [Parameter]
  public List<TItem>? Entities { get; set; } = new();
  
  public TItem SelectedItem { get; set; }
  
  private void Select(TItem selectedItem)
  {
    SelectedItem = selectedItem;
    CatalogItemState.SetItem(SelectedItem);
  }
  
}
