using Blazored.LocalStorage;
using Blazored.Toast;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.Core.Repository.RepositoryApi;
using DiaryOfTrader.WebBlazor.Core;
using DiaryOfTrader.WebBlazor.Core.HttpInterceptor;
using DiaryOfTrader.WebBlazor.Core.HttpRepository;
using DiaryOfTrader.WebBlazor.Server;
using Havit.Blazor.Components.Web;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(sp => new HttpClient (){BaseAddress = new Uri("https://localhost:7184")});

builder.Services.Configure<ApiConfiguration>
  (builder.Configuration.GetSection("ApiConfiguration"));

#region Register HttpRepository

builder.Services.AddHttpClient("DiaryOfTraderAPI", (sp, cl) =>
{
  var apiConfiguration = sp.GetRequiredService<IOptions<ApiConfiguration>>();
  cl.BaseAddress = new Uri(apiConfiguration.Value.BaseAddress);
  cl.EnableIntercept(sp);
});

var rootApi = "https://localhost:7236";
builder.Services.AddScoped<ITraderExchangeRepository, TraderExchangeRepositoryApi>(_ => new TraderExchangeRepositoryApi(rootApi));
builder.Services.AddScoped<ITimeFrameRepository, TimeFrameRepositoryApi>(_ => new TimeFrameRepositoryApi(rootApi));
builder.Services.AddScoped<IWalletRepository, WalletRepositoryApi>(_ => new WalletRepositoryApi(rootApi));
builder.Services.AddScoped<ITraderResultRepository, TraderResultRepositoryApi>(_ => new TraderResultRepositoryApi(rootApi));
builder.Services.AddScoped<ITrendRepository, TrendRepositoryApi>(_ => new TrendRepositoryApi(rootApi));
builder.Services.AddScoped<ITraderSessionRepository, TraderSessionRepositoryApi>(_ => new TraderSessionRepositoryApi(rootApi));
builder.Services.AddScoped<ITraderRegionRepository, TraderRegionRepositoryApi>(_ => new TraderRegionRepositoryApi(rootApi));
builder.Services.AddScoped<ISymbolRepository, SymbolRepositoryApi>(_ => new SymbolRepositoryApi(rootApi));
builder.Services.AddScoped<IEconomicCalendarRepository, EconomicCalendarRepositoryApi>(_ => new EconomicCalendarRepositoryApi(rootApi));
builder.Services.AddScoped<ITraderRepository, TraderRepositoryApi>(_ => new TraderRepositoryApi(rootApi));
builder.Services.AddScoped<IMarketReviewRepository, MarketReviewRepositoryApi>(_ => new MarketReviewRepositoryApi(rootApi));
builder.Services.AddScoped<IMarketReviewTimeFrameRepository, MarketReviewTimeFrameRepositoryApi>(_ => new MarketReviewTimeFrameRepositoryApi(rootApi));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

#endregion

builder.Services.AddScoped<CatalogItemState>();

builder.Services.AddBlazoredToast();

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>()?.CreateClient("DiaryOfTraderAPI"));

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddHxServices();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
