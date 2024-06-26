﻿
using System.ComponentModel;
using DiaryOfTrader.Components;
using DiaryOfTrader.Properties;
using MessageBox = DiaryOfTrader.Core.MessageBox;

namespace DiaryOfTrader.EditControls
{
  public partial class GridNavigator : CoreControl
  {
    public delegate void Handler(object entity);
    public event Handler Add;
    public event Handler Edit;
    public event Handler Delete;

    private DevExpress.XtraGrid.Views.Grid.GridView? view;
    public GridNavigator()
    {
      InitializeComponent();
    }

    [DefaultValue(null)]
    public DevExpress.XtraGrid.Views.Grid.GridView View
    {
      get
      {
        return view;
      }
      set
      {
        view = value;
        if (view != null)
        {
          //RefreshAction();
        }
      }
    }

    private object GetEntity()
    {
      return View.GetRow(View.FocusedRowHandle);
    }
    private void RefreshAction()
    {
      var bEnabled = View.DataRowCount > 0;
      bbtEdit.Enabled = bEnabled;
      bbtRefresh.Enabled = bEnabled;
      bbtDelete.Enabled = bEnabled;
    }

    private void bbtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      View.AddNewRow();
      Add?.Invoke(GetEntity());
      RefreshAction();
    }

    private void bbEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Edit?.Invoke(GetEntity());
      RefreshAction();
    }

    private void bbtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      if (MessageBox.ShowQuestionYesNo(String.Format(Resources.DeleteRecord, GetEntity()), Resources.DeleteQuestion) == DialogResult.Yes)
      {
        Delete?.Invoke(GetEntity());
        View.DeleteRow(View.FocusedRowHandle);
        View.FocusedRowHandle = 0;
      }
      RefreshAction();
    }
  }
}
