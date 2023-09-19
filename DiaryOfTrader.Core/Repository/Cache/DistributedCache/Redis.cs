using System.Text.Json;
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.Cache.DistributedCache
{
  /*
      (1)
      // добавление кэширования
      builder.Services.AddStackExchangeRedisCache(options => {
        options.Configuration = "localhost";
        options.InstanceName = "local";
        });   
  
      (2)
      // Register the RedisCache service
      services.AddStackExchangeRedisCache(options =>
      {
          options.Configuration = Configuration.GetSection("Redis")["ConnectionString"];
      });
      // ...
      services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());
      // ..
      -----------
        "Redis": {
        "ConnectionString": "localhost:5002"
      }
      -----------
   */
  public class Redis: ICache
  {
    private IDistributedCache _cache;
    private int _liveMinutes;

    public Redis()
    {
      _liveMinutes = 5;
      var options = new RedisCacheOptions
      {
        Configuration = "localhost",
        InstanceName = "local"
      };
      var optionsAccessor = Options.Create(options);
      _cache = new RedisCache(optionsAccessor);
    }

    public Redis(IDistributedCache сache, int liveMinutes)
    {
      
      _cache = сache;
      _liveMinutes = liveMinutes;
    }

    public async void Set(string key, byte[] value)
    {
      await _cache.SetAsync(key, value, new DistributedCacheEntryOptions
      {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_liveMinutes)
      });
    }

    public async void Set<T>(string key, T value)
    {
      await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), new DistributedCacheEntryOptions
      {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_liveMinutes)
      });
    }

    public async Task<byte[]?> Get(string key)
    {
      return await _cache.GetAsync(key);
    }

    public T? Get<T>(string key)
    {
      return JsonSerializer.Deserialize<T>(_cache.GetString(key));
    }
  }
}
