
using System.Text;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using DiaryOfTrader.WebApi.Api;
using DiaryOfTrader.WebApi.Auth;
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
  serveices.AddScoped<ISymbolRepository, SymbolRepositoryDb>();
  serveices.AddScoped<ITimeFrameRepository, TimeFrameRepositoryDb>();
  serveices.AddScoped<ITraderExchangeRepository, TraderExchangeRepositoryDb>();
  serveices.AddScoped<ITraderResultRepository, TraderResultRepositoryDb>();
  serveices.AddScoped<ITraderSessionRepository, TraderSessionRepositoryDb>();
  serveices.AddScoped<ITraderRegionRepository, TraderRegionRepositoryDb>();
  serveices.AddScoped<ITrendRepository, TrendRepositoryDb>();
  serveices.AddScoped<IWalletRepository, WalletRepositoryDb>();
  serveices.AddScoped<IEconomicCalendarRepository, EconomicCalendarRepositoryDb>();

  serveices.AddScoped<ITraderRepository, TraderRepositoryDb>();

  // добавили авторизыцию
  serveices.AddSingleton<ITokenService>(new TokenService());
  //serveices.AddSingleton<ITraderRepository>(new TraderRepository());

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

  serveices.AddTransient<IApi, TraderApi>();
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
