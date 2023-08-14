using DiaryOfTrader.Core.Core;

namespace DiaryOfTrader.WebApi.Core.Repository
{
  public class Repository<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity
  {
    #region fields
    private readonly DbContext _data;
    private readonly DbSet<TEntity> _entity;
    #endregion

    public Repository(DbContext data)
    {
      _data = data;
      _entity = _data.Set<TEntity>();
    }

    protected DbContext Data { get { return _data; } }
    protected DbSet<TEntity> Entity { get { return _entity; } }

    public virtual async Task<List<TEntity?>> GetAllAsync() => await _entity.ToListAsync();

    public async Task<List<TEntity>> GetAllAsync(object[] pattern)
    {
      return await _entity.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int entryId) => await _entity.FindAsync(new object[] { entryId });

    public async Task InsertAsync(TEntity entity)
    {
      _entity.Add(entity);
      await SaveAsync();
    }

    public async Task UpdateAsync(TEntity entity)
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

    public async Task SaveAsync()
    {
      await _data.SaveChangesAsync();
    }
  }
}
