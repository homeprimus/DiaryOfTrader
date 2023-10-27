
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TrendDlg : GridEditDialog
  {
    ITrendRepository _repository;
    ILogger<TrendDlg> _logger;
    public TrendDlg(ILogger<TrendDlg> logger, ITrendRepository repository)
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
