using DiaryOfTrader.Core.Entity.Economic;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class EconomicCalendar
{
  private EconomicPeriod Period { get; set; } = EconomicPeriod.today;
  public List<EconomicSchedule>? EconomicSchedules { get; set; }
  
  [Inject]
  public IEconomicCalendarRepository ApiRepo { get; set; }
  
  protected override async Task OnInitializedAsync()
  {
    // EconomicSchedules = await ApiRepo.GetAsync(Period, Importance.None);
  }
}
