
namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class RepositoryDb<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity.Entity
  {
    #region fields
    private readonly DbContext _data;
    private readonly DbSet<TEntity> _entity;
    #endregion

    public RepositoryDb(DbContext data)
    {
      _data = data;
      _entity = _data.Set<TEntity>();
    }

    protected DbContext Data { get { return _data; } }
    protected DbSet<TEntity> Entity { get { return _entity; } }

    public virtual async Task<List<TEntity?>> GetAllAsync()
    {
      return await _entity.ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      return await _entity.Where(e => e.Name.Contains(pattern[0].ToString()!)).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int entryId) 
    {
      return await _entity.Where(e => e.ID == (long)entryId).FirstOrDefaultAsync();
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
      _entity.Add(entity);
      await SaveAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
      _entity.Update(entity);
      await SaveAsync();
    }

    public async Task DeleteAsync(int entityId)
    {
      var entity = await _entity.FindAsync(new object[] { entityId });
      if (entity != null)
      {
        _entity.Remove(entity);
        await SaveAsync();
      }
    }

    public async Task InsertRangeAsync(TEntity[] entities)
    {
      await _entity.AddRangeAsync(entities);
      await SaveAsync();
    }

    public async Task UpdateRangeAsync(TEntity[] entities)
    {
      _entity.UpdateRange(entities);
      await SaveAsync();
    }

    public async Task DeleteRangeAsync(long[] entityIds)
    {
      var list = new List<long>(entityIds);
      _entity.RemoveRange(_entity.Where(e => list.Contains(e.ID)));
      await SaveAsync();
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
