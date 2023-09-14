
using System.Drawing.Imaging;
using System.IO;
using CefSharp;

namespace DiaryOfTrader.Components
{
  public partial class TragingView : CoreControl
  {
    private Symbol _symbol;
    private TimeFrame _frame;

    private TraderExchange _exchange;
    // 1, 3, 5, 15, 30, 1ч, 2ч, 3ч, 4ч, 1д, 1н, 1м, 3м, 6м, 12
    // 1, 2, 3,  4,  5, 6,  7,  8,  9,  10, 11, 12, 13, 14, 15  
    private static readonly Dictionary<string, string> _hash = new()
    {
      {"MN", "1M"},
      {"W1", "1W"},
      {"D1", "1D"},
      {"H4", "4H"},
      {"H1", "1H"},
      {"M30", "30"},
      {"M15", "15"},
      {"M5", "5"},
      {"M1", "1"},

    };
    public TragingView()
    {
      InitializeComponent();
    }

    public TraderExchange Exchange
    {
      get { return _exchange; }
      set { _exchange = value; }
    }
    public Symbol Symbol
    {
      get { return _symbol; }
      set { _symbol = value; }
    }
    public TimeFrame Frame
    {
      get { return _frame; }
      set { _frame = value; }
    }

    public void Go()
    {

      var html = @$"
<html>
<div class=""tradingview-widget-container"">
  <div id=""technical-analysis""></div>
  <script type=""text/javascript"" src=""https://s3.tradingview.com/tv.js""></script>
  <script type=""text/javascript"">
  new TradingView.widget(
  {{
  ""container_id"": ""technical-analysis"",
  ""width"": ""100%"",
  ""height"": ""100%"",
  ""autosize"": true,
  ""symbol"": ""{_exchange?.Name}:{_symbol?.Name}"",
  ""interval"": ""{_hash[_frame.Name]}"",
  ""timezone"": ""exchange"",
  ""theme"": ""light"",
  ""style"": ""1"",
  ""hide_top_toolbar"": true,
  ""withdateranges"": false,
  ""hide_side_toolbar"": false,
  ""allow_symbol_change"": false,
  ""save_image"": false,
  ""show_popup_button"": true,
  ""popup_width"": ""1000"",
  ""popup_height"": ""650"",
  ""locale"": ""ru""
}}
  );
  </script>
</div>
</html>";
      WebBrowser.LoadHtml(html, "https://s3.tradingview.com/");
    }

    public byte[] ScreenShot()
    {
      var deltaX = 57;
      var deltaY = 0;
      var format = ImageFormat.Jpeg;

      var rect = WebBrowser.RectangleToScreen(WebBrowser.Bounds);
      rect = new Rectangle(rect.X + deltaX, rect.Y + deltaY, rect.Width - deltaX, rect.Height - deltaY);
      var result = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
      var g = Graphics.FromImage(result);
      g.CopyFromScreen(rect.Left, rect.Top, 0, 0, result.Size, CopyPixelOperation.SourceCopy);

      using var stream = new MemoryStream();
      result.Save(stream, format);
      return stream.ToArray();
    }
  }
}
