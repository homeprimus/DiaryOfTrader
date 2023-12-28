
using System.Data.Common;
using System.Text;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.Cache.DistributedCache;
using DiaryOfTrader.Core.Repository.Cache.Memory;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using DiaryOfTrader.WebApi.Api;
using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using DiaryOfTrader.Core.WritableOptions;

var builder = WebApplication.CreateBuilder(args);
BuildLogging(builder.Logging);
var configuration = BuildConfiguration(builder.Configuration, builder.Environment);
var serviceProvider = BuildServices(builder.Services, configuration);

using var app = builder.Build();

Configure(app);

app.Run();


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

static ServiceProvider BuildServices(IServiceCollection services, IConfigurationRoot configuration)
{
  // сваггер добавили
  services.AddEndpointsApiExplorer();
  services.AddSwaggerGen();

  //services.AddDbContext<HotelDb>(options =>
  //  options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

  services.AddScoped<DbContext, DiaryOfTraderCtx>();
  //// инткрфейс добавили
  services.AddScoped<ISymbolRepository, SymbolRepositoryDb>();
  services.AddScoped<ITimeFrameRepository, TimeFrameRepositoryDb>();
  services.AddScoped<ITraderExchangeRepository, TraderExchangeRepositoryDb>();
  services.AddScoped<ITraderResultRepository, TraderResultRepositoryDb>();
  services.AddScoped<ITraderSessionRepository, TraderSessionRepositoryDb>();
  services.AddScoped<ITraderRegionRepository, TraderRegionRepositoryDb>();
  services.AddScoped<ITrendRepository, TrendRepositoryDb>();
  services.AddScoped<IWalletRepository, WalletRepositoryDb>();

  services.AddScoped<IMarketReviewRepository, MarketReviewRepositoryDb>();
  services.AddScoped<IMarketReviewTimeFrameRepository, MarketReviewTimeFrameRepositoryDb>();
  services.AddScoped<IDiaryRepository, DiaryRepositoryDb>();

  services.AddScoped<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();
  services.AddScoped<ITraderRepository, TraderRepositoryDb>();

  services.Configure<EndPointConfiguration>(configuration.GetSection(nameof(EndPointConfiguration)));
  //services.AddSingleton(new EndPointConfiguration());

  // добавили авторизыцию
  services.AddSingleton<ITokenService>(new TokenService());

  services.AddAuthorization();
  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new()
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
      };
    });

  services.AddTransient<IApi, SymbolApi>();
  services.AddTransient<IApi, TimeFrameApi>();
  services.AddTransient<IApi, TraderExchangeApi>();
  services.AddTransient<IApi, TraderResultApi>();
  services.AddTransient<IApi, TraderSessionApi>();
  services.AddTransient<IApi, TraderRegionApi>();
  services.AddTransient<IApi, TrendApi>();
  services.AddTransient<IApi, WalletApi>();
  services.AddTransient<IApi, DiaryApi>();

  services.AddTransient<IApi, MarketReviewApi>();
  services.AddTransient<IApi, MarketReviewTimeFrameApi>();

  services.AddTransient<IApi, EconomicCalendarApi>();

  services.AddTransient<IApi, TraderApi>();

  #region add Cache
  if (bool.TryParse(configuration["Redis:Enabled"], out var enabled) && enabled)
  {
    services.AddStackExchangeRedisCache(options =>
    {
      options.Configuration = configuration["Redis:ConnectionString"];
    });
    services.AddSingleton<ICache, Redis>();
  }
  else
  {
    services.AddMemoryCache();
    services.AddSingleton<ICache, Memory>();
  }
  #endregion
  services.ConfigureWritable<DbConnectionStringBuilder>(configuration.GetSection(key: "ConnectionStringBuilder"));

  return services.BuildServiceProvider();
}

void Configure(WebApplication application)
{
  application.UseAuthentication();
  application.UseAuthorization();

  if (true) //(application.Environment.IsDevelopment())
  {
    // сваггер добавили
    application.UseSwagger();
    application.UseSwaggerUI();
    //
    application.UseDeveloperExceptionPage();
  }

  //var loggerFactory = application.Services.GetService<ILoggerFactory>();
  //var logger = loggerFactory?.CreateLogger<Program>();
  //if (logger == null)
  //{
  //  throw new InvalidOperationException("Logger not found");
  //}

  application.UseHttpsRedirection();

  var apiServices = application.Services.GetServices<IApi>();
  foreach (var api in apiServices)
  {
    api.Register(app);
  }

}
