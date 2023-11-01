
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TimeFrameDlg : GridEditDialogGeneric<TimeFrame>
  {
    public TimeFrameDlg(IRepository<TimeFrame> repository, ILogger<GridEditDialogGeneric<TimeFrame>> logger) : base(repository, logger)
    {
      InitializeComponent();
    }
  }
}
