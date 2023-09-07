
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using DiaryOfTrader.Core.Data;
using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;
// https://github.com/rabbitmq/rabbitmq-stream-dotnet-client/blob/main/docs/Documentation/ProducerUsage.cs

namespace DiaryOfTrader.Core.Repository.RabbitMQ.Publisher
{
  public class EconomicCalendarStreamPublisherMQ: Disposable, EconomicCalendarPublisher
  {
    #region fields

    private readonly DiaryOfTraderCtx _data;
    private StreamSystem _streamSystem;
    private Producer _producer;
    #endregion

    public EconomicCalendarStreamPublisherMQ(DbContext data, string user = "", string password = "", string queue = "", string host = "", int port = 5552)
    {
      _data = data as DiaryOfTraderCtx;
      Create(user, password, queue, host, port).Wait();
    }
    private async Task Create(string user, string password, string queue, string host, int port)
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

      _producer = await global::RabbitMQ.Stream.Client.Reliable.Producer.Create(
        new ProducerConfig(
          _streamSystem,
          queue)
        {
          ConfirmationHandler = async confirmation => // <5>
          {
            switch (confirmation.Status)
            {
              case ConfirmationStatus.Confirmed:
                Debug.WriteLine("Message confirmed");
                break;
              case ConfirmationStatus.ClientTimeoutError:
              case ConfirmationStatus.StreamNotAvailable:
              case ConfirmationStatus.InternalError:
              case ConfirmationStatus.AccessRefused:
              case ConfirmationStatus.PreconditionFailed:
              case ConfirmationStatus.PublisherDoesNotExist:
              case ConfirmationStatus.UndefinedError:
                Debug.WriteLine("Message not confirmed with error: {0}", confirmation.Status);
                break;

              default:
                throw new ArgumentOutOfRangeException();
            }


            await Task.CompletedTask.ConfigureAwait(false);
          }
        }
      ).ConfigureAwait(false);

    }
    protected override void Free()
    {
      base.Free();
      _producer.Close().Wait();// ConfigureAwait(false);
      _streamSystem.Close().Wait();// ConfigureAwait(false);
    }


    public async Task Publish(EconomicPeriod period, Importance importance)
    {
      EconomicParser.GetPeriodToDate(period, out var startDate, out var endDate);
      await Publish(startDate, endDate, period, importance);
    }

    public async Task Publish(DateTime startDate, DateTime endDate, EconomicPeriod period, Importance importance)
    {
      using var source = new CancellationTokenSource();
      var parser = new EconomicParser(_data, source.Token);
      var events = await parser.GetEconomicScheduleAsync(
        startDate,
        endDate,
        period,
        importance);

      var json = JsonSerializer.Serialize(events);

      var body = Encoding.UTF8.GetBytes(json);
      var message = new Message(body);
      await _producer.Send(message).ConfigureAwait(false); 
    }
  }
}
