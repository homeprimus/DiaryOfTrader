
namespace DiaryOfTrader.Core.Entity 
{
  [Serializable]
  public class Trader: Entity
  {
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
  }
}
