using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderResultRepositoryDb: RepositoryDb<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryDb(DbContext data) : base(data) { }

  }
}
