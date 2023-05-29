using System.ComponentModel;
using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Dictionary;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DiaryOfTrader
{
  public partial class RibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    readonly DiaryOfTraderCtx ctx = new DiaryOfTraderCtx();

    public RibbonMain()
    {
      InitializeComponent();
    }

    private void UpdateDbSet<T>(GridEditDialog dlg, DbSet<T> data) where T : Entity
    {
      var orig = new BindingList<T>(data.ToList());
      var list = new List<T>(orig);
      dlg.DataSource = orig;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        orig.Where(e => !list.Contains(e)).ForEach(e => data.Add(e));
        list.Where(e => !orig.Contains(e)).ForEach(e => data.Remove(e));

        ctx.SaveChanges();
      }

    }
    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new ExchangeDlg(), ctx.Exchange);
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new SymbolDlg(), ctx.Symbol);
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new TradeSessionDlg(), ctx.Session);
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new TimeFrameDlg(), ctx.Frame);
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new ResultDlg(), ctx.Result);
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new TrendDlg(), ctx.Trend);
    }
  }
}
