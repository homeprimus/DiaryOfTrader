
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TrendDlg : GridEditDialogGeneric<Trend>
  {
    public TrendDlg(IRepository<Trend> repository, ILogger<GridEditDialogGeneric<Trend>> logger) : base(repository, logger)
    {
      InitializeComponent();
    }
  }
}
