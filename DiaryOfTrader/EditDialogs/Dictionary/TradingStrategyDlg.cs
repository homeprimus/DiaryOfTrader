
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TradingStrategyDlg : GridEditDialog
  {
    ITradingStrategyRepository _repository;
    ILogger<TradingStrategyDlg> _logger;
    public TradingStrategyDlg(ILogger<TradingStrategyDlg> logger, ITradingStrategyRepository repository)
    {
      InitializeComponent();
      _logger = logger;
      _repository = repository;
      DoLoad(_repository, _logger);
    }
    protected override void OnOkClick()
    {
      DoUpdate(_repository, _logger);
    }
  }
}
