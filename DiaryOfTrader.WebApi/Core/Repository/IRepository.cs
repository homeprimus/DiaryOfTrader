namespace DiaryOfTrader.WebApi.Core.Repository
{
  public interface IRepository<TEntity> : IDisposable

  {
    Task<List<TEntity?>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(object[] pattern);
    Task<TEntity?> GetByIdAsync(int entityId);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int entityId);
    Task SaveAsync();
  }
}
