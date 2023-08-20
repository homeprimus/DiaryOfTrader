
namespace DiaryOfTrader.Core.Entity
{
  public class ScreenShot : Entity
  {
    [JsonIgnore]
    public object Image { get; }
    public string Path { get; set; }
  }

}
