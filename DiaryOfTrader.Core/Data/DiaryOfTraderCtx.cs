using DiaryOfTrader.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader.Core.Data
{

  public class DiaryOfTraderCtx : DbContext
  {
    private const string DIARY_OF_TRADER = "DiaryOfTrader";
    public DbSet<Diary> Diary { get; set; }
    public DbSet<ScreenShot> ScreenShot { get; set; }
    public DbSet<TradeSession> TradeSession { get; set; }
    public DbSet<TimeFrame> TimeFrame { get; set; }
    public DbSet<Result> TimeResult { get; set; }
    public DbSet<Sumbol> Sumbol { get; set; }
    public DbSet<Entity.Exchange> Exchange { get; set; }


    public DiaryOfTraderCtx()
    {

      Database.EnsureDeleted();
      Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DIARY_OF_TRADER + "\\Data");
      optionsBuilder.UseSqlite("Data Source=" + DIARY_OF_TRADER + ".db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Diary>().UseTpcMappingStrategy();
    }
  }
}

