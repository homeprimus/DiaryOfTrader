using System.Net.Http.Json;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class RepositoryApi<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    private readonly HttpClient _client = new HttpClient();
    private readonly string _endPoint;
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

    public async Task InsertRangeAsync(TEntity[] entities)
    {
      await _client.PostAsJsonAsync($"{_endPoint}/range", entities);
    }

    public async Task UpdateRangeAsync(TEntity[] entities)
    {
      await _client.PutAsJsonRangeAsync($"{_endPoint}/range", entities);
    }
    //????
    public async Task DeleteRangeAsync(long[] entityIds)
    {
      await _client.DeleteAsJsonRangeAsync<long>($"{_endPoint}/range", entityIds);
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
