using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Calendar;
using DiaryOfTrader.EditDialogs.Dictionary;

namespace DiaryOfTrader
{
  public partial class RibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    #region fields
    private readonly CancellationTokenSource _cancelTokenSource;
    private readonly DiaryOfTraderCtx _context;// = new();
    private Task? _updateThisWeekAsync;

    #endregion

    public RibbonMain()
    {
      InitializeComponent();

      _cancelTokenSource = new CancellationTokenSource();
      _context = new DiaryOfTraderCtx();

      var eco = new EconomicParser(_context, _cancelTokenSource.Token);
      _updateThisWeekAsync = eco.UpdateThisWeekAsync();

    }

    private static void Proccessing<T>(GridEditDialog dlg, IRepository<T> repository) where T : Entity
    {
      dlg.DoLoad(repository);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        dlg.DoUpdate(repository);
      }
    }
    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new ExchangeDlg(), Core.Entity.DiaryOfTrader.TraderExchangeRepository);
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new SymbolDlg(), Core.Entity.DiaryOfTrader.SymbolRepository);
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new TradeSessionDlg(), Core.Entity.DiaryOfTrader.TraderRegionRepository);
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new TimeFrameDlg(), Core.Entity.DiaryOfTrader.TimeFrameRepository);
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new ResultDlg(), Core.Entity.DiaryOfTrader.TraderResultRepository);
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new TrendDlg(), Core.Entity.DiaryOfTrader.TrendRepository);
    }

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      Proccessing(new WalletDlg(), Core.Entity.DiaryOfTrader.WalletRepository);
    }

    private void bbtCalendar_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (_updateThisWeekAsync != null)
      {
        Task.WaitAll(_updateThisWeekAsync);
        _updateThisWeekAsync = null;
      }

      var calendar = new CalendarDlg();
      calendar.Text = e.Item.Caption;
      calendar.Contex = _context;
      calendar.ShowDialog();
    }

    private void bbiMarketReview_ItemClick(object sender, ItemClickEventArgs e)
    {
      tcMain.SelectedTabPage = tpMarketReview;
    }

    private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
    {
      tcMain.SelectedTabPage = tpDiary;
    }
  }

}
