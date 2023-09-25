using System.ComponentModel.DataAnnotations;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class MarketReviewPage
{
  private FormModel _model = new FormModel();
  private bool _formInvalid = true;
  
  public MarketReview MarketReview { get; set; } = new();
  public List<TraderExchange?> Exchanges { get; set; }
  public List<Symbol?> Symbols { get; set; }

  #region HttpRepositories

  [Inject] public ITraderExchangeRepository ExchangeRepository { get; set; }
  [Inject] public ISymbolRepository SymbolRepository { get; set; }

  #endregion
  
  
  protected override async Task OnInitializedAsync()
  {
    Exchanges = await ExchangeRepository.GetAllAsync();
    _model.SelectedExchange = Exchanges.FirstOrDefault()?.ID ?? 0;
    
    Symbols = await SymbolRepository.GetAllAsync();
  }
  
  
  internal class FormModel
  {
    [Required(ErrorMessage = "Choose a exchange.")]
    public long? SelectedExchange { get; set; }
    
    [Required(ErrorMessage = "Choose a symbols.")]
    public long? SelectedSymbols { get; set; }
  }
}
