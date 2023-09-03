using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Consumer
{
  public class EconomicCalendarStreamConsumerMQ : EconomicCalendarConsumer
  {

    private StreamSystem _streamSystem;
    private global::RabbitMQ.Stream.Client.Reliable.Consumer _consumer;

    public EconomicCalendarStreamConsumerMQ(string user, string password, string queue, string host, int port) : base(user, password, queue, host, port)
    {
      Create(user, password, queue, host, port).Wait();
    }

    private async Task Create(string user, string password, string queue, string host, int port = 5552)
    {
      _streamSystem = await StreamSystem.Create(
        new StreamSystemConfig
        {
          UserName = user,
          Password = password,
          //Ssl = new SslOption()
          //{
          //  Enabled = true,
          //  AcceptablePolicyErrors = SslPolicyErrors.RemoteCertificateNotAvailable | 
          //                           SslPolicyErrors.RemoteCertificateChainErrors |
          //                           SslPolicyErrors.RemoteCertificateNameMismatch
          //},
          Endpoints = new List<EndPoint> { new IPEndPoint(IPAddress.Parse(host), port) }
        }
      ).ConfigureAwait(false);

      _consumer = await global::RabbitMQ.Stream.Client.Reliable.Consumer.Create(
        new ConsumerConfig(
          _streamSystem,
          queue)
        {
          OffsetSpec = new OffsetTypeLast(),
          MessageHandler = async (stream, consumer, context, message) =>
          {
            var json = Encoding.UTF8.GetString(message.Data.Contents);

            Monitor.Enter(Locker);
            try
            {
              _events = JsonSerializer.Deserialize<List<EconomicSchedule>>(json);
            }
            finally
            {
              Monitor.Exit(Locker);
            }

            await consumer.StoreOffset(context.Offset).ConfigureAwait(false);
            await Task.CompletedTask.ConfigureAwait(false);
          }
        }
      ).ConfigureAwait(false);

    }
    protected override void Free()
    {
      base.Free();
      _consumer.Close().Wait();// ConfigureAwait(false);
      _streamSystem.Close().Wait();// ConfigureAwait(false);
    }

  }
}
