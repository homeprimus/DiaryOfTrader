
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows;
using CefSharp;
using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace DiaryOfTrader.Components
{
  public partial class TragingView : CoreControl
  {
    private Symbol _symbol;
    private TimeFrame _frame;
    private TraderExchange _exchange;
    private byte[] _imageData;


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

    private readonly Dictionary<string, BarCheckItem> _btnHash;
    private readonly List<BarCheckItem> _lowGroup;
    public TragingView()
    {
      InitializeComponent();
      _btnHash = new()
      {
        {"1M", bci1mon},
        {"1W", bci1w},
        {"1D", bci1d},
        {"4H", bci4h},
        {"1H", bci1h},
        {"30", bci30m},
        {"15", bci15m},
        {"5", bci5m},
        {"1", bci1m},
      };
      _lowGroup = new(new[]
      {
        bci30m,
        bci15m,
        bci5m,
        bci1m
      });
    }

    public EventHandler NotifyScreenShort;

    [DefaultValue(true)]
    public bool EnabledTimeFrame
    {
      get { return bci1m.Enabled; }
      set
      {
        _btnHash.ToList().ForEach(e => e.Value.Enabled = value);
      }
    }
    [DefaultValue(true)]
    public bool LowGroup
    {
      get { return _lowGroup.All(e => e.Visibility == BarItemVisibility.Always); }
      set
      {
        _lowGroup.ForEach(e => e.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never);
      }
    }
    [DefaultValue(true)]
    public bool VisibleTimeFrame
    {
      get { return bsiTimeframe.Visibility == BarItemVisibility.Always; }
      set
      {
        var visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never;
        bsiTimeframe.Visibility = visibility;
        _btnHash.ToList().ForEach(e => e.Value.Visibility = visibility);
      }
    }

    [DefaultValue(true)]
    public bool VisibleSymbol
    {
      get { return bsiSymbol.Visibility == BarItemVisibility.Always; }
      set
      {
        var visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never;
        bsiExchange.Visibility = visibility;
        bsiSymbol.Visibility = visibility;
      }
    }
    [DefaultValue(true)]
    public bool VisibleScreenShot
    {
      get { return bbiScreeShot.Visibility == BarItemVisibility.Always; }
      set
      {
        bbiScreeShot.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; ;
      }
    }

    [DefaultValue(null)]
    public TraderExchange Exchange
    {
      get { return _exchange; }
      set
      {
        _exchange = value;
        if (_exchange != null)
        {
          bsiExchange.Caption = $"{_exchange.Name} ";
          if (_exchange.Image != null)
          {
            if (_exchange.Image is SKImage img)
            {
              bsiExchange.ImageOptions.Image = img.ToBitmap();
            }
          }
        }
      }
    }

    [DefaultValue(null)]
    public Symbol Symbol
    {
      get { return _symbol; }
      set
      {
        _symbol = value;
        if (_symbol != null)
        {
          bsiSymbol.Caption = $"{_symbol.Name}  ";
          if (_symbol.Image != null)
          {
            if (_symbol.Image is SKImage img)
            {
              bsiSymbol.ImageOptions.Image = img.ToBitmap();
            }
          }
        }
      }
    }

    [DefaultValue(null)]
    public TimeFrame Frame
    {
      get { return _frame; }
      set
      {
        _frame = value;
        if (_frame != null)
        {
          _btnHash.ToList().ForEach(e => e.Value.Checked = false);
          _btnHash[_hash[_frame.Name]].Checked = true;
          Go(_hash[_frame.Name]);
        }
      }
    }

    [DefaultValue(null)]
    public byte[] ImageData
    {
      get { return _imageData; }
      set { _imageData = value; }
    }
    public void Go(string timeframe)
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
  ""interval"": ""{timeframe}"",
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
      var simpleSound = new SoundPlayer(Properties.Resources.photoSound);
      simpleSound.Play();


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

    private void bbiScreeShot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      ImageData = ScreenShot();
      NotifyScreenShort?.Invoke(this, EventArgs.Empty);
    }

    private void bci1m_ItemClick(object sender, ItemClickEventArgs e)
    {
      var timeframe = _btnHash.ToList().FirstOrDefault(b => b.Value == e.Item).Key;
      Go(timeframe);
    }
  }
}
