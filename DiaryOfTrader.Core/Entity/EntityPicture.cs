using System.ComponentModel.DataAnnotations.Schema;
using SkiaSharp;

namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  public class EntityPicture: Entity
  {
    #region fields

    private byte[]? _imageData;
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
      get
      {
        if (_imageData == null)
        {
          return null;
        }
        using var ms = new MemoryStream(_imageData);
        return SKImage.FromEncodedData(ms);
      }
      set
      {
        _imageData = value?.EncodedData.ToArray(); 
        OnPropertyChanged();
      }
    }

    [JsonIgnore]
    public virtual byte[]? ImageData
    {
      get
      {
        return _imageData;
      }
      set
      {
        _imageData = value;
        OnPropertyChanged();
      }
    }

#endif
  }
}
