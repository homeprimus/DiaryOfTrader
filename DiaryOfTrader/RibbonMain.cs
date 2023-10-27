﻿using DevExpress.XtraBars;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.EditDialogs;
using DiaryOfTrader.EditDialogs.Calendar;
using DiaryOfTrader.EditDialogs.Dictionary;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryOfTrader
{
  public partial class RibbonMain : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    #region fields
    private readonly CancellationTokenSource _cancelTokenSource;
    private readonly DiaryOfTraderCtx _context;// = new();
    private Task? _updateThisWeekAsync;

    #endregion

    public RibbonMain()
    {
      InitializeComponent();

      _cancelTokenSource = new CancellationTokenSource();
      _context = new DiaryOfTraderCtx();

      var eco = new EconomicParser(_context, _cancelTokenSource.Token);
      _updateThisWeekAsync = eco.UpdateThisWeekAsync();

    }
    private void bbtExchamge_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<ExchangeDlg>().ShowDialog();
    }

    private void bbtSymbol_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<SymbolDlg>().ShowDialog();
    }

    private void bbtSession_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<TradeSessionDlg>().ShowDialog();
    }

    private void bbtTimeFrame_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<TimeFrameDlg>().ShowDialog();
    }

    private void bbtResult_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<ResultDlg>().ShowDialog();
    }

    private void bbtTrend_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<TrendDlg>().ShowDialog();
    }

    private void bbtWallet_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<WalletDlg>().ShowDialog();
    }
    private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
    {
      Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<TradingStrategyDlg>().ShowDialog();
    }

    private void bbtCalendar_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (_updateThisWeekAsync != null)
      {
        Task.WaitAll(_updateThisWeekAsync);
        _updateThisWeekAsync = null;
      }

      var calendar = new CalendarDlg();
      calendar.Text = e.Item.Caption;
      calendar.Contex = _context;
      calendar.ShowDialog();
    }

    private void bbiMarketReview_ItemClick(object sender, ItemClickEventArgs e)
    {
      tcMain.SelectedTabPage = tpMarketReview;
    }

    private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
    {
      tcMain.SelectedTabPage = tpDiary;
    }

    private void bbtMarket_ItemClick(object sender, ItemClickEventArgs e)
    {
      tcMain.SelectedTabPage = tpMarket;
    }
  }

}
