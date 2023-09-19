using Microsoft.Extensions.Caching.Memory;
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Internal;

namespace DiaryOfTrader.Core.Repository.Cache.Memory
{
  /*
      // добавление кэширования
      builder.Services.AddMemoryCache();// добавление кэширования
   */
  public class Memory: ICache
  {
    IMemoryCache _cache;
    private int _liveMinutes;

    public Memory()
    {
      _liveMinutes = 5;
      var options = new MemoryCacheOptions
      {
        Clock = new SystemClock(),
        CompactionPercentage = 1,
        ExpirationScanFrequency = TimeSpan.FromMinutes(_liveMinutes),
        SizeLimit = null
      };
      var optionsAccessor = Options.Create(options);
      _cache = new MemoryCache(optionsAccessor);
    }
    public Memory(IMemoryCache сache, int liveMinutes = 5)
    {
      _cache = сache;
      _liveMinutes = liveMinutes;
    }

    public void Set(string key, byte[] value)
    {
      _cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(_liveMinutes)));
    }

    public void Set<T>(string key, T value)
    {
      _cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(_liveMinutes)));
    }

    public async Task<byte[]?> Get(string key)
    {
      return await Task.Run(()=>
      {
        _cache.TryGetValue(key, out byte[]? value);
        return value;
      });
    }

    public T? Get<T>(string key)
    {
      _cache.TryGetValue(key, out T? value);
      return value;
    }
  }
}
