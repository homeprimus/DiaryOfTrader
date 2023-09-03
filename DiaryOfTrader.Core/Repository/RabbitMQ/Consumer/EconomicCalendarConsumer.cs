
namespace DiaryOfTrader.Core.Repository.RabbitMQ.Consumer
{
  public class EconomicCalendarConsumer : Disposable, IEconomicCalendarRepository
  {
    #region
    protected List<EconomicSchedule>? _events;
    protected readonly object Locker = new();
    #endregion

    public EconomicCalendarConsumer(string user = "", string password = "", string queue = "", string host = "", int port = -1)
    {
    }
    public async Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      EconomicParser.GetPeriodToDate(period, out var startDate, out var endDate);
      return await GetAsync(startDate, endDate, period, importance);
    }

    public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      return await Task.Run(() =>
      {
        Monitor.Enter(Locker);
        try
        {
          var events = _events?
            .Where(e => e.Time >= startDate && e.Time <= endDate && e.Importance == (int)importance)
            .ToList();
          return EconomicParser.MakeEventCalendar(events);
        }
        finally
        {
          Monitor.Exit(Locker);
        }
      });
    }
  }
}
