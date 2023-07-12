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

    private void UpdateDbSet<T>(GridEditDialog dlg, DbSet<T> data, List<T>? readAlredy = null) where T : Entity
    {

      BindingList<T> orig;
      if (readAlredy != null)
      {
        orig = new(readAlredy);
      }
      else
      {
        orig = new(data.OrderBy(e => e.Order).ToList());
      }

      var list = new List<T>(orig);
      dlg.DataSource = orig;
      dlg.Text = ReflectionUtils.ClassDescription(typeof(T));
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        orig.Where(e => !list.Contains(e) && e.Validate).ForEach(e => data.Add(e));
        list.Where(e => !orig.Contains(e)).ForEach(e => data.Remove(e));
        try
        {
          ctx.SaveChanges();
        }
        catch(Exception ex) 
        {
          var s = ex.ToString();
          if (ex.InnerException != null)
          {
            s = ex.InnerException.ToString();
          }
          DiaryOfTrader.Core.MessageBox.ShowError(s, "");
        }
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
      var data = ctx.Region.Include(e => e.Sessions).ToList();
      UpdateDbSet(new TradeSessionDlg(), ctx.Region, data);
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

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      UpdateDbSet(new WalletDlg(), ctx.Wallet);
    }
  }
}
