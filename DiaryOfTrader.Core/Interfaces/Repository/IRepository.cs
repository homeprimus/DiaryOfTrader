namespace DiaryOfTrader.Core.Interfaces.Repository
{
  public interface IRepository<TEntity> : IDisposable

  {
    Task<List<TEntity?>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(object[] pattern);
    Task<TEntity?> GetByIdAsync(long entityId);
    Task InsertAsync(List<TEntity> entities);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(List<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(List<long> entityIds);
    Task DeleteAsync(long entityId);

    Task SaveAsync();
  }
}
