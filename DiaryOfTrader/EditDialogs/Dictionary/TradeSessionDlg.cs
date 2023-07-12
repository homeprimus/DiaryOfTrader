
using System.ComponentModel;
using System.Windows.Controls;
using DevExpress.Xpo;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.EditControls;

namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TradeSessionDlg : GridEditDialog
  {
    public TradeSessionDlg()
    {
      InitializeComponent();
      grid.gridView.FocusedRowChanged += FocusedRowChanged;
      gnSession.View = gvSession;
    }

    private void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      var reg = TraderRegion;
      if (reg != null)
      {
        var orig = new BindingList<TraderSession>(reg.Sessions.OrderBy(e => e.Order).ToList());
        gridSession.DataSource = orig;
      }
      else
      {
        gridSession.DataSource = null;
      }
    }

    private TraderRegion? TraderRegion
    {
      get
      {
        if (grid.gridView.FocusedRowHandle > -1)
          return (TraderRegion)grid.gridView.GetRow(grid.gridView.FocusedRowHandle);
        return null;
      }
    }
  }
}
