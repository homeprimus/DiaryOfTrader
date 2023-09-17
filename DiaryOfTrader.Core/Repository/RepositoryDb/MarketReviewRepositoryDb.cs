
namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewRepositoryDb : RepositoryDb<MarketReview>, IMarketReviewRepository
  {
    public MarketReviewRepositoryDb(DbContext data) : base(data)
    {
    }

    public override async Task<List<MarketReview?>> GetAllAsync()
    {
      _ = Data.Frame.ToList();
      _ = Data.Trend.ToList();
      _ = Data.ScreenShot.ToList();
      return await Entity
        .Include(p=>p.Symbol)
        .Include(p=>p.Exchange)
        .Include(p => p.Frames)
        
        .ToListAsync();
    }

  }
}
