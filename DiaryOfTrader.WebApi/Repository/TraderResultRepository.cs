using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TraderResultRepository: Repository<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepository(DbContext data) : base(data) { }

  }
}
