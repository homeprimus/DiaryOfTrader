using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Entity.Economic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Sqlite.Migrations.Internal;

namespace DiaryOfTrader.Core.Data
{

  public sealed class DiaryOfTraderCtx : DbContext
  {
    private const string DIARY_OF_TRADER = "DiaryOfTrader";

    internal class HistoryRepository : SqliteHistoryRepository
    {
      public HistoryRepository(HistoryRepositoryDependencies dependencies) :
        base(dependencies)
      {
      }
      protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
      {
        base.ConfigureTable(history);
        //history.Property(h => h.MigrationId).HasColumnName("Id");
        //history.Property(h => h.ProductVersion).HasColumnName("Version");
        //history.Property<string>("Custom").HasMaxLength(300).IsRequired();
      }
    }

    public static string RootFolder
    {
      get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DIARY_OF_TRADER); }
    }

    private string DataSource()
    {
      var folder = Path.Combine(RootFolder, "Data");
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
       *
       * Remove-migration
       */

      Database.Migrate();
      if (Frame != null && !Frame.Any())
      {
        var upData = new DataInitializer(this);
        upData.Update();
      }

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Pooling=True;Data Source=" + DataSource())
        .ReplaceService<IHistoryRepository, HistoryRepository>()
        ; 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      base.OnModelCreating(modelBuilder);
      
      modelBuilder.Ignore<Element>();
      modelBuilder.Ignore<Entity.Entity>();

      modelBuilder.Entity<ScreenShot>().UseTpcMappingStrategy();
      modelBuilder.Entity<ScreenShot>().Property(b => b.ID).ValueGeneratedOnAdd();

      modelBuilder.Entity<Wallet>(WalletConfigure);
      modelBuilder.Entity<Symbol>(SymbolConfigure);
      modelBuilder.Entity<TraderExchange>(ExchangeConfigure);
      modelBuilder.Entity<TraderRegion>(TraderRegionConfigure);
      modelBuilder.Entity<TraderSession>(TraderSessionConfigure);
      modelBuilder.Entity<TimeFrame>(TimeFrameConfigure);
      modelBuilder.Entity<Trend>(TrendConfigure);
      modelBuilder.Entity<TraderResult>(TraderResultConfigure);
      modelBuilder.Entity<Diary>(DiaryConfigure);
      modelBuilder.Entity<MarketReview>(MarketReviewConfigure);
      modelBuilder.Entity<EconomicSchedule>(EconomicScheduleConfigure);
      modelBuilder.Entity<EconomicEvent>(EconomicEventConfigure);

    }

    #region Configure

    #region Symbol
    private void EconomicScheduleConfigure(EntityTypeBuilder<EconomicSchedule> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    private void EconomicEventConfigure(EntityTypeBuilder<EconomicEvent> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    private void SymbolConfigure(EntityTypeBuilder<Symbol> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region Wallet
    private void WalletConfigure(EntityTypeBuilder<Wallet> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region Exchange
    private void ExchangeConfigure(EntityTypeBuilder<TraderExchange> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region TraderSession
    private void TraderSessionConfigure(EntityTypeBuilder<TraderSession> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region TraderRegion
    private void TraderRegionConfigure(EntityTypeBuilder<TraderRegion> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region Trend
    private void TrendConfigure(EntityTypeBuilder<Trend> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region TimeFrame
    private void TimeFrameConfigure(EntityTypeBuilder<TimeFrame> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region TraderResult
    private void TraderResultConfigure(EntityTypeBuilder<TraderResult> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region MarketReview
    private void MarketReviewConfigure(EntityTypeBuilder<MarketReview> builder)
    {
      builder.UseTpcMappingStrategy();
      builder.Ignore(b => b.Order);
      builder.Property(b => b.ID).ValueGeneratedOnAdd();
    }
    #endregion
    #region Diary
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
    #endregion

    #endregion

    public DbSet<ScreenShot> ScreenShot { get; set; }
    public DbSet<TraderSession> Session { get; set; }
    public DbSet<TimeFrame> Frame { get; set; }
    public DbSet<TraderResult> Result { get; set; }
    public DbSet<Symbol> Symbol { get; set; }
    public DbSet<TraderExchange> Exchange { get; set; }
    public DbSet<Trend> Trend { get; set; }
    public DbSet<TraderRegion> Region { get; set; }
    public DbSet<Wallet> Wallet { get; set; }
    public DbSet<Diary> Diary { get; set; }
    public DbSet<MarketReview> MarketReview { get; set; }
    public DbSet<EconomicSchedule> EconomicSchedule { get; set; }
    public DbSet<EconomicEvent> EconomicEvent { get; set; }
  }
}

