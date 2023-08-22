
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class TraderSessionRepositoryDb: RepositoryDb<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryDb(DbContext data) : base(data) { }
  }
}
