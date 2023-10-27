
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TimeFrameDlg : GridEditDialog
  {
    ITimeFrameRepository _repository;
    ILogger<TimeFrameDlg> _logger;
    public TimeFrameDlg(ILogger<TimeFrameDlg> logger, ITimeFrameRepository repository)
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
