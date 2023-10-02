
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

    public override async Task InsertAsync(List<MarketReview> entities)
    {
      foreach (var entity in entities)
      {
        foreach (var frame in entity.Frames)
        {
          frame.Frame = await Data.Frame.FindAsync(frame.Frame.ID);
          frame.Trend = await Data.Trend.FindAsync(frame.Trend.ID);
        }
        
        entity.Symbol = await Data.Symbol.FindAsync(entity.Symbol.ID);
        entity.Exchange = await Data.Exchange.FindAsync(entity.Exchange.ID);
        await Data.MarketReview.AddAsync(entity);
      }

      await Data.SaveChangesAsync();
    }
  }
}
