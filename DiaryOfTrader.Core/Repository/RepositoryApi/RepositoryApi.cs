using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class RepositoryApi<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    private readonly HttpClient _client;
    private readonly string _endPoint;
    private readonly ILogger<RepositoryApi<TEntity>> _logger;
    #endregion

    public RepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<TEntity>> logger)
    {
      var entity = typeof(TEntity).Name.ToLowerInvariant();
      var url = new UriBuilder(config.Value.EndPoint) { Path = config.Value.Version(entity) + "/" + entity + "s" };
      _endPoint = url.ToString();
      _client = client;
      _logger = logger;
    }

    public async Task<List<TEntity?>> GetAllAsync()
    {
      _logger.LogInformation(nameof(GetAllAsync));
      return await _client.GetFromJsonAsync<List<TEntity>>(_endPoint);
    }

    public async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      _logger.LogInformation(nameof(GetAllAsync));
      throw new NotImplementedException();
    }

    public async Task<TEntity?> GetByIdAsync(long entityId)
    {
      _logger.LogInformation(nameof(GetByIdAsync));
      return await _client.GetFromJsonAsync<TEntity>($"{_endPoint}/{entityId}");
    }

    public async Task InsertAsync(List<TEntity> entities)
    {
      _logger.LogInformation(nameof(InsertAsync));
      await _client.PostAsJsonAsync($"{_endPoint}", entities);
    }

    public async Task InsertAsync(TEntity entity)
    {
      await InsertAsync(new List<TEntity> { entity });
    }

    public async Task UpdateAsync(List<TEntity> entities)
    {
      _logger.LogInformation(nameof(UpdateAsync));
      await _client.PutAsJsonAsync($"{_endPoint}", entities);
    }

    public async Task UpdateAsync(TEntity entity)
    {
      await UpdateAsync(new List<TEntity> { entity });
    }

    public async Task DeleteAsync(List<long> entityIds)
    {
      _logger.LogInformation(nameof(DeleteAsync));
      await _client.DeleteAsJsonRangeAsync<long>($"{_endPoint}", entityIds);
    }

    public async Task DeleteAsync(long entityId)
    {
      await DeleteAsync(new List<long> { entityId });
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
