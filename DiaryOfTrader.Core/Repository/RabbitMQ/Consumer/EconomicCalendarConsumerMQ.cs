
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Consumer
{
  public class EconomicCalendarConsumerMq: EconomicCalendarConsumer
  {
    #region
    private IModel _chanel;
    private IConnection _connection;
    #endregion
    public EconomicCalendarConsumerMq(string user = "", string password = "", string queue = "", string host = "", int port = -1) 
      : base(user, password, queue, host, port)
    {
      RegisterConsumer(user, password, queue, host, port);
    }

    public void RegisterConsumer(string user, string password, string queue, string host, int port)
    {
      var factory = new ConnectionFactory { HostName = host };
      _connection = factory.CreateConnection();
      _chanel = _connection.CreateModel();
      _chanel.QueueDeclare(
        queue: queue,
        exclusive: false,
        durable: true,
        autoDelete: false,
        arguments: null);

      var consumer = new EventingBasicConsumer(_chanel);
      consumer.Received += async (object? sender, BasicDeliverEventArgs e) =>
      {
        var body = e.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);

        Monitor.Enter(Locker);
        try
        {
          _events = JsonSerializer.Deserialize<List<EconomicSchedule>>(json);
        }
        finally
        {
          Monitor.Exit(Locker);
        }
      };

      _chanel.BasicConsume(
        queue: queue,
        consumer: consumer);
    }

    protected override void Free()
    {
      base.Free();
      _chanel.Dispose();
      _connection.Dispose();
    }

  }
}
