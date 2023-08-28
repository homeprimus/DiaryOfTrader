using DiaryOfTrader.Core.Entity.Economic;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class EconomicCalendar
{
  private EconomicPeriod CurrentChoice { get; set; } = EconomicPeriod.today;
}
