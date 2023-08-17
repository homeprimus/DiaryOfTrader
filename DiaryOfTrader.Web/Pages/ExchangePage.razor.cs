using System.Net.Http.Json;
using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.Web.Pages;

public partial class ExchangePage
{
  public List<TraderExchange> Exchanges { get; set; }
  
  [Inject]
  public HttpClient Http { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    Exchanges = await Http.GetFromJsonAsync<List<TraderExchange>>("sample-data/exchanges.json");
  }

}
