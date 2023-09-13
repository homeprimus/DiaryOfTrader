using System.Net.Http.Json;
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class RepositoryApi<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    protected readonly HttpClient _client = new HttpClient();
    protected readonly string _endPoint;
    #endregion

    public RepositoryApi(string root)
    {
      _endPoint = root + "/" + typeof(TEntity).Name.ToLowerInvariant() + "s";
    }

    public async Task<List<TEntity?>> GetAllAsync()
    {
      return await _client.GetFromJsonAsync<List<TEntity>>(_endPoint);
    }

    public async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      throw new NotImplementedException();
    }

    public async Task<TEntity?> GetByIdAsync(int entityId)
    {
      return await _client.GetFromJsonAsync<TEntity>($"{_endPoint}/{entityId}");
    }

    public async Task InsertAsync(TEntity entity)
    {
      await _client.PostAsJsonAsync($"{_endPoint}", entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
      await _client.PutAsJsonAsync($"{_endPoint}", entity);
    }

    public async Task DeleteAsync(int entityId)
    {
      await _client.DeleteAsync($"{_endPoint}/{entityId}");
    }

    public Task SaveAsync()
    {
      throw new NotImplementedException();
    }
    protected override void Free()
    {
      base.Free();
      _client.Dispose();
    }
  }
}
