using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class CatalogTable<TItem> where TItem : Entity
{
  [Parameter]
  public List<TItem>? Entities { get; set; } = new();
  
}
