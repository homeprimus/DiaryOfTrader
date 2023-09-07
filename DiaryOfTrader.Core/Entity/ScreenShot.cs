
namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  public class ScreenShot : Entity
  {
    [JsonIgnore]
    
    public object Image { get; }
    public string Path { get; set; }
  }

}
