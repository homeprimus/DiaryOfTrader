
using System.ComponentModel;
using DiaryOfTrader.Components;
using DiaryOfTrader.Core;
using DiaryOfTrader.Properties;

namespace DiaryOfTrader.EditControls
{
  public partial class GridNavigator : CoreControl
  {
    public GridNavigator()
    {
      InitializeComponent();
    }

    public DevExpress.XtraGrid.Views.Grid.GridView View { get; set; }
    private void bbtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      View.AddNewRow();
    }

    private void bbEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
    }

    private void bbtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      if (MsgBox.ShowQuestionYesNo(String.Format(Resources.DeleteRecord, ""), Resources.DeleteQuestion) == DialogResult.Yes)
      {
        View.DeleteRow(View.FocusedRowHandle);
      }
    }
  }
}
