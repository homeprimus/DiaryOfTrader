

namespace DiaryOfTrader.Core.Entity
{
  [DescriptionRes("Symbol")]
  public class Symbol : Entity
  {
    [JsonIgnore]
    public List<TraderExchange> Exchange { get; set; } = new List<TraderExchange>();
  }
}
