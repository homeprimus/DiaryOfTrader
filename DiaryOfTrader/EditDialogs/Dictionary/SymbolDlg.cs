
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class SymbolDlg : GridEditDialog
  {
    ISymbolRepository _repository;
    ILogger<SymbolDlg> _logger;
    public SymbolDlg(ILogger<SymbolDlg> logger, ISymbolRepository repository)
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
