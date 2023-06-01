
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryOfTrader.Core.Data
{
  internal class DataInitializer
  {
    private DiaryOfTraderCtx ctx;

    DataInitializer(DiaryOfTraderCtx ctx)
    {
      this.ctx = ctx;
    }
    #region Symbol
    private void PostSymbolConfigure()
    {
      ctx.Symbol.AddRange(
        new Symbol[]
        {
          new Symbol { ID=1, Name=Resources.SymbolDXY, Description=Resources.SymbolDXYDesc},
          new Symbol { ID=2, Name=Resources.SymbolEURUSD, Description=Resources.SymbolEURUSDDesc},
          new Symbol { ID=3, Name=Resources.SymbolUSDJPY, Description=Resources.SymbolUSDJPYDesc},

          new Symbol { ID=4, Name=Resources.SymbolSPX, Description=Resources.SymbolSPXDesc},

          new Symbol { ID=5, Name=Resources.SymbolBTCUSD, Description=Resources.SymbolBTCUSDDesc},
          new Symbol { ID=6, Name=Resources.SymbolETHUSD, Description=Resources.SymbolETHUSDDesc},
          new Symbol { ID=7, Name=Resources.SymbolBNBUSD, Description=Resources.SymbolBNBUSDDesc},
          new Symbol { ID=7, Name=Resources.SymbolBNBUSD, Description=Resources.SymbolBNBUSDDesc},
        });
    }
    #endregion
    #region Wallet
    private void PostWalletConfigure()
    {
      ctx.Wallet.AddRange(
        new Wallet[]
        {
          new Wallet { ID=1, Name=Resources.WalletReal, Description=Resources.WalletRealDesc, Order = 10},
          new Wallet { ID=2, Name=Resources.WalletDemo, Description = Resources.WalletDemoDesc, Order = 20},
          new Wallet { ID=3, Name=Resources.WalletMarketSimulator, Description = Resources.WalletMarketSimulatorDesc, Order = 30},
        });
    }
    #endregion
    #region Exchange
    private void PostExchangeConfigure()
    {
      ctx.Exchange.AddRange(
        new TraderExchange[]
        {
          new TraderExchange { ID=1, Name=Resources.ExchangeForex, Description=Resources.ExchangeForexDesc},
          new TraderExchange { ID=2, Name=Resources.ExchangeBinance, Description = Resources.ExchangeBinanceDesc},
        });
    }
    #endregion
    #region TraderSession
    private void PostTraderSessionConfigure()
    {
      var asia = ctx.Region.First(e => e.ID == 1);
      var europe = ctx.Region.First(e => e.ID == 2);
      var america = ctx.Region.First(e => e.ID == 3);
      var pacific = ctx.Region.First(e => e.ID == 4);

      ctx.Session.AddRange(
        new TraderSession[]
        {
          #region asia
          new TraderSession
          {
            ID=1, Region=asia, Name=Resources.Tokyo,
            WinterStarting = new DateTime(2023, 05, 01, 00, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 08, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 00, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 08, 0, 0),
          },

          new TraderSession
          {
            ID=2, Region=asia, Name=Resources.HongKong,
            WinterStarting = new DateTime(2023, 05, 01, 01, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 09, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 01, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 00, 0, 0),

          },
          #endregion
          #region europe
          new TraderSession
          {
            ID=3, Region=europe, Name=Resources.Frankfurt,
            WinterStarting = new DateTime(2023, 05, 01, 06, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 14, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 05, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 13, 0, 0),
          },
          new TraderSession
          {
            ID=4, Region=europe, Name=Resources.London,
            WinterStarting = new DateTime(2023, 05, 01, 07, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 15, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 06, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 14, 0, 0),
          },
          #endregion
          #region america
          new TraderSession
          {
            ID=5, Region=europe, Name=Resources.NewYork,
            WinterStarting = new DateTime(2023, 05, 01, 13, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 21, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 12, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 20, 0, 0),
          },
          new TraderSession
          {
            ID=6, Region=europe, Name=Resources.Chicago,
            WinterStarting = new DateTime(2023, 05, 01, 13, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 21, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 14, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 22, 0, 0),
          },
          #endregion
          #region pacific
          new TraderSession
          {
            ID=7, Region=europe, Name=Resources.Wellington,
            WinterStarting = new DateTime(2023, 05, 01, 21, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 03, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 20, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 04, 0, 0),
          },
          new TraderSession
          {
            ID=8, Region=europe, Name=Resources.Sydney,
            WinterStarting = new DateTime(2023, 05, 01, 23, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 05, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 22, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 04, 0, 0),
          },
          #endregion
        });
    }
    #endregion
    #region TraderRegion
    private void PostTraderRegionConfigure()
    {
      ctx.Region.AddRangeAsync(
        new TraderRegion[]
        {
          new TraderRegion { ID=1, Name=Resources.TraderRegionAsia },
          new TraderRegion { ID=2, Name=Resources.TraderRegionEurope },
          new TraderRegion { ID=3, Name = Resources.TraderRegionAmerica },
          new TraderRegion { ID=4, Name = Resources.TraderRegionPacific }
        });
    }
    #endregion
    #region Trend
    private void PostTrendConfigure()
    {
      ctx.Trend.AddRange(
        new Trend[]
        {
          new Trend { ID=1, Name=Resources.TrendUpward, Description=Resources.TrendUpwardDesc},
          new Trend { ID=2, Name=Resources.TrendDownward, Description = Resources.TrendDownwardDesc},
          new Trend { ID=3, Name=Resources.TrendSide, Description = Resources.TrendSideDesc}
        });
    }
    #endregion
    #region TimeFrame
    private void PostTimeFrameConfigure()
    {
      ctx.Frame.AddRange(
        new TimeFrame[]
        {
          new TimeFrame { ID=1, Name=Resources.TimeFrameMN, Description=Resources.TimeFrameMNDesc},
          new TimeFrame { ID=2, Name=Resources.TimeFrameW1, Description = Resources.TimeFrameW1Desc},
          new TimeFrame { ID=3, Name=Resources.TimeFrameD1, Description = Resources.TimeFrameD1Desc},
          new TimeFrame { ID=4, Name=Resources.TimeFrameH4, Description = Resources.TimeFrameH4Desc},
          new TimeFrame { ID=5, Name=Resources.TimeFrameH1, Description = Resources.TimeFrameH1Desc},
          new TimeFrame { ID=6, Name=Resources.TimeFrameM30, Description = Resources.TimeFrameM30Desc},
          new TimeFrame { ID=7, Name=Resources.TimeFrameM15, Description = Resources.TimeFrameM15Desc},
          new TimeFrame { ID=8, Name=Resources.TimeFrameM5, Description = Resources.TimeFrameM5Desc},
          new TimeFrame { ID=9, Name=Resources.TimeFrameM1, Description = Resources.TimeFrameM1Desc}
        });
    }
    #endregion
    #region TraderResult
    private void PostTraderResultConfigure()
    {
      ctx.Result.AddRange(
        new TraderResult[]
        {
          new TraderResult { ID=1, Name=Resources.TraderResultSuccess, Description=Resources.TraderResultDescriptionSuccess},
          new TraderResult { ID=2, Name=Resources.TraderResultNone, Description = Resources.TraderResultDescriptionNone},
          new TraderResult { ID=3, Name=Resources.TraderResultLoss, Description = Resources.TraderResultDescriptionLoss}
        });
    }
    #endregion
  }
}
