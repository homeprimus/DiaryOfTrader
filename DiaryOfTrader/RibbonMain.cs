using System.ComponentModel;
using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Entity.Economic;
using DiaryOfTrader.Core.Utils;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Calendar;
using DiaryOfTrader.EditDialogs.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader
{
  public partial class RibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    private readonly CancellationTokenSource cancelTokenSource = new();
    private readonly DiaryOfTraderCtx contexDb = new();

    private Task? updateThisWeekAsync;
    public RibbonMain()
    {
      InitializeComponent();
      var eco = new EconomicParser(contexDb, cancelTokenSource.Token);
      updateThisWeekAsync = eco.UpdateThisWeekAsync();
    }

    private bool EditDbSet<T>(GridEditDialog dlg, DbSet<T> data) where T : Entity
    {
      Entity.DoBeginEdit(data, out BindingList<T> orig, out List<T> list);
      dlg.DataSource = orig;
      dlg.Text = ReflectionUtils.ClassDescription(typeof(T));
      var result = dlg.ShowDialog() == DialogResult.OK;
      if (result)
      {
        Entity.DoEndEdit(contexDb, data, orig, list);
      }
      else
      {
        Entity.DoCancelEdit(contexDb);
      }
      return result;
    }

    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ExchangeDlg(), contexDb.Exchange);
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new SymbolDlg(), contexDb.Symbol);
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      Entity.DoBeginEdit<TraderSession>(contexDb.Session, out BindingList<TraderSession> orig, out List<TraderSession> list);

      if (EditDbSet(new TradeSessionDlg(), contexDb.Region))
      {
        Entity.DoEndEdit<TraderSession>(contexDb, contexDb.Session, orig, list);
      }
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TimeFrameDlg(), contexDb.Frame);
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ResultDlg(), contexDb.Result);
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TrendDlg(), contexDb.Trend);
    }

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new WalletDlg(), contexDb.Wallet);
    }

    private void bbtCalendar_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (updateThisWeekAsync != null)
      {
        Task.WaitAll(updateThisWeekAsync);
        updateThisWeekAsync = null;
      }

      var calendar = new CalendarDlg();
      calendar.Text = e.Item.Caption;
      calendar.Contex = contexDb;
      calendar.ShowDialog();
    }

    private void bbiMarketReview_ItemClick(object sender, ItemClickEventArgs e)
    {
      var marketReview = new MarketReviewDlg();
      marketReview.Element = new MarketReview();
      marketReview.Text = marketReview.Element.ClassDescription;
      marketReview.Edit();

    }
  }

}
