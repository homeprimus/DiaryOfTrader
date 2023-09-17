using System.ComponentModel;
using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Utils;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Calendar;
using DiaryOfTrader.EditDialogs.Dictionary;
using Microsoft.Extensions.DependencyInjection;

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

    private bool EditDbSet<T>(GridEditDialog dlg, DbSet<T> data) where T : Entity
    {
      Entity.DoBeginEdit(data, out BindingList<T> orig, out List<T> list);
      dlg.DataSource = orig;
      dlg.Text = ReflectionUtils.ClassDescription(typeof(T));
      var result = dlg.ShowDialog() == DialogResult.OK;
      if (result)
      {
        Entity.DoEndEdit(_context, data, orig, list);
      }
      else
      {
        Entity.DoCancelEdit(_context);
      }
      return result;
    }

    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ExchangeDlg(), _context.Exchange);
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new SymbolDlg(), _context.Symbol);
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      Entity.DoBeginEdit<TraderSession>(_context.Session, out BindingList<TraderSession> orig, out List<TraderSession> list);

      if (EditDbSet(new TradeSessionDlg(), _context.Region))
      {
        Entity.DoEndEdit<TraderSession>(_context, _context.Session, orig, list);
      }
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TimeFrameDlg(), _context.Frame);
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ResultDlg(), _context.Result);
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TrendDlg(), _context.Trend);
    }

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new WalletDlg(), _context.Wallet);
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
