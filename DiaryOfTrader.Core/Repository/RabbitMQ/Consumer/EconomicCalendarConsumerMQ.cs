
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Consumer
{
  public class EconomicCalendarConsumerMQ: Disposable, IEconomicCalendarRepository
  {
    public Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      throw new NotImplementedException();
    }

    public Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      throw new NotImplementedException();
    }
  }
}
