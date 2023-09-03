
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Publisher
{
  public class EconomicCalendarPublisherMq: Disposable, EconomicCalendarPublisher
  {
    #region fields

    private readonly DiaryOfTraderCtx _data;
    private readonly string _host;
    private readonly string _queue;
    #endregion

    public EconomicCalendarPublisherMq(DbContext data, string user = "", string password = "", string queue = "", string host = "", int port = -1)
    {
      _queue = queue;
      _host = host;
      _data = data as DiaryOfTraderCtx;
    }

    public async Task Publish(EconomicPeriod period, Importance importance)
    {
      EconomicParser.GetPeriodToDate(period, out var startDate, out var endDate);
      await Publish(startDate, endDate, period, importance);
    }


    public async Task Publish(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      var factory = new ConnectionFactory{HostName = _host };
      using var connection = factory.CreateConnection();
      using var chanel = connection.CreateModel();
      chanel.QueueDeclare(
        queue: _queue, 
        exclusive:false, 
        durable:true, 
        autoDelete:false, 
        arguments:null);

      using var source = new CancellationTokenSource();
      var parser = new EconomicParser(_data, source.Token);
      var events = await parser.GetEconomicScheduleAsync(
        startDate, 
        endDate, 
        period, 
        importance);
      
      var json = JsonSerializer.Serialize(events);

      var body = Encoding.UTF8.GetBytes(json);
      chanel.BasicPublish(
        exchange:"",
        routingKey: _queue,
        basicProperties:null,
        body:body
        );
      return;
    }

    protected override void Free()
    {
      base.Free();
      _data.Dispose();
    }

  }
}
