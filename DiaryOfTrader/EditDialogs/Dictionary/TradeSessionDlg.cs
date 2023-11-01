
using System.ComponentModel;

namespace DiaryOfTrader.EditDialogs.Dictionary
{
  public partial class TradeSessionDlg : GridEditDialogGeneric<TraderRegion>
  {
    public TradeSessionDlg(IRepository<TraderRegion> repository, ILogger<GridEditDialogGeneric<TraderRegion>> logger) : base(repository, logger)
    {
      InitializeComponent();
      grid.gridView.FocusedRowChanged += FocusedRowChanged;
      gnSession.View = gvSession;
      gnSession.Add += delegate (object entity)
      {
        var region = (TraderRegion)grid.gridView.GetRow(grid.gridView.FocusedRowHandle);
        ((TraderSession)entity).Region = region;
        region.Sessions.Add((TraderSession)entity);
      };
      gnSession.Delete += delegate (object entity)
      {
        var region = (TraderRegion)grid.gridView.GetRow(grid.gridView.FocusedRowHandle);
        region.Sessions.Remove((TraderSession)entity);
      };

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
