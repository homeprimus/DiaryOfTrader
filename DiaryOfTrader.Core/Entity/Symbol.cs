
namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  [DescriptionRes("Symbol")]
  public class Symbol : EntityPicture
  {
    public string? Url { get; set; }
    [JsonIgnore]
    public List<TraderExchange> Exchanges { get; set; } = new List<TraderExchange>();
  }
}
