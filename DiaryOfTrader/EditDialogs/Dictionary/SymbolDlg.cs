
namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class SymbolDlg : GridEditDialogGeneric<Symbol>
  {
    public SymbolDlg(IRepository<Symbol> repository, ILogger<GridEditDialogGeneric<Symbol>> logger) : base(repository, logger)
    {
      InitializeComponent();
    }
  }
}
