

using System.ComponentModel;
using DiaryOfTrader.Components;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.Properties;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using MessageBox = DiaryOfTrader.Core.MessageBox;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewGrid : CoreControl
  {
    public MarketReviewGrid()
    {
      InitializeComponent();
      MasterDetail = true;
    }

    private bool MasterDetail
    {
      get { return gvMarketReview.OptionsDetail.EnableMasterViewMode; }
      set
      {
        gvMarketReview.OptionsDetail.EnableMasterViewMode = value;
        gvMarketReview.OptionsView.ShowChildrenInGroupPanel = value;
      }
    }

    public TraderExchange Exchange { get; set; }
    public Symbol Symbol { get; set; }

    private DevExpress.XtraGrid.Views.Grid.GridView View
    {
      get
      {
        return gvMarketReview;
      }
    }

    private MarketReview GetEntity()
    {
      return (MarketReview)View.GetRow(View.FocusedRowHandle);
    }

    private void RefreshAction()
    {
      var bEnabled = View.DataRowCount > 0;
      bbtEdit.Enabled = bEnabled;
      bbtRefresh.Enabled = bEnabled;
      bbtDelete.Enabled = bEnabled;

      bbtAdd.Enabled = true;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      RefreshData();
    }

    private void RefreshData()
    {
      var data = Core.Entity.DiaryOfTrader.MarketReviewRepository.GetAllAsync().Result;
      gcMarketReview.DataSource = new BindingList<MarketReview>(data!);

    }

    private void bbtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      View.AddNewRow();
      var marketReview = new MarketReviewDlg();
      var review = GetEntity();
      review.Exchange = Exchange;
      review.Symbol = Symbol;
      if (marketReview.Edit(review))
      {
        Core.Entity.DiaryOfTrader.MarketReviewRepository.InsertAsync(review);
      }

      RefreshAction();
    }

    private void bbEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      var review = GetEntity();
      var marketReview = new MarketReviewDlg();
      if (marketReview.Edit(review))
      {
        Core.Entity.DiaryOfTrader.MarketReviewRepository.UpdateAsync(review);
      }

      RefreshAction();
    }

    private void bbtRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      RefreshData();
      RefreshAction();
    }

    private void bbtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      var review = GetEntity();
      if (MessageBox.ShowQuestionYesNo(String.Format(Resources.DeleteRecord, review), Resources.DeleteQuestion) ==
          DialogResult.Yes)
      {
        Core.Entity.DiaryOfTrader.MarketReviewRepository.DeleteAsync(review.ID);

        View.DeleteRow(View.FocusedRowHandle);
        View.FocusedRowHandle = 0;
        RefreshAction();
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
  }
}
