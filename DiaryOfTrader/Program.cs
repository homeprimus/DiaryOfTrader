using System.Net.Http;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using DiaryOfTrader.Core.Interfaces.Repository;
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
      services.AddTransient<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();

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
      services.AddSingleton<EndPointConfiguration>();

      #region UI
      services.AddSingleton<RibbonMain>();
      services.AddSingleton<ExchangeDlg>();
      services.AddSingleton<ResultDlg>();
      services.AddSingleton<SymbolDlg>();
      services.AddSingleton<TimeFrameDlg>();
      services.AddSingleton<TradeSessionDlg>();
      services.AddSingleton<TradingStrategyDlg>();
      services.AddSingleton<TrendDlg>();
      services.AddSingleton<WalletDlg>();
      #endregion

      return services.BuildServiceProvider();
    }

    [STAThread]
    static void Main(string[] args)
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.

      ApplicationConfiguration.Initialize();

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

