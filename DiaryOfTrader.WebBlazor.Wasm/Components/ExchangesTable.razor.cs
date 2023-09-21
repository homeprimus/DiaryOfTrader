using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.Web.Components;

public partial class ExchangesTable
{
  [Parameter]
  public List<TraderExchange> Exchanges { get; set; }
  
}
