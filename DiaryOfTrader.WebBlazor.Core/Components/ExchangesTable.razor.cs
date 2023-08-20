using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class ExchangesTable
{
  [Parameter]
  public List<TraderExchange> Exchanges { get; set; }
  
}
