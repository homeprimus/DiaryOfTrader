
using System.ComponentModel.DataAnnotations;
using System.Text;
using RabbitMQ.Client;
using DiaryOfTrader.Core.Entity.Economic;
using System.Text.Json;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Publisher
{
  public class EconomicCalendarPublisherMQ
  {
    public async Task Create()
    {
      var factory = new ConnectionFactory(){HostName = "192.168.99.156" };
      using var connection = factory.CreateConnection();
      using var chanel = connection.CreateModel();
      chanel.QueueDeclare(
        queue: "economic.calendar", 
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
        routingKey: "economic.calendar",
        basicProperties:null,
        body:body
        );
      return;
    }
  }
}
