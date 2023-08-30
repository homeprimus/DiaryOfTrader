
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Consumer
{
  public class EconomicCalendarConsumerMq: Disposable, IEconomicCalendarRepository
  {
    #region
    private List<EconomicSchedule>? _events;
    private readonly object _lock = new ();
    private readonly string _queue;
    private readonly string _host;
    #endregion

    public EconomicCalendarConsumerMq(string queue, string host)
    {
      _queue = queue;
      _host = host;
    }
    public async Task<List<EventCalendar>> GetAsync(EconomicPeriod period, Importance importance)
    {
      return await Task.Run(() =>
      {
        EconomicParser.GetPeriodToDate(period, out var startDate, out var endDate);
        Monitor.Enter(_lock);
        try
        {
          var events = _events?.Where(e => e.Time >= startDate && e.Time <= endDate && e.Importance == (int)importance)
            .ToList();
          return Task.FromResult(EconomicParser.MakeEventCalendar(events));
        }
        finally
        {
          Monitor.Exit(_lock);
        }
      });
    }

    public async Task<List<EventCalendar>> GetAsync(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      return await Task.Run(() =>
      {
        Monitor.Enter(_lock);
        try
        {
          var events = _events?.Where(e => e.Time >= startDate && e.Time <= endDate && e.Importance == (int)importance)
            .ToList();
          return EconomicParser.MakeEventCalendar(events);
        }
        finally
        {
          Monitor.Exit(_lock);
        }
      });
    }

    public async Task GetMessagesAsync()
    {
      var factory = new ConnectionFactory { HostName = _host };
      using var connection = factory.CreateConnection();
      using var chanel = connection.CreateModel();
      chanel.QueueDeclare(
        queue: _queue,
        exclusive: false,
        durable: true,
        autoDelete: false,
        arguments: null);

      var consumer = new EventingBasicConsumer(chanel);
      consumer.Received += async (object? sender, BasicDeliverEventArgs e) =>
      {
        var body = e.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);

        Monitor.Enter(_lock);
        try
        {
          _events = JsonSerializer.Deserialize<List<EconomicSchedule>>(json);
        }
        finally
        {
          Monitor.Exit(_lock);
        }
      };

      chanel.BasicConsume(
        queue: _queue,
        consumer: consumer);
    }

  }
}
