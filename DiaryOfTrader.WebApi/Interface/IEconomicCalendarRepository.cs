using DiaryOfTrader.Core.Entity.Economic;

namespace DiaryOfTrader.WebApi.Interface
{
  public interface IEconomicCalendarRepository : IDisposable
  {
    Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance);
    Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance);
  }
}
