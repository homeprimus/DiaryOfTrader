﻿using DiaryOfTrader.Core.Data;
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
      new RibbonMain().ShowDialog();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      var _e = new EconomicCalendarPublisherMq(new DiaryOfTraderCtx(),"192.168.99.153", "economic.calendar");
      await _e.Create(DateTime.Now.Date, DateTime.Now.AddDays(28), EconomicPeriod.thisWeek, Importance.None);
    }
  }
}
