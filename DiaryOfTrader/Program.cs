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

namespace DiaryOfTrader
{
  internal static class Program
  {

    class Startup
    {
      private IConfigurationRoot Configuration { get; }

      public Startup(IHostEnvironment environment, IConfigurationBuilder configuration)
      {
        Configuration  = configuration
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
          .AddEnvironmentVariables()
          .Build();
      }

      public ServiceProvider ConfigureServices(IServiceCollection services)
      {
        services.AddScoped<DbContext, DiaryOfTraderCtx>();

        services.AddLogging(configure => configure.AddDebug());

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
        services.AddTransient<ITradingStrategyRepository, TradingStrategyRepositoryDb>();
        services.AddTransient<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();

        //кэш
        var redis = Configuration.GetSection("Redis");
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

        services.AddSingleton<RibbonMain, RibbonMain>();

        return services.BuildServiceProvider();
      }
    }

    static void ConfigureServices(string[] args)
    {
      var builder = Host.CreateApplicationBuilder(args);
      var env = builder.Environment;

      var configuration = builder.Configuration
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddCommandLine(args)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
        .AddEnvironmentVariables()
        .Build();


      // https://learn.microsoft.com/ru-ru/dotnet/core/extensions/configuration
      var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddCommandLine(args)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
        .AddEnvironmentVariables()
        .Build();

      var services = new ServiceCollection();
      services.AddScoped<DbContext, DiaryOfTraderCtx>();

      services.AddLogging(configure => configure.AddDebug());

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

      services.AddTransient<HttpClient>();

      //кэш
      var redis = config.GetSection("Redis");
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

      services.AddSingleton<RibbonMain, RibbonMain>();

      Core.Entity.DiaryOfTrader.ServiceProvider = services.BuildServiceProvider();

    }


    [STAThread]
    static void Main(string[] args)
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.

      ApplicationConfiguration.Initialize();

      var builder = Host.CreateApplicationBuilder(args);
      
      var startup = new Startup(builder.Environment, builder.Configuration);
      startup.ConfigureServices(builder.Services);
      using var host = builder.Build();


      //var env = builder.Environment;

      //var configuration = builder.Configuration
      //  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
      //  .AddCommandLine(args)
      //  .AddJsonFile("appsettings.json")
      //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
      //  .AddEnvironmentVariables()
      //  .Build();

      ConfigureServices(args);
      var main = Core.Entity.DiaryOfTrader.ServiceProvider.GetRequiredService<RibbonMain>();
      Application.Run(main);
      //Application.Run(new Main());
    }
  }
}
