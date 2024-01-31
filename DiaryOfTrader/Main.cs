using System.Diagnostics;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Repository.RabbitMQ.Consumer;
using DiaryOfTrader.Core.Repository.RabbitMQ.Publisher;
using DiaryOfTrader.EditDialogs;

namespace DiaryOfTrader
{
  public partial class Main : BaseForm
  {
    public Main()
    {
      InitializeComponent();
    }

    private void btMain_Click(object sender, EventArgs e)
    {
      //new RibbonMain().ShowDialog();
    }

    async void print(EconomicCalendarConsumerMq consumer)
    {
      var a = await consumer.GetAsync(DateTime.Now.Date, DateTime.Now.AddDays(5).Date, EconomicPeriod.today, Importance.High);
      a.ForEach(e=> Debug.WriteLine(e.ToString()));
    }
    private async void button1_Click(object sender, EventArgs e)
    {
      //const string EconomicCalendar = "economic.calendar";
      //const string Host = "192.168.99.153";
      //var consumer = new EconomicCalendarConsumerMq(host:Host, queue:EconomicCalendar);

      //var _e = new EconomicCalendarPublisherMq(data:new DiaryOfTraderCtx(), "","", queue: EconomicCalendar, host:Host, 1);

      //await _e.Publish(DateTime.Now.Date, DateTime.Now.AddDays(28), EconomicPeriod.today, Importance.None);
      //var a = await consumer.GetAsync(DateTime.Now.Date, DateTime.Now.AddDays(5).Date, EconomicPeriod.today, Importance.High);
      //a.ForEach(e => Debug.WriteLine(e.ToString()));

      //await _e.Publish(DateTime.Now.Date, DateTime.Now.AddDays(28), EconomicPeriod.thisWeek, Importance.None);
      //a = await consumer.GetAsync(DateTime.Now.Date, DateTime.Now.AddDays(5).Date, EconomicPeriod.thisWeek, Importance.High);
      //a.ForEach(e => Debug.WriteLine(e.ToString()));

    }
  }
}
