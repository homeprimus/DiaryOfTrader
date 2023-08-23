
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using SkiaSharp;

namespace DiaryOfTrader.Core.Entity
{
  public class TraderExchange: Entity
  {
    public string? Url { get; set; }
    [JsonIgnore, NotMapped]
    public SKImage? Image { get; set; }
    public byte[]? ImageData
    {
      get
      {
        return Image?.EncodedData.ToArray();
      }
      set
      {
        if (value == null)
        {
          Image = null;
        }
        else
        {
          using var ms = new MemoryStream(value);
          Image = SKImage.FromEncodedData(ms);
        }
      }
    }

    public async void LoadImage()
    {
      await GetFavicon(Url, Image == null);
    }

    [JsonIgnore]
    public List<Symbol> Symbols { get; set; } = new List<Symbol>();

    private async Task<SKImage?> GetFavicon(string url, bool reload)
    {
      SKImage? image = null;
      if (!string.IsNullOrEmpty(url) && (Image != null || reload))
      {

        var regex = new Regex("href=\"(?<favicon>.*?(favicon).*?)\"");
        var favicons = new List<string>();

        var req = WebRequest.Create(Url) as HttpWebRequest;
        req.Method = "GET";
        req.Accept = "*/*";
        req.AllowAutoRedirect = true;
        req.AutomaticDecompression = DecompressionMethods.All;

        var resp = req.GetResponse();
        var stream = resp.GetResponseStream();
        var data = new StreamReader(stream).ReadToEnd();
        var match = regex.Match(data);
        while (match.Success)
        {
          favicons.Add(match.Result("${favicon}").Trim());
          match = match.NextMatch();
        }

        foreach (var favicon in favicons)
        {
          Console.WriteLine(favicon);
        }

        var i = 0;
        var sb = new StringBuilder();
        while (image != null && i < favicons.Count)
        {
          sb.Clear();
          sb.Append(favicons[i]);

          if (!sb.ToString().Contains("http"))
          {
            sb.Insert(0, url);
          }

          try
          {
            req = WebRequest.Create(sb.ToString()) as HttpWebRequest;
            req.Method = "GET";
            req.Accept = "*/*";
            req.AllowAutoRedirect = true;
            req.AutomaticDecompression = DecompressionMethods.All;

            resp = await req.GetResponseAsync();
            using var s = resp.GetResponseStream();
            image = SKImage.FromEncodedData(s);
          }
          catch (Exception e)
          {
            Debug.WriteLine(e);
          }
          i++;
        }

      }
      return image;
    }
  }
}
