using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class RepositoryDb<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    private readonly DiaryOfTraderCtx _data;
    private readonly DbSet<TEntity> _entity;
    private readonly ICache _cache;
    private readonly string _key;
    private readonly ILogger _logger;
    #endregion

    public RepositoryDb(DbContext data, ICache cache, ILogger<RepositoryDb<TEntity>> logger)
    {
      _data = (DiaryOfTraderCtx)data;
      _entity = _data.Set<TEntity>();
      _cache = cache;
      _logger = logger;
      _key = typeof(TEntity).Name.ToLowerInvariant();
    }

    protected DiaryOfTraderCtx Data { get { return _data; } }
    protected DbSet<TEntity> Entity { get { return _entity; } }
    protected ICache Cache { get { return _cache; } }
    protected string CacheKey { get { return _key; } }

    public virtual async Task<List<TEntity?>> GetAllAsync()
    {
       var result = _cache.Get<List<TEntity?>>(_key);
      if (result == null)
      {
        _logger.LogInformation($"DB: {nameof(GetAllAsync)}");
        result = await _entity.ToListAsync();
        _cache.Set(_key, result);
      }
      else
      {
        _logger.LogInformation($"Cache: {nameof(GetAllAsync)}");
      }
      return result;
    }

    public virtual async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      return await _entity.Where(e => e.Name.Contains(pattern[0].ToString()!)).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(long entryId)
    {
      var result = _cache.Get<TEntity?>($"{_key}:{entryId}");
      if (result == null)
      {
        _logger.LogInformation($"DB: {nameof(GetByIdAsync)}");
        result = await _entity.Where(e => e.ID == entryId).FirstOrDefaultAsync();
        _cache.Set($"{_key}:{entryId}", result);
      }
      else
      {
        _logger.LogInformation($"Cache: {nameof(GetByIdAsync)}");
      }
      return result;
    }
    public virtual async Task InsertAsync(List<TEntity> entities)
    {
      _logger.LogInformation($"DB: {nameof(InsertAsync)}");
      await _entity.AddRangeAsync(entities);
      await SaveAsync();

      await _entity.ForEachAsync(e => _cache.Set($"{_key}:{e.ID}", e));
      _cache.Remove(_key);
    }
    public async Task InsertAsync(TEntity entity)
    {
      await InsertAsync(new List<TEntity> { entity });
    }
    public virtual async Task UpdateAsync(List<TEntity> entities)
    {
      _logger.LogInformation($"DB: {nameof(UpdateAsync)}");
      _entity.UpdateRange(entities);
      await SaveAsync();

      await _entity.ForEachAsync(e => _cache.Remove($"{_key}:{e.ID}"));
      _cache.Remove(_key);
    }
    public async Task UpdateAsync(TEntity entity)
    {
      await UpdateAsync(new List<TEntity> { entity });
    }
    public async Task DeleteAsync(List<long> entityIds)
    {
      _logger.LogInformation($"DB: {nameof(DeleteAsync)}");
      _entity.RemoveRange(_entity.Where(e => entityIds.Contains(e.ID)));
       await SaveAsync();

       await _entity.ForEachAsync(e => _cache.Remove($"{_key}:{e.ID}"));
       _cache.Remove(_key);
    }
    public async Task DeleteAsync(long entityId)
    {
      await DeleteAsync(new List<long>() { entityId });
    }
    public async Task SaveAsync()
    {
      await _data.SaveChangesAsync();
    }
    protected override void Free()
    {
      base.Free();
      _data.Dispose();
    }

  }
}
