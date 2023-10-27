
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class ResultDlg : GridEditDialog
  {
    ITraderResultRepository _repository;
    ILogger<ResultDlg> _logger;
    public ResultDlg(ILogger<ResultDlg> logger, ITraderResultRepository repository)
    {
      InitializeComponent();
      grid.gcOrder.Visible = false;

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
