using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.Shared;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class CatalogTable<TItem> where TItem : Entity
{
  private Confirmation _confirmation;
  private long _entityIdToDelete;
  
  [Inject] 
  public CatalogItemState CatalogItemState { get; set; }
  
  [Inject]
  public NavigationManager? NavigationManager { get; set; }
  
  [Parameter]
  public List<TItem>? Entities { get; set; } = new();
  
  [Parameter]
  public string RedirectEditUrl { get; set; } = string.Empty;
  
  [Parameter]
  public EventCallback<long> OnDelete { get; set; }
  
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
  
  private void CallConfirmationModal(long id)
  {
    _entityIdToDelete = id;
    _confirmation.Show();
  }

  private async Task DeleteEntity()
  {
    _confirmation.Hide();
    await OnDelete.InvokeAsync(_entityIdToDelete);
  }
}
