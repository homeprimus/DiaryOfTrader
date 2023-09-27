using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class MarketReviewTimeFrame
{
  [Parameter]
  public TraderExchange Exchange { get; set; }
}
