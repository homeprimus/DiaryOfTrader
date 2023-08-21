using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class TraderResultTable
{
  [Parameter]
  public List<TraderResult> TraderResults { get; set; }
}
