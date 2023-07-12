
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryOfTrader.Core.Data
{
  internal class DataInitializer
  {
    private DiaryOfTraderCtx ctx;

    public DataInitializer(DiaryOfTraderCtx ctx)
    {
      this.ctx = ctx;
    }

    public virtual void Update()
    {
      PostSymbolConfigure();
      PostWalletConfigure();
      PostExchangeConfigure();
      PostTraderRegionConfigure();
      PostTraderSessionConfigure();
      PostTrendConfigure();
      PostTraderResultConfigure();
      PostTimeFrameConfigure();

      ctx.SaveChanges();
    }
    #region Symbol
    private void PostSymbolConfigure()
    {
      ctx.Symbol.AddRange(
        new Symbol[]
        {
          new Symbol { ID=1, Name=Resources.SymbolDXY, Description=Resources.SymbolDXYDesc, Order = 10},
          new Symbol { ID=2, Name=Resources.SymbolEURUSD, Description=Resources.SymbolEURUSDDesc, Order = 20},
          new Symbol { ID=3, Name=Resources.SymbolUSDJPY, Description=Resources.SymbolUSDJPYDesc, Order = 30},

          new Symbol { ID=4, Name=Resources.SymbolSPX, Description=Resources.SymbolSPXDesc, Order = 40},

          new Symbol { ID=5, Name=Resources.SymbolBTCUSD, Description=Resources.SymbolBTCUSDDesc, Order = 50},
          new Symbol { ID=6, Name=Resources.SymbolETHUSD, Description=Resources.SymbolETHUSDDesc, Order = 60},
          new Symbol { ID=7, Name=Resources.SymbolBNBUSD, Description=Resources.SymbolBNBUSDDesc, Order = 70},
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
          new TraderExchange { ID=1, Name=Resources.ExchangeForex, Description=Resources.ExchangeForexDesc, Order = 10},
          new TraderExchange { ID=2, Name=Resources.ExchangeBinance, Description = Resources.ExchangeBinanceDesc, Order = 20},
        });
    }
    #endregion
    #region TraderSession

    private void PostTraderSessionConfigure()
    {
      #region asia

      var asia = new TraderRegion { ID = 1, Name = Resources.TraderRegionAsia, Description = Resources.TraderRegionAsiaDesc, Order = 10 };
      asia.Sessions.AddRange(
        new[]
        {
          new TraderSession
          {
            ID = 1,
            Region = asia,
            Name = Resources.Tokyo,
            Description = Resources.TokyoDesc,
            WinterStarting = new DateTime(2023, 05, 01, 00, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 08, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 00, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 08, 0, 0),
          },
          new TraderSession
          {
            ID = 2,
            Region = asia,
            Name = Resources.HongKong, 
            Description =  Resources.HongKongDesc,
            WinterStarting = new DateTime(2023, 05, 01, 01, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 09, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 01, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 00, 0, 0),

          }
        }
      );

      #endregion

      #region europe

      var europe = new TraderRegion { ID = 2, Name = Resources.TraderRegionEurope, Description = Resources.TraderRegionEuropeDesc, Order = 20 };
      europe.Sessions.AddRange(
        new[]
        {
          new TraderSession
          {
            ID = 3,
            Region = europe,
            Name = Resources.Frankfurt,
            Description = Resources.FrankfurtDesc,
            WinterStarting = new DateTime(2023, 05, 01, 06, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 14, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 05, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 13, 0, 0),
          },
          new TraderSession
          {
            ID = 4,
            Region = europe,
            Name = Resources.London,
            Description = Resources.LondonDesc,
            WinterStarting = new DateTime(2023, 05, 01, 07, 0, 0),
            WinterFinished = new DateTime(2023, 05, 01, 15, 0, 0),
            SummerStarting = new DateTime(2023, 05, 01, 06, 0, 0),
            SummerFinished = new DateTime(2023, 05, 01, 14, 0, 0),
          },
        });

      #endregion


      #region america

      var america = new TraderRegion { ID = 3, Name = Resources.TraderRegionAmerica, Description = Resources.TraderRegionAmericaDesc, Order = 30 };
      america.Sessions.AddRange(new[]
      {
        new TraderSession
        {
          ID = 5,
          Region = europe,
          Name = Resources.NewYork,
          Description = Resources.NewYorkDesc,
          WinterStarting = new DateTime(2023, 05, 01, 13, 0, 0),
          WinterFinished = new DateTime(2023, 05, 01, 21, 0, 0),
          SummerStarting = new DateTime(2023, 05, 01, 12, 0, 0),
          SummerFinished = new DateTime(2023, 05, 01, 20, 0, 0),
        },
        new TraderSession
        {
          ID = 6,
          Region = europe,
          Name = Resources.Chicago,
          Description = Resources.ChicagoDesc,
          WinterStarting = new DateTime(2023, 05, 01, 13, 0, 0),
          WinterFinished = new DateTime(2023, 05, 01, 21, 0, 0),
          SummerStarting = new DateTime(2023, 05, 01, 14, 0, 0),
          SummerFinished = new DateTime(2023, 05, 01, 22, 0, 0),
        },
      });

      #endregion

      #region pacific

      var pacific = new TraderRegion { ID = 4, Name = Resources.TraderRegionPacific, Description = Resources.TraderRegionPacificDesc, Order = 40 };
      pacific.Sessions.AddRange(new[]
      {
        new TraderSession
        {
          ID = 7,
          Region = europe,
          Name = Resources.Wellington,
          Description = Resources.WellingtonDesc,
          WinterStarting = new DateTime(2023, 05, 01, 21, 0, 0),
          WinterFinished = new DateTime(2023, 05, 01, 03, 0, 0),
          SummerStarting = new DateTime(2023, 05, 01, 20, 0, 0),
          SummerFinished = new DateTime(2023, 05, 01, 04, 0, 0),
        },
        new TraderSession
        {
          ID = 8,
          Region = europe,
          Name = Resources.Sydney,
          Description = Resources.ChicagoDesc,
          WinterStarting = new DateTime(2023, 05, 01, 23, 0, 0),
          WinterFinished = new DateTime(2023, 05, 01, 05, 0, 0),
          SummerStarting = new DateTime(2023, 05, 01, 22, 0, 0),
          SummerFinished = new DateTime(2023, 05, 01, 04, 0, 0),
        },
      });

      ctx.Region.AddRange(new[] { asia, europe, america, pacific });

      ctx.Region.ToList().ForEach(e=> ctx.Session.AddRange(e.Sessions));

      #endregion
    }

    #endregion
    #region TraderRegion
    private void PostTraderRegionConfigure()
    {
    }
    #endregion
    #region Trend
    private void PostTrendConfigure()
    {
      ctx.Trend.AddRange(
        new Trend[]
        {
          new Trend { ID=1, Name=Resources.TrendUpward, Description=Resources.TrendUpwardDesc, Order = 10},
          new Trend { ID=2, Name=Resources.TrendDownward, Description = Resources.TrendDownwardDesc, Order = 20},
          new Trend { ID=3, Name=Resources.TrendSide, Description = Resources.TrendSideDesc, Order = 30}
        });
    }
    #endregion
    #region TimeFrame
    private void PostTimeFrameConfigure()
    {
      ctx.Frame.AddRange(
        new TimeFrame[]
        {
          new TimeFrame { ID=1, Name=Resources.TimeFrameMN, Description=Resources.TimeFrameMNDesc, Order = 10},
          new TimeFrame { ID=2, Name=Resources.TimeFrameW1, Description = Resources.TimeFrameW1Desc, Order = 20},
          new TimeFrame { ID=3, Name=Resources.TimeFrameD1, Description = Resources.TimeFrameD1Desc, Order = 30},
          new TimeFrame { ID=4, Name=Resources.TimeFrameH4, Description = Resources.TimeFrameH4Desc, Order = 40},
          new TimeFrame { ID=5, Name=Resources.TimeFrameH1, Description = Resources.TimeFrameH1Desc, Order = 50},
          new TimeFrame { ID=6, Name=Resources.TimeFrameM30, Description = Resources.TimeFrameM30Desc, Order = 60},
          new TimeFrame { ID=7, Name=Resources.TimeFrameM15, Description = Resources.TimeFrameM15Desc, Order = 70},
          new TimeFrame { ID=8, Name=Resources.TimeFrameM5, Description = Resources.TimeFrameM5Desc, Order = 80},
          new TimeFrame { ID=9, Name=Resources.TimeFrameM1, Description = Resources.TimeFrameM1Desc, Order = 90}
        });
    }
    #endregion
    #region TraderResult
    private void PostTraderResultConfigure()
    {
      ctx.Result.AddRange(
        new TraderResult[]
        {
          new TraderResult { ID=1, Name=Resources.TraderResultSuccess, Description=Resources.TraderResultDescriptionSuccess, Order = 10},
          new TraderResult { ID=2, Name=Resources.TraderResultNone, Description = Resources.TraderResultDescriptionNone, Order = 20},
          new TraderResult { ID=3, Name=Resources.TraderResultLoss, Description = Resources.TraderResultDescriptionLoss, Order = 30}
        });
    }
    #endregion
  }
}
