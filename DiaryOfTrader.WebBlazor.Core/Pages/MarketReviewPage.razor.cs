using System.ComponentModel.DataAnnotations;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class MarketReviewPage
{
  private FormModel _model = new FormModel();
  private bool _formInvalid = true;
  
  public MarketReview MarketReview { get; set; } = new();
  public List<TraderExchange?> Exchanges { get; set; }
  public List<Symbol?> Symbols { get; set; }
  public List<TimeFrame?> TimeFrames { get; set; }
  public List<Trend?> Trends { get; set; }
  private TraderExchange SelectedExchange
  {
    get
    {
      return Exchanges.FirstOrDefault(x => x.ID == _model.SelectedExchange);
    }
  }
  private Symbol SelectedSymbol
  {
    get
    {
      return Symbols.FirstOrDefault(x => x.ID == _model.SelectedSymbols);
    }
  }
  private MarketReviewTimeFrame NewMarketReviewTimeFrame { get; set; }

  #region HttpRepositories

  [Inject] public ITraderExchangeRepository ExchangeRepository { get; set; }
  [Inject] public ISymbolRepository SymbolRepository { get; set; }
  [Inject] public ITimeFrameRepository TimeFrameRepository { get; set; }
  [Inject] public ITrendRepository TrendRepository { get; set; }
  [Inject] public IMarketReviewRepository MarketReviewRepository { get; set; }
  [Inject] public IMarketReviewTimeFrameRepository MarketReviewTimeFrameRepository { get; set; }

  #endregion
  
  
  protected override async Task OnInitializedAsync()
  {
    Exchanges = await ExchangeRepository.GetAllAsync();
    _model.SelectedExchange = Exchanges.FirstOrDefault()?.ID ?? 0;
    
    Symbols = await SymbolRepository.GetAllAsync();
    _model.SelectedSymbols = Symbols.FirstOrDefault()?.ID ?? 0;
    
    TimeFrames = await TimeFrameRepository.GetAllAsync();
    Trends = await TrendRepository.GetAllAsync();
  }
  
  
  internal class FormModel
  {
    [Required(ErrorMessage = "Choose a exchange.")]
    public long? SelectedExchange { get; set; }
    
    [Required(ErrorMessage = "Choose a symbols.")]
    public long? SelectedSymbols { get; set; }
  }

  private void AddFrame()
  {
    NewMarketReviewTimeFrame = new MarketReviewTimeFrame();
    // NavigationManager.NavigateTo("/createMarketReviewTimeFrame");
  }

  private void SaveNewMarketReviewTimeFrame()
  {
    NewMarketReviewTimeFrame.Market = MarketReview;
    MarketReview.Frames.Add(NewMarketReviewTimeFrame);
  }

  private async Task SaveMarketReview()
  {
    MarketReview.Exchange = SelectedExchange;
    MarketReview.Symbol = SelectedSymbol;
    await MarketReviewRepository.InsertAsync(MarketReview);
  }
}
