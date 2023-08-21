using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using SkiaSharp;

namespace DiaryOfTrader.Core.Entity
{
  [DescriptionRes("Symbol")]
  public class Symbol : Entity
  {
    public string? Url { get; set; }
    [NotMapped]
    [JsonIgnore]
    public SKImage? Image { get; set; }
    [JsonIgnore]
    public List<TraderExchange> Exchanges { get; set; } = new List<TraderExchange>();

    public byte[]? ImageData
    {
      get
      {
        return Image?.EncodedData.ToArray();;
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
  }
}
