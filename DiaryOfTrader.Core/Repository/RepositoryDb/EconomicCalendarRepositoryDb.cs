using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class EconomicCalendarRepositoryDb: Disposable, IEconomicCalendarRepository
  {
    #region fields
    private readonly DiaryOfTraderCtx _data;
    #endregion

    public EconomicCalendarRepositoryDb(DbContext data)
    {
      _data = data as DiaryOfTraderCtx;
    }

    private List<EventCalendar> MakeEventCalendar(List<EconomicSchedule> events)
    {
      return events
        .Join(
          EconomicSchedule.Importances,
          e => e.Importance,
          i => (int)i.Key,
          (e, i)
            => new EventCalendar()
            {
              Date = e.Time,
              Time = e.Time.ToString("HH:mm"),
              Currency = e.Currency,
              Importance = i.Value,
              Description = e.Description,
              Factual = e.Factual,
              Prognosis = e.Prognosis,
              Previous = e.Previous,
              Node = e.Event?.Description!
            }
        ).ToList();
    }
    public async Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      using var source = new CancellationTokenSource();
      var parser = new EconomicParser(_data, source.Token);
      var economic = await parser.ParseAsync(false, period, importance);
      return MakeEventCalendar(economic);
    }

    public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      using var source = new CancellationTokenSource();
      var parser = new EconomicParser(_data, source.Token);
      var economic = await parser.ParseAsync(startDate, endDate, period, importance, false);
      return MakeEventCalendar(economic);
    }
    protected override void Free()
    {
      base.Free();
      _data.Dispose();
    }

  }
}
