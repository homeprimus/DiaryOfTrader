using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class TimeFrameTable
{
  [Parameter]
  public List<TimeFrame> TimeFrames { get; set; }
}
