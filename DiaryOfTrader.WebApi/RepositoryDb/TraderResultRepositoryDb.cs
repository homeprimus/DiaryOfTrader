namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class TraderResultRepositoryDb: RepositoryDb<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryDb(DbContext data) : base(data) { }

  }
}
