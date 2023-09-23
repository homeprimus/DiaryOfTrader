using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TimeFramePage
{
  public List<TimeFrame?> TimeFrames { get; set; }
  
    
  [Inject]
  public ITimeFrameRepository HttpRepo { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    TimeFrames = await HttpRepo.GetAllAsync();
  }

  private async Task DeleteTimeFrame(long id)
  {
    await HttpRepo.DeleteAsync(id);
    TimeFrames.Remove(TimeFrames.FirstOrDefault(x => x.ID == id));
  }
}
