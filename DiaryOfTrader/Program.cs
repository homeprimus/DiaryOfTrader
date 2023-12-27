#define use_db

using System.Net.Http;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.Cache.DistributedCache;
using DiaryOfTrader.Core.Repository.Cache.Memory;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using DiaryOfTrader.EditDialogs.Dictionary;
using DiaryOfTrader.Core.Repository.RepositoryApi;
using DiaryOfTrader.Core.WritableOptions;
using System.Data.Common;

namespace DiaryOfTrader
{
  internal static class Program
  {
    static ILoggingBuilder BuildLogging(ILoggingBuilder loggingBuilder)
    {
      loggingBuilder.ClearProviders();
      loggingBuilder.AddNLog();
      loggingBuilder.SetMinimumLevel(LogLevel.Trace);
      return loggingBuilder;
    }

    static IConfigurationRoot BuildConfiguration(ConfigurationManager configuration, IHostEnvironment environment)
    {
      return configuration
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddEnvironmentVariables()
        .AddJsonFile("appsettings", true, true)
        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
        .Build();
    }
    /// <summary>
    static ServiceProvider BuildServices(IServiceCollection services, IConfigurationRoot configuration)
    {
      services.AddScoped<DbContext, DiaryOfTraderCtx>();

      services.AddTransient<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();
#if use_db
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
      services.AddTransient<ITradingStrategyRepository, TradingStrategyRepositoryDb>();


      services.AddTransient<IRepository<Symbol> , SymbolRepositoryDb>();
      services.AddTransient<IRepository<TimeFrame>, TimeFrameRepositoryDb>();
      services.AddTransient<IRepository<TraderExchange>, TraderExchangeRepositoryDb>();
      services.AddTransient<IRepository<TraderResult>, TraderResultRepositoryDb>();
      services.AddTransient<IRepository<TraderSession>, TraderSessionRepositoryDb>();
      services.AddTransient<IRepository<TraderRegion>, TraderRegionRepositoryDb>();
      services.AddTransient<IRepository<Trend>, TrendRepositoryDb>();
      services.AddTransient<IRepository<Wallet>, WalletRepositoryDb>();
      services.AddTransient<IRepository<MarketReview>, MarketReviewRepositoryDb>();
      services.AddTransient<IRepository<MarketReviewTimeFrame>, MarketReviewTimeFrameRepositoryDb>();
      services.AddTransient<IRepository<Diary>, DiaryRepositoryDb>();
      services.AddTransient<IRepository<TradingStrategy>, TradingStrategyRepositoryDb>();
#else
      services.AddTransient<ISymbolRepository, SymbolRepositoryApi>();
      services.AddTransient<ITimeFrameRepository, TimeFrameRepositoryApi>();
      services.AddTransient<ITraderExchangeRepository, TraderExchangeRepositoryApi>();
      services.AddTransient<ITraderResultRepository, TraderResultRepositoryApi>();
      services.AddTransient<ITraderSessionRepository, TraderSessionRepositoryApi>();
      services.AddTransient<ITraderRegionRepository, TraderRegionRepositoryApi>();
      services.AddTransient<ITrendRepository, TrendRepositoryApi>();
      services.AddTransient<IWalletRepository, WalletRepositoryApi>();
      services.AddTransient<IMarketReviewRepository, MarketReviewRepositoryApi>();
      services.AddTransient<IMarketReviewTimeFrameRepository, MarketReviewTimeFrameRepositoryApi>();
      services.AddTransient<IDiaryRepository, DiaryRepositoryApi>();
      services.AddTransient<ITradingStrategyRepository, TradingStrategyRepositoryApi>();

      services.AddTransient<IRepository<Symbol>, SymbolRepositoryApi>();
      services.AddTransient<IRepository<TimeFrame>, TimeFrameRepositoryApi>();
      services.AddTransient<IRepository<TraderExchange>, TraderExchangeRepositoryApi>();
      services.AddTransient<IRepository<TraderResult>, TraderResultRepositoryApi>();
      services.AddTransient<IRepository<TraderSession>, TraderSessionRepositoryApi>();
      services.AddTransient<IRepository<TraderRegion>, TraderRegionRepositoryApi>();
      services.AddTransient<IRepository<Trend>, TrendRepositoryApi>();
      services.AddTransient<IRepository<Wallet>, WalletRepositoryApi>();
      services.AddTransient<IRepository<MarketReview>, MarketReviewRepositoryApi>();
      services.AddTransient<IRepository<MarketReviewTimeFrame>, MarketReviewTimeFrameRepositoryApi>();
      services.AddTransient<IRepository<Diary>, DiaryRepositoryApi>();
      services.AddTransient<IRepository<TradingStrategy>, TradingStrategyRepositoryApi>();
#endif

      services.AddSingleton<IServiceCollection> (services);

      //кэш
      
      var redis = configuration.GetSection("Redis");
      if (bool.TryParse(redis["Enabled"], out var enabled) && enabled)
      {
        services.AddStackExchangeRedisCache(options =>
        {
          options.Configuration = redis["ConnectionString"];

        });
        services.AddSingleton<ICache, Redis>();
      }
      else
      {
        services.AddMemoryCache();
        services.AddSingleton<ICache, Memory>();
      }

      services.AddTransient<HttpClient>();
      services.Configure<EndPointConfiguration>(configuration.GetSection(key: nameof(EndPointConfiguration)));
      services.ConfigureWritable<DbConnectionStringBuilder>(configuration.GetSection(key: "ConnectionStringBuilder"));

      #region UI
      services.AddSingleton<RibbonMain>();

      services.AddTransient<ExchangeDlg>();
      services.AddTransient<ResultDlg>();
      services.AddTransient<SymbolDlg>();
      services.AddTransient<TimeFrameDlg>();
      services.AddTransient<TradeSessionDlg>();
      services.AddTransient<TradingStrategyDlg>();
      services.AddTransient<TrendDlg>();
      services.AddTransient<WalletDlg>();
      #endregion

      return services.BuildServiceProvider();
    }

    [STAThread]
    static void Main(string[] args)
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.

      //ApplicationConfiguration.Initialize();

      var builder = Host.CreateApplicationBuilder();
      BuildLogging(builder.Logging);
      var configuration = BuildConfiguration(builder.Configuration, builder.Environment);
      Core.Entity.DiaryOfTrader.ServiceProvider = BuildServices(builder.Services, configuration);

      using var app = builder.Build();

      var main = Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<RibbonMain>();
      Application.Run(main);
    }
  }
}

