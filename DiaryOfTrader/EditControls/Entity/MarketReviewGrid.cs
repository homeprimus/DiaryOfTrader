

using DiaryOfTrader.Components;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewGrid : CoreControl
  {
    public MarketReviewGrid()
    {
      InitializeComponent();
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
  }
}
