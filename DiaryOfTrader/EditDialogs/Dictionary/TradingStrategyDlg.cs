
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TradingStrategyDlg : GridEditDialogGeneric<TradingStrategy>
  {
    public TradingStrategyDlg(IRepository<TradingStrategy> repository, ILogger<GridEditDialogGeneric<TradingStrategy>> logger) : base(repository, logger)
    {
      InitializeComponent();
    }
  }
}
