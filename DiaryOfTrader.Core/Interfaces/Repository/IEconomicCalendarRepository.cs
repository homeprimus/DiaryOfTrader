namespace DiaryOfTrader.Core.Interfaces.Repository
{
  public interface IEconomicCalendarRepository : IDisposable
  {
    Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance);
    Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance);
  }

  public interface EconomicCalendarPublisher : IDisposable
  {
    Task Publish(EconomicPeriod period, Importance importance);
    Task Publish(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance);
  }

}
