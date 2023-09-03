using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core;

public class CatalogItemState
{
  public Entity? SelectedEntity { get; private set; }

  public event Action OnChange;

  public void SetItem(Entity entity)
  {
    SelectedEntity = entity;
    NotifyStateChanged();
  }

  private void NotifyStateChanged() => OnChange?.Invoke();
}
