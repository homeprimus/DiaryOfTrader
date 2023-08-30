
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Publisher
{
  public class EconomicCalendarPublisherMq: Disposable
  {
    #region fields

    private readonly DiaryOfTraderCtx _data;
    private readonly string _host;
    private readonly string _queue;
    #endregion

    public EconomicCalendarPublisherMq(DbContext data, string host, string queue)
    {
      _queue = queue;
      _host = host;
      _data = data as DiaryOfTraderCtx;
    }
    public async Task Create(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
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
