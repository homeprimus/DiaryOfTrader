using Blazored.Toast.Services;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.WebBlazor.Core.HttpInterceptor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DiaryOfTrader.WebBlazor.Core.Pages.EditCatalogPages;

public partial class TraderRegionEditPage:IDisposable
{
  [Parameter] public long Id { get; set; }
  
  private TraderRegion? _traderRegion;
  private TraderRegion? _copyTraderRegion;
  private EditContext _editContext;
  private bool _formInvalid = false;

  [Inject] public ITraderRegionRepository? Repository { get; set; }
  [Inject] public ITraderSessionRepository? SessionRepository { get; set; }

  [Inject] public HttpInterceptorService? Interceptor { get; set; }

  [Inject] public IToastService? ToastService { get; set; }
    
    
  protected async override Task OnInitializedAsync()
  {
    _traderRegion = await Repository.GetByIdAsync(Id);
    _copyTraderRegion =  await Repository.GetByIdAsync(Id);
    _editContext = new EditContext(_traderRegion);
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
    foreach (var session in _copyTraderRegion.Sessions)
    {
      if (_traderRegion.Sessions.All(x => x.ID != session.ID))
      {
        await SessionRepository.DeleteAsync(session.ID);
      } 
      
      if(_traderRegion.Sessions.Any(x => x.ID == session.ID))
      {
        var ses= _traderRegion.Sessions.First(x=>x.ID == session.ID);
        if(!ses.Equals(session))
          await SessionRepository.UpdateAsync(session);
      }
    }

    foreach (var session in _traderRegion.Sessions)
    {
      if (_copyTraderRegion.Sessions.All(x => x.ID != session.ID))
      {
        await SessionRepository.InsertAsync(session);
      }
    }

    await Repository.UpdateAsync(_traderRegion);
    ToastService.ShowSuccess($"Update successful.");
  }

  public void Dispose()
  {
    Interceptor.DisposeEvent();
    _editContext.OnFieldChanged -= HandleFieldChanged;
  }

  private void DeleteSession(TraderSession session)
  {
    _traderRegion.Sessions.Remove(session);
  }

  private void AddSession()
  {
    _traderRegion.Sessions.Add(new TraderSession());
  }
}
