﻿
using CefSharp;
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
      BindingUtils.Bind(txtExchange, BindingUtils.Text, Element.Market, "Exchange");
      BindingUtils.Bind(txtCoin, BindingUtils.Text, Element.Market, "Symbol");
      BindingUtils.BindCombo(lcbTimeFrame, Element, "Frame", MarketReview.FrameList);
      BindingUtils.BindCombo(lcbTrend, Element, "Trend", MarketReview.TrendList);
      BindingUtils.Bind(mmDescription, BindingUtils.Text, Element, "Description");

      tragingView.Symbol = Element.Market.Symbol;
      tragingView.Exchange = Element.Market.Exchange;
      OnPropertyChanged("Frame");
    }

    protected override void OnPropertyChanged(string property)
    {
      base.OnPropertyChanged(property);
      if (property == "Frame")
      {
        tragingView.Frame = Element.Frame;
        tragingView.Go();
      }
    }

    private void btScreenShot_Click(object sender, EventArgs e)
    {
      Element.ScreenShot.ImageData = tragingView.ScreenShot();
    }
  }
}
