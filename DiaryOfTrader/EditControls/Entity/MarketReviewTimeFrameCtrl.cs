using DiaryOfTrader.Core;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewTimeFrameCtrl : MarketReviewTimeFrameCtrlAbstract
  {
    public MarketReviewTimeFrameCtrl()
    {
      InitializeComponent();
    }

    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      BindingUtils.BindCombo(lcbTimeFrame, Element, "Frame", MarketReview.FrameList);
      BindingUtils.BindCombo(lcbTrend, Element, "Trend", MarketReview.TrendList);
      BindingUtils.Bind(mmDescription, BindingUtils.Text, Element, "Description");

      tragingView.Symbol = Element.Market.Symbol;
      tragingView.Exchange = Element.Market.Exchange;
      tragingView.NotifyScreenShort += ScreenShotClick;
      OnPropertyChanged("Frame");
    }

    protected override void OnPropertyChanged(string property)
    {
      base.OnPropertyChanged(property);
      if (property == "Frame")
      {
        tragingView.Frame = Element.Frame;
      }
    }

    private void ScreenShotClick(object sender, EventArgs e)
    {
      Element.ScreenShot.ImageData = tragingView.ImageData;
    }
  }
}
