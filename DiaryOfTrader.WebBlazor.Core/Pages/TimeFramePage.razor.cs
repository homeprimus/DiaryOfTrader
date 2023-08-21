using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TimeFramePage
{
  public List<TimeFrame> TimeFrames { get; set; }
  
    
  [Inject]
  public ITimeFrameHttpRepository HttpRepo { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    TimeFrames = await HttpRepo.GetTimeFrame();
  }
}
