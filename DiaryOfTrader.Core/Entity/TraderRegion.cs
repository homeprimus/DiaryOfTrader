
namespace DiaryOfTrader.Core.Entity
{
  /*
   *    Торговый регион
   *    Азиатский (Asia)
   *    Европейский (Europe)
   *    Американский (America)
   *    Тихоокенский (Pacific) 
   */
  public class TraderRegion: Entity
  {
    public TraderRegion()
    {
      Sessions = new();
    }

    protected override bool GetValidate()
    {
      var result = base.GetValidate();
      if (result)
      {
        Sessions.ForEach(e => result &= e.Validate);
      }
      return result;
    }
    public List<TraderSession> Sessions { get; set; }
  }
}
