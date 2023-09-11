namespace DiaryOfTrader.Core.Interfaces.Cache
{
  public interface ICache
  {
    void Set(string key, byte[] value);
    void Set<T>(string key, T value);
    Task<byte[]?> Get(string key);
    Task<T?> Get<T>(string key);
  }
}
