
using System.Collections;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryOfTrader.Core.Entity
{
  public static class DiaryOfTrader 
  {

    public static IServiceProvider ServiceProvider { get; set; }
    public static Trader Trader { get; set; }
    public static ISymbolRepository SymbolRepository { get { return ServiceProvider.GetRequiredService<ISymbolRepository>(); } }
    public static ITimeFrameRepository TimeFrameRepository { get { return ServiceProvider.GetRequiredService<ITimeFrameRepository>(); } }
    public static ITraderExchangeRepository TraderExchangeRepository { get { return ServiceProvider.GetRequiredService<ITraderExchangeRepository>(); } }
    public static ITraderResultRepository TraderResultRepository { get { return ServiceProvider.GetRequiredService<ITraderResultRepository>(); } }
    public static ITraderSessionRepository TraderSessionRepository { get { return ServiceProvider.GetRequiredService<ITraderSessionRepository>(); } }
    public static ITraderRegionRepository TraderRegionRepository { get { return ServiceProvider.GetRequiredService<ITraderRegionRepository>(); } }
    public static ITradingStrategyRepository TradingStrategyRepository { get { return ServiceProvider.GetRequiredService<ITradingStrategyRepository>(); } }
    public static ITrendRepository TrendRepository { get { return ServiceProvider.GetRequiredService<ITrendRepository>(); } }
    public static IWalletRepository WalletRepository { get { return ServiceProvider.GetRequiredService<IWalletRepository>(); } }
    public static IMarketReviewRepository MarketReviewRepository { get { return ServiceProvider.GetRequiredService<IMarketReviewRepository>(); } }
    public static IMarketReviewTimeFrameRepository MarketReviewTimeFrameRepository { get { return ServiceProvider.GetRequiredService<IMarketReviewTimeFrameRepository>(); } }
    public static IDiaryRepository DiaryRepository { get { return ServiceProvider.GetRequiredService<IDiaryRepository>(); } }
    public static IEconomicCalendarRepository EconomicCalendarRepository { get { return ServiceProvider.GetRequiredService<IEconomicCalendarRepository>(); } }

    public static IList GetSymbol()
    {
      return SymbolRepository.GetAllAsync().Result
        .OrderBy(e=>e.Order)
        .Select(e=>new KeyValuePair<string, Symbol>(e.Name, e))
        .ToList();
    }
    public static IList GetTimeFrame()
    {
      return TimeFrameRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, TimeFrame>(e.Name, e))
        .ToList();
    }
    public static IList GetTraderExchange()
    {
      return TraderExchangeRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, TraderExchange>(e.Name, e))
        .ToList();
    }
    public static IList GetTrend()
    {
      return TrendRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, Trend>(e.Name, e))
        .ToList();
    }
    public static IList GetTraderResult()
    {
      return TraderResultRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, TraderResult>(e.Name, e))
        .ToList();
    }
    public static IList GetWallet()
    {
      return WalletRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, Wallet>(e.Name, e))
        .ToList();
    }
    public static IList GetTradingStrategy()
    {
      return TradingStrategyRepository.GetAllAsync().Result
        .OrderBy(e => e.Order)
        .Select(e => new KeyValuePair<string, TradingStrategy>(e.Name, e))
        .ToList();
    }


  }
}
