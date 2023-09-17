using Blazored.Toast.Services;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.WebBlazor.Core.HttpInterceptor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DiaryOfTrader.WebBlazor.Core.Pages.EditCatalogPages;

public partial class TimeFrameEditPage:IDisposable
{
  [Parameter] public long Id { get; set; }
  
  private TimeFrame? _timeFrame;
  private EditContext _editContext;
  private bool _formInvalid = false;

  [Inject] public ITimeFrameRepository? Repository { get; set; }

  [Inject] public HttpInterceptorService? Interceptor { get; set; }

  [Inject] public IToastService? ToastService { get; set; }
    
    
  protected async override Task OnInitializedAsync()
  {
    _timeFrame = await Repository.GetByIdAsync(Id);
    _editContext = new EditContext(_timeFrame);
    _editContext.OnFieldChanged += HandleFieldChanged;
    Interceptor?.RegisterEvent();
  }
    
  private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
  {
    _formInvalid = !_editContext.Validate();
    StateHasChanged();
  }

  private async Task Update()
  {
    await Repository.UpdateAsync(_timeFrame);

    ToastService.ShowSuccess($"Update successful.");
  }

  public void Dispose()
  {
    Interceptor.DisposeEvent();
    _editContext.OnFieldChanged -= HandleFieldChanged;
  }
}
