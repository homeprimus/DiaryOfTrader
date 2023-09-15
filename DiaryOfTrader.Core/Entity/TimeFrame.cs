
namespace DiaryOfTrader.Core.Entity
{
  /*
   Таймфрейм
   */
  [Serializable]
  public class TimeFrame : Entity
  {
    public override string ToString()
    {
      return $"[{Name}] {Description}";
    }
  }

}
