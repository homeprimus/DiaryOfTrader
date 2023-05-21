using DiaryOfTrader.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader.Core.Data
{
  public class DiaryOfTraderCtx : DbContext
  {
    public DbSet<Diary> Diary { get; set; }
    public DbSet<ScreenShot> ScreenShot { get; set; }
    public DbSet<TradeSession> TradeSession { get; set; }
    public DbSet<TimeFrame> TimeFrame { get; set; }


    public DiaryOfTraderCtx()
    {

      Database.EnsureDeleted();
      Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=DiaryOfTrader.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Diary>().UseTpcMappingStrategy();
    }
  }
}

