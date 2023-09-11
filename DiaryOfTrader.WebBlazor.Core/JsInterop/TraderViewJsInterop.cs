using Microsoft.JSInterop;

namespace DiaryOfTrader.WebBlazor.Core.JsInterop;

public class TraderViewJsInterop : IAsyncDisposable
{
  private readonly Lazy<Task<IJSObjectReference>> moduleTask;

  public TraderViewJsInterop(IJSRuntime jsRuntime)
  {
    moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
      "import", "./_content/DiaryOfTrader.WebBlazor.Core/tradeview.js").AsTask());
  }
  
  public async Task InitWidget()
  {
    var module = await moduleTask.Value;
    await module.InvokeVoidAsync("InitWidget");
  }

  public async ValueTask DisposeAsync()
  {
    if (moduleTask.IsValueCreated)
    {
      var module = await moduleTask.Value;
      await module.DisposeAsync();
    }
  }
}
