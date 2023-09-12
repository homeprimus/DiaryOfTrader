
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

      var html = @$"
<html>
<div class=""tradingview-widget-container"">
  <div id=""technical-analysis-chart-demo""></div>
  <script type=""text/javascript"" src=""https://s3.tradingview.com/tv.js""></script>
  <script type=""text/javascript"">
  new TradingView.widget(
  {{
  ""container_id"": ""technical-analysis-chart-demo"",
  ""width"": ""100%"",
  ""height"": ""100%"",
  ""autosize"": true,
  ""symbol"": ""{Element.Market.Symbol.Name}"",
  ""interval"": ""{Element.Frame.Name}"",
  ""timezone"": ""exchange"",
  ""theme"": ""light"",
  ""style"": ""1"",
  ""withdateranges"": true,
  ""hide_side_toolbar"": false,
  ""allow_symbol_change"": true,
  ""save_image"": true,
  ""show_popup_button"": true,
  ""popup_width"": ""1000"",
  ""popup_height"": ""650"",
  ""locale"": ""ru""
}}
  );
  </script>
</div>
</html>";

      //WebBrowser.Load(@"c:\Users\private\source\repos\CoinParser\CoinParser\TradingView\tv.html");
      WebBrowser.LoadHtml(html, "https://s3.tradingview.com/");
    }
  }
}
