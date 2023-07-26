using System.ComponentModel;
using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Utils;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader
{
  public partial class RibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    readonly DiaryOfTraderCtx ctx = new DiaryOfTraderCtx();

    public RibbonMain()
    {
      InitializeComponent();
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
  }
}
