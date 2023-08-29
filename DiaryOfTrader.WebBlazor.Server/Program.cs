using Blazored.Toast;
using DiaryOfTrader.Core.Interfaces.Repository;
using DiaryOfTrader.Core.Repository.RepositoryApi;
using DiaryOfTrader.WebBlazor.Core.HttpInterceptor;
using DiaryOfTrader.WebBlazor.Core.HttpRepository;
using DiaryOfTrader.WebBlazor.Server;
using Microsoft.Extensions.Options;
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
builder.Services.AddScoped<IEconomicCalendarRepository, EconomicCalendarHttpRepository>();


#endregion

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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
