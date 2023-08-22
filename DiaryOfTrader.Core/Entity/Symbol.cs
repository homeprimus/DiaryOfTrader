using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;

namespace DiaryOfTrader.Core.Entity
{
  [DescriptionRes("Symbol")]
  public class Symbol : Entity
  {
    public string? Url { get; set; }
    [JsonIgnore, NotMapped]
    public Image? Image { get; set; }
    [JsonIgnore]
    public List<TraderExchange> Exchanges { get; set; } = new List<TraderExchange>();

    [JsonIgnore]
    public byte[]? ImageData
    {
      get
      {
        return null;
        using var ms = new MemoryStream();
        Image?.Save(ms, Image.RawFormat);
        return ms.ToArray();
      }
      set
      {
        if (value == null || value.Length == 0)
        {
          Image = null;
        }
        else
        {
          try
          {
            using var ms = new MemoryStream(value);
            Image = Image.FromStream(ms);
          }
          catch (Exception e)
          {
            Debug.WriteLine(e);
          }
        }
      }
    }
  }
}
