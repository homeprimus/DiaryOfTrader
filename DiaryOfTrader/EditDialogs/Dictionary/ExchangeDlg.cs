namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class ExchangeDlg : GridEditDialog
  {
    ITraderExchangeRepository _repository;
    ILogger<ExchangeDlg> _logger;
    public ExchangeDlg(ILogger<ExchangeDlg> logger, ITraderExchangeRepository repository)
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
