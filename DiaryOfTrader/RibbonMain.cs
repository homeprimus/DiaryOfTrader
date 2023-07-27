using System.ComponentModel;
using DevExpress.Mvvm.Native;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;
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
    readonly DiaryOfTraderCtx ctx = new DiaryOfTraderCtx();
    private Task? updateThisWeekAsync;
    public RibbonMain()
    {
      InitializeComponent();
      var eco = new EconomicParser(ctx);
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
        Entity.DoEndEdit(ctx, data, orig, list);
      }
      else
      {
        Entity.DoCancelEdit(ctx);
      }
      return result;
    }

    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ExchangeDlg(), ctx.Exchange);
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new SymbolDlg(), ctx.Symbol);
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      Entity.DoBeginEdit<TraderSession>(ctx.Session, out BindingList<TraderSession> orig, out List<TraderSession> list);

      if (EditDbSet(new TradeSessionDlg(), ctx.Region))
      {
        Entity.DoEndEdit<TraderSession>(ctx, ctx.Session, orig, list);
      }
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TimeFrameDlg(), ctx.Frame);
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new ResultDlg(), ctx.Result);
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new TrendDlg(), ctx.Trend);
    }

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      EditDbSet(new WalletDlg(), ctx.Wallet);
    }

    private void bbtCalendar_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (updateThisWeekAsync != null)
      {
        Task.WaitAll(updateThisWeekAsync);
        updateThisWeekAsync = null;
      }

      var calendar = new CalendarDlg();
      calendar.ShowDialog();
    }
  }

  public class BindingCalendar
  {
    public DateTime Time { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public string Factual { get; set; }
    public string Prognosis { get; set; }
    public string Previous { get; set; }
    public string Node { get; set; }
  }

}
