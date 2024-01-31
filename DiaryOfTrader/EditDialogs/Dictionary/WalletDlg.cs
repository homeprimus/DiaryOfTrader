
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class WalletDlg : GridEditDialogGeneric<Wallet>
  {
    public WalletDlg(IRepository<Wallet> repository, ILogger<GridEditDialogGeneric<Wallet>> logger) : base(repository, logger)
    {
      InitializeComponent();
    }
  }
}
