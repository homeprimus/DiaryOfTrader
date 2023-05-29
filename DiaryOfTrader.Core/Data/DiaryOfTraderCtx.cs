using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Emit;
using System.Xml.Linq;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiaryOfTrader.Core.Data
{

  public class DiaryOfTraderCtx : DbContext
  {
    private const string DIARY_OF_TRADER = "DiaryOfTrader";

    private string DataSource()
    {
      var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DIARY_OF_TRADER + "\\Data");
      if (!Directory.Exists(folder))
      {
        Directory.CreateDirectory(folder);
      }
      return Path.Combine(folder, DIARY_OF_TRADER + ".db");
    }
    public DiaryOfTraderCtx()
    {
      /*
       * После изменения структуры базы выполнить миграцию = Юперейдем в Visual Studio к окну Package Manager Console.
       * Вначале введем команду
       * Add-Migration InitialCreate
       * Название миграции произвольное. В данном случае это InitialCreate. Нажмем на Enter для создания миграции.
       */
      Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=" + DataSource());
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Ignore<Element>();
      modelBuilder.Ignore<Entity.Entity>();


      modelBuilder.Entity<ScreenShot>().UseTpcMappingStrategy();
      modelBuilder.Entity<ScreenShot>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<TraderRegion>().UseTpcMappingStrategy();
      modelBuilder.Entity<TraderRegion>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<TraderSession>().UseTpcMappingStrategy();
      modelBuilder.Entity<TraderSession>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<TimeFrame>().UseTpcMappingStrategy();
      modelBuilder.Entity<TimeFrame>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<Symbol>().UseTpcMappingStrategy();
      modelBuilder.Entity<Symbol>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<Entity.Exchange>().UseTpcMappingStrategy();
      modelBuilder.Entity<Entity.Exchange>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<Trend>().UseTpcMappingStrategy();
      modelBuilder.Entity<Trend>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<TraderResult>(TraderResultConfigure);
      modelBuilder.Entity<Diary>(DiaryConfigure);
      modelBuilder.Entity<MarketReview>(MarketReviewConfigure);

    }

    private void TraderResultConfigure(EntityTypeBuilder<TraderResult> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
      //builder.HasData(
      //  new TraderResult[]
      //  {
      //    new TraderResult { ID=1, Name=Resources.TraderResultSuccess, Description= ""},
      //    new TraderResult { ID=2, Name=Resources.TraderResultNone, Description = ""},
      //    new TraderResult { ID=3, Name=Resources.TraderResultLoss, Description = ""}
      //  });

    }

    private void MarketReviewConfigure(EntityTypeBuilder<MarketReview> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Ignore(b => b.Order);
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }

    private void DiaryConfigure(EntityTypeBuilder<Diary> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
      builder.Ignore(b => b.Order);
      // ** не используется, оставлю для примера **
      // первичный ключ
      //builder.HasKey(u => u.ID);
      //builder.HasKey(u => new { u.ID, u.Date });
      // - альтернативный ключ
      //builder.HasAlternateKey(u => new { u.Date });
      // - индексы
      //builder.HasIndex(u => u.Symbol).IsUnique();
      // - Также можно определить индексы сразу для нескольких свойств:
      //builder
      //  .HasIndex(u => new { u.Date, u.Symbol })
      //  .HasDatabaseName("DateSymbol");
      // - Фильтры индексов
      //builder
      //  .HasIndex(u => u.Symbol)
      //  .HasFilter("[Symbol] IS NOT NULL"); ;
    }

    public DbSet<Diary> Diary { get; set; }
    public DbSet<ScreenShot> ScreenShot { get; set; }
    public DbSet<TraderSession> Session { get; set; }
    public DbSet<TimeFrame> Frame { get; set; }
    public DbSet<TraderResult> Result { get; set; }
    public DbSet<Symbol> Symbol { get; set; }
    public DbSet<Entity.Exchange> Exchange { get; set; }
    public DbSet<Trend> Trend { get; set; }
    public DbSet<TraderRegion> Region { get; set; }
    public DbSet<MarketReview> MarketReview { get; set; }
    

  }
}

