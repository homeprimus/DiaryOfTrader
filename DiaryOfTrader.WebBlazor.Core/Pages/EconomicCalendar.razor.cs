using DiaryOfTrader.Core.Entity.Economic;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class EconomicCalendar
{
  private EconomicPeriod Period { get; set; } = EconomicPeriod.today;
  public List<EventCalendar>? EconomicCalendars { get; set; }
  
  [Inject]
  public IEconomicCalendarRepository ApiRepo { get; set; }
  
  protected override async Task OnInitializedAsync()
  {
     EconomicCalendars = await ApiRepo.GetAsync(Period, Importance.None);
  }
  
  protected async Task OnPeriodChanged(EconomicPeriod period)
  {
    Period = period;
    EconomicCalendars = await ApiRepo.GetAsync(Period, Importance.None);
  }
}
