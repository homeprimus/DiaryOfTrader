
namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  public class TraderExchange : EntityPicture
  {
    public string? Url { get; set; }
    [JsonIgnore] 
    public List<Symbol> Symbols { get; set; } = new List<Symbol>();
  }
}
