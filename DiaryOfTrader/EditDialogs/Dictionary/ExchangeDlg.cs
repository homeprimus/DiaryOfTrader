namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class ExchangeDlg : GridEditDialogGeneric<TraderExchange>
  {
    public ExchangeDlg(IRepository<TraderExchange> repository, ILogger<GridEditDialogGeneric<TraderExchange>> logger): base(repository, logger) 
    {
      InitializeComponent();
    }
  }
}
