
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class TrendRepositoryDb: RepositoryDb<Trend>, ITrendRepository
  {
    public TrendRepositoryDb(DbContext data) : base(data) { }
  }
}
