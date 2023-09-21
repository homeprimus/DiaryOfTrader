using System.ComponentModel;
using DiaryOfTrader.Core;
using DiaryOfTrader.Core.Interfaces;
using DiaryOfTrader.EditDialogs;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewCtrl : MarketReviewCtrlAbstract
  {
    public MarketReviewCtrl()
    {
      InitializeComponent();

      gnReview.View = gvTimeFrame;
      gnReview.Add += delegate (object entity)
      {
        var frame = (MarketReviewTimeFrame)entity;
        Element.SetFrame(frame);

        var edit = new MarketReviewTimeFrameDlg();
        edit.Edit(frame, EditModeUI.AllowEdit);
        gvTimeFrame.RefreshData();
      };

      gnReview.Edit += delegate (object entity)
      {
        var frame = (MarketReviewTimeFrame)entity;

        var edit = new MarketReviewTimeFrameDlg();
        edit.Edit(frame, EditModeUI.AllowEdit);
        gvTimeFrame.RefreshData();
      };

      gnReview.Delete += delegate (object entity)
      {
        gvTimeFrame.RefreshData();
      };

    }
    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      BindingUtils.Bind(dateEdit, "DateTime", Element, "DateTime");

      BindingUtils.BindCombo(lcbExchange, Element, "Exchange", MarketReview.ExchangeList);
      BindingUtils.BindCombo(lcbSymbol, Element, "Symbol", MarketReview.SymbolList);

      BindingUtils.Bind(txtName, BindingUtils.Text, Element, "Name");
      BindingUtils.Bind(mmDescription, BindingUtils.Text, Element, "Description");

      gcTimeFrame.DataSource = new BindingList<MarketReviewTimeFrame>(Element.Frames); ;

      luFrame.DataSource = MarketReview.FrameList;
      luTrend.DataSource = MarketReview.TrendList;
    }

    protected override void OnPropertyChanged(string property)
    {
      base.OnPropertyChanged(property);
      if (property == "Exchange" || property == "Symbol" || property == "DateTime")
      {
        BindingUtils.SafeReadValue(txtName, BindingUtils.Text);
      }
    }

    private void repositoryItemPictureEdit_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
    {
      if (e.Value is SKImage img)
      {
        e.Value = img.ToBitmap();
        e.Handled = true;
      }
    }

    private void repositoryItemPictureEdit_DoubleClick(object sender, EventArgs e)
    {
      var entity = (MarketReviewTimeFrame)gvTimeFrame.GetRow(gvTimeFrame.FocusedRowHandle);
      if (entity?.ScreenShot?.Image is SKImage img)
      {
        var pictureEditDlg = new PictureEditDlg();
        pictureEditDlg.Image = img.ToBitmap();
        if (pictureEditDlg.ShowDialog() == DialogResult.OK)
        {
          entity.ScreenShot.Image = ((Bitmap)pictureEditDlg.Image)?.ToSKImage();
          gvTimeFrame.RefreshData();
        }
      }
    }

  }
}
