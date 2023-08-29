
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Publisher
{
  public class EconomicCalendarPublisherMq
  {
    #region fields

    private readonly string _host;
    private readonly string _queue;
    #endregion

    public EconomicCalendarPublisherMq(string host, string queue)
    {
      _queue = queue;
      _host = host;
    }
    public async Task Create()
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
      var parser = new EconomicParser(null, source.Token);
      var events = await parser.GetEconomicScheduleAsync(
        DateTime.Now.Date, 
        DateTime.Now.AddDays(1).Date, 
        EconomicPeriod.custom, 
        Importance.None);
      
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
  }
}
