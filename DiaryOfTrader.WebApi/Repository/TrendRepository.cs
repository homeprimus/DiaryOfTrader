
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TrendRepository: Repository<Trend>, ITrendRepository
  {
    public TrendRepository(DbContext data) : base(data) { }
  }
}
