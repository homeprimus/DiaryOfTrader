using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.Web1.Components;

public partial class ExchangesTable
{
  [Parameter]
  public List<TraderExchange> Exchanges { get; set; }
  
}
