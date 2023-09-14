using System.ComponentModel.DataAnnotations.Schema;
using SkiaSharp;

namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  [DescriptionRes("Symbol")]
  public class Symbol : Entity
  {
    [NonSerialized, NotPersistent]
    private SKImage? _image;


    [JsonIgnore, NotMapped]
    public SKImage? Image { get { return _image; } set { _image = value; } }
    public string? Url { get; set; }

    [JsonIgnore]
    public List<TraderExchange> Exchanges { get; set; } = new List<TraderExchange>();

    [JsonIgnore]
    public byte[]? ImageData
    {
      get
      {
        return Image?.EncodedData.ToArray();;
      }
      set
      {
        if (value == null || value.Length == 0)
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
