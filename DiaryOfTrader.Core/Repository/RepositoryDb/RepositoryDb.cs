

using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class RepositoryDb<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    private readonly DiaryOfTraderCtx _data;
    private readonly DbSet<TEntity> _entity;
    #endregion

    public RepositoryDb(DbContext data)
    {
      _data = (DiaryOfTraderCtx)data;
      _entity = _data.Set<TEntity>();
    }

    protected DiaryOfTraderCtx Data { get { return _data; } }
    protected DbSet<TEntity> Entity { get { return _entity; } }

    public virtual async Task<List<TEntity?>> GetAllAsync()
    {
      return await _entity.ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      return await _entity.Where(e => e.Name.Contains(pattern[0].ToString()!)).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(long entryId) 
    {
      return await _entity.Where(e => e.ID == entryId).FirstOrDefaultAsync();
    }

    public virtual async Task InsertAsync(List<TEntity> entities)
    {
      await _entity.AddRangeAsync(entities);
      await SaveAsync();
    }

    public async Task InsertAsync(TEntity entity)
    {
      await InsertAsync(new List<TEntity> { entity });
    }

    public virtual async Task UpdateAsync(List<TEntity> entities)
    {
      _entity.UpdateRange(entities);
      await SaveAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
      await UpdateAsync(new List<TEntity> { entity });
    }

    public async Task DeleteAsync(List<long> entityIds)
    {
      _entity.RemoveRange(_entity.Where(e => entityIds.Contains(e.ID)));
       await SaveAsync();
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
