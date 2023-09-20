
using System.Text;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using DiaryOfTrader.Core.Repository.Cache.DistributedCache;
using DiaryOfTrader.Core.Repository.Cache.Memory;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using DiaryOfTrader.WebApi.Api;
using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ResgistryServices(builder.Services, builder.Configuration);
var app = builder.Build();
Configure(app);
var apiServices = app.Services.GetServices<IApi>();
foreach (var api in apiServices)
{
  api.Register(app);
}

app.Run();

void ResgistryServices(IServiceCollection services, ConfigurationManager configurationManager)
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

  // добавили авторизыцию
  services.AddSingleton<ITokenService>(new TokenService());
  //services.AddSingleton<ITraderRepository>(new TraderRepository());

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
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
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

  if (bool.TryParse(configurationManager["Redis:Enabled"], out var enabled) && enabled)
  {
    services.AddStackExchangeRedisCache(options =>
    {
      options.Configuration = configurationManager["Redis:ConnectionString"];
      //options.InstanceName = "local";
    });
    services.AddSingleton<ICache, Redis>();
  }
  else
  {
    services.AddMemoryCache();
    services.AddSingleton<ICache, Memory>();
  }

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
  }

  // Get a shared logger object
  var loggerFactory = application.Services.GetService<ILoggerFactory>();
  var logger = loggerFactory?.CreateLogger<Program>();

  if (logger == null)
  {
    throw new InvalidOperationException("Logger not found");
  }

  application.UseHttpsRedirection();

}
