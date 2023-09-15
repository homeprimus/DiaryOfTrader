using SkiaSharp;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryOfTrader.Core.Entity.Economic
{
  [Serializable]
  public class EntityPicture: Entity
  {
    #region fields
    [NonSerialized, NotPersistent]
#if WINDOWS
    private Image? _image;
#else
    private SKImage? _image;
#endif
    #endregion

#if WINDOWS
    [JsonIgnore, NotMapped]
    public System.Drawing.Image? Image
    {
      get { return _image; }
      set
      {
        _image = value; 
        OnPropertyChanged();
      }
    }

    [JsonIgnore, NotMapped]
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
        if (value == null || value.Length == 0)
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
#else
    [JsonIgnore, NotMapped]
    public SKImage? Image
    {
      get { return _image; }
      set
      {
        _image = value;
        OnPropertyChanged();
      }
    }

    [JsonIgnore]
    public virtual byte[]? ImageData
    {
      get
      {
        return (Image as SKImage)?.EncodedData.ToArray(); ;
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

#endif
  }
}
