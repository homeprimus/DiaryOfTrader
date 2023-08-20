using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace DiaryOfTrader.Core.Entity
{
  [DescriptionRes("Symbol")]
  public class Symbol : Entity
  {
    public string? Url { get; set; }
    [NotMapped]
    public Image? Image { get; set; }
    [JsonIgnore]
    public List<TraderExchange> Exchanges { get; set; } = new List<TraderExchange>();

    public byte[]? ImageData
    {
      get
      {
        using var ms = new MemoryStream();
        Image?.Save(ms, Image.RawFormat);
        return ms.ToArray();
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
          Image = Image.FromStream(ms);
        }
      }
    }
  }
}
