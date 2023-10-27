
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class WalletDlg : GridEditDialog
  {
    IWalletRepository _repository;
    ILogger<WalletDlg> _logger;
    public WalletDlg(ILogger<WalletDlg> logger, IWalletRepository repository)
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
