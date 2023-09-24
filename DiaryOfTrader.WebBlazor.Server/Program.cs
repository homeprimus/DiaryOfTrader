using Blazored.LocalStorage;
using Blazored.Toast;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryApi;
using DiaryOfTrader.WebBlazor.Core;
using DiaryOfTrader.WebBlazor.Core.HttpInterceptor;
using DiaryOfTrader.WebBlazor.Core.HttpRepository;
using DiaryOfTrader.WebBlazor.Server;
using Microsoft.Extensions.Options;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddScoped(sp => new HttpClient (){BaseAddress = new Uri("https://localhost:7184")});

builder.Services.Configure<ApiConfiguration>
  (builder.Configuration.GetSection("ApiConfiguration"));

builder.Services.Configure<EndPointConfiguration>
  (builder.Configuration.GetSection("EndPointConfiguration"));

#region Register HttpRepository

builder.Services.AddHttpClient("DiaryOfTraderAPI", (sp, cl) =>
{
  var apiConfiguration = sp.GetRequiredService<IOptions<ApiConfiguration>>();
  cl.BaseAddress = new Uri(apiConfiguration.Value.BaseAddress);
  cl.EnableIntercept(sp);
});

builder.Services.AddSingleton<EndPointConfiguration>();

builder.Services.AddScoped<ITraderExchangeRepository, TraderExchangeRepositoryApi>();
builder.Services.AddScoped<ITimeFrameRepository, TimeFrameRepositoryApi>();
builder.Services.AddScoped<IWalletRepository, WalletRepositoryApi>();
builder.Services.AddScoped<ITraderResultRepository, TraderResultRepositoryApi>();
builder.Services.AddScoped<ITrendRepository, TrendRepositoryApi>();
builder.Services.AddScoped<ITraderSessionRepository, TraderSessionRepositoryApi>();
builder.Services.AddScoped<ITraderRegionRepository, TraderRegionRepositoryApi>();
builder.Services.AddScoped<ISymbolRepository, SymbolRepositoryApi>();
builder.Services.AddScoped<ITradingStrategyRepository, TradingStrategyRepositoryApi>();
builder.Services.AddScoped<IEconomicCalendarRepository, EconomicCalendarRepositoryApi>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

#endregion

builder.Services.AddScoped<CatalogItemState>();

builder.Services.AddBlazoredToast();

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>()?.CreateClient("DiaryOfTraderAPI"));

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

var endPoint = app.Services.GetRequiredService<EndPointConfiguration>();
var configuration = app.Services.GetRequiredService<IOptions<EndPointConfiguration>>();
endPoint.EndPoint = configuration.Value.EndPoint;
endPoint.Default = configuration.Value.Default;

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
