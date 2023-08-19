
namespace DiaryOfTrader.Core.Entity
{
  public class TraderExchange: Entity
  {
    [JsonIgnore]
    public List<Symbol> Symbol { get; set; } = new List<Symbol>();
  }
}
