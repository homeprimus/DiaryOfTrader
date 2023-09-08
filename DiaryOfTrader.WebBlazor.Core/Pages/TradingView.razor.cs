using DiaryOfTrader.WebBlazor.Core.JsInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class TradingView: IAsyncDisposable
{
  private TraderViewJsInterop _interop;
  
  [Inject]public IJSRuntime jsRuntime { get; set; }
  
  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      _interop = new TraderViewJsInterop(jsRuntime);
      await _interop.InitWidget();
    }
    
  }
  //
  // protected override void OnAfterRender(bool firstRender)
  // {
  //   if (firstRender)
  //   {
  //     
  //     _interop = new TraderViewJsInterop(jsRuntime);
  //      _interop.InitWidget().Wait();
  //   }
  // }


  public async ValueTask DisposeAsync()
  {
    await _interop.DisposeAsync();
  }
}
