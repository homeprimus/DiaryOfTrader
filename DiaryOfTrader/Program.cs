using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.Core.Repository.Cache.Memory;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryOfTrader
{
  internal static class Program
  {
    static void ConfigureServices()
    {
      var services = new ServiceCollection();
      services.AddScoped<DbContext, DiaryOfTraderCtx>();
      //services.AddSingleton<DbContext, DiaryOfTraderCtx>();

      
      services.AddTransient<ICache, Memory>();
      //// инткрфейс добавили
      services.AddTransient<ISymbolRepository, SymbolRepositoryDb>();
      services.AddTransient<ITimeFrameRepository, TimeFrameRepositoryDb>();
      services.AddTransient<ITraderExchangeRepository, TraderExchangeRepositoryDb>();
      services.AddTransient<ITraderResultRepository, TraderResultRepositoryDb>();
      services.AddTransient<ITraderSessionRepository, TraderSessionRepositoryDb>();
      services.AddTransient<ITraderRegionRepository, TraderRegionRepositoryDb>();
      services.AddTransient<ITrendRepository, TrendRepositoryDb>();
      services.AddTransient<IWalletRepository, WalletRepositoryDb>();
      services.AddTransient<IMarketReviewRepository, MarketReviewRepositoryDb>();
      services.AddTransient<IMarketReviewTimeFrameRepository, MarketReviewTimeFrameRepositoryDb>();
      services.AddTransient<IDiaryRepository, DiaryRepositoryDb>();
      services.AddTransient<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();

      //кэш
      services.AddMemoryCache();

      services.AddSingleton<RibbonMain, RibbonMain>();

      Core.Entity.DiaryOfTrader.ServiceProvider = services.BuildServiceProvider();
    }
    [STAThread]
    static void Main()
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.

      ApplicationConfiguration.Initialize();
      ConfigureServices();
      var main = Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<RibbonMain>();
      Application.Run(main);
      //Application.Run(new Main());
    }
  }
}
