using DiaryOfTrader.WebBlazor.Core.JsInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TradingView
{
  private IJSObjectReference? _jsModule;
  
  [Inject]public IJSRuntime? JSRuntime { get; set; }
  
  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/tradeview.js");

      await InitWidget();
    }			
  }

  private async Task InitWidget()
  {
    await _jsModule.InvokeVoidAsync("InitWidget");
  }
}
