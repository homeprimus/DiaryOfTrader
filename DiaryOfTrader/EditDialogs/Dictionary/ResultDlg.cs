
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class ResultDlg : GridEditDialogGeneric<TraderResult>
  {
    public ResultDlg(IRepository<TraderResult> repository, ILogger<GridEditDialogGeneric<TraderResult>> logger): base(repository, logger) 
    {
      InitializeComponent();
      grid.gcOrder.Visible = false;
    }
  }
}
