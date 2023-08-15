
using System.Text;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.WebApi.Api;
using DiaryOfTrader.WebApi.Auth;
using DiaryOfTrader.WebApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ResgistryServices(builder.Services);
var app = builder.Build();
Configure(app);
var apiServices = app.Services.GetServices<IApi>();
foreach (var api in apiServices)
{
  api.Register(app);
}

app.Run();

void ResgistryServices(IServiceCollection serveices)
{
  // сваггер добавили
  serveices.AddEndpointsApiExplorer();
  serveices.AddSwaggerGen();

  //serveices.AddDbContext<HotelDb>(options =>
  //  options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

  serveices.AddScoped<DbContext, DiaryOfTraderCtx>();
  //// инткрфейс добавили
  serveices.AddScoped<ISymbolRepository, SymbolRepository>();
  serveices.AddScoped<ITimeFrameRepository, TimeFrameRepository>();
  serveices.AddScoped<ITraderExchangeRepository, TraderExchangeRepository>();
  serveices.AddScoped<ITraderResultRepository, TraderResultRepository>();
  serveices.AddScoped<ITraderSessionRepository, TraderSessionRepository>();
  serveices.AddScoped<ITraderRegionRepository, TraderRegionRepository>();
  serveices.AddScoped<ITrendRepository, TrendRepository>();
  serveices.AddScoped<IWalletRepository, WalletRepository>();
  serveices.AddScoped<IEconomicCalendarRepository, EconomicCalendarRepository>();


  // добавили авторизыцию
  serveices.AddSingleton<ITokenService>(new TokenService());
  serveices.AddSingleton<IAuthRepository>(new AuthRepository());

  serveices.AddAuthorization();
  serveices.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

  serveices.AddTransient<IApi, SymbolApi>();
  serveices.AddTransient<IApi, TimeFrameApi>();
  serveices.AddTransient<IApi, TraderExchangeApi>();
  serveices.AddTransient<IApi, TraderResultApi>();
  serveices.AddTransient<IApi, TraderSessionApi>();
  serveices.AddTransient<IApi, TraderRegionApi>();
  serveices.AddTransient<IApi, TrendApi>();
  serveices.AddTransient<IApi, WalletApi>();

  serveices.AddTransient<IApi, EconomicCalendarApi>();

  serveices.AddTransient<IApi, AuthorizationApi>();
}

void Configure(WebApplication application)
{
  application.UseAuthentication();
  application.UseAuthorization();

  if (application.Environment.IsDevelopment())
  {
    // сваггер добавили
    application.UseSwagger();
    application.UseSwaggerUI();
    //
    // создали базу
    //using var scope = application.Services.CreateScope();
    //var db = scope.ServiceProvider.GetRequiredService<HotelDb>();
    //db.Database.EnsureCreated();
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
