using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiaryOfTrader.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "DiarySequence");

            migrationBuilder.CreateSequence(
                name: "EconomicEventSequence");

            migrationBuilder.CreateSequence(
                name: "EconomicScheduleSequence");

            migrationBuilder.CreateSequence(
                name: "MarketReviewSequence");

            migrationBuilder.CreateSequence(
                name: "MarketReviewTimeFrameSequence");

            migrationBuilder.CreateSequence(
                name: "ScreenShotSequence");

            migrationBuilder.CreateSequence(
                name: "SymbolSequence");

            migrationBuilder.CreateSequence(
                name: "TimeFrameSequence");

            migrationBuilder.CreateSequence(
                name: "TraderExchangeSequence");

            migrationBuilder.CreateSequence(
                name: "TraderRegionSequence");

            migrationBuilder.CreateSequence(
                name: "TraderResultSequence");

            migrationBuilder.CreateSequence(
                name: "TraderSequence");

            migrationBuilder.CreateSequence(
                name: "TraderSessionSequence");

            migrationBuilder.CreateSequence(
                name: "TradingStrategySequence");

            migrationBuilder.CreateSequence(
                name: "TrendSequence");

            migrationBuilder.CreateSequence(
                name: "WalletSequence");

            migrationBuilder.CreateTable(
                name: "EconomicEvent",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"EconomicEventSequence\"')"),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    SourceRef = table.Column<string>(type: "text", nullable: false),
                    LocalRef = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicEvent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TraderExchangeSequence\"')"),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Frame",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TimeFrameSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frame", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TraderRegionSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TraderResultSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"SymbolSequence\"')"),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trader",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TraderSequence\"')"),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trader", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TradingStrategy",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TradingStrategySequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingStrategy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trend",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TrendSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trend", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"WalletSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TraderSessionSequence\"')"),
                    RegionID = table.Column<long>(type: "bigint", nullable: false),
                    WinterStarting = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WinterFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SummerStarting = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SummerFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Session_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeSymbol",
                columns: table => new
                {
                    ExchangesID = table.Column<long>(type: "bigint", nullable: false),
                    SymbolsID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeSymbol", x => new { x.ExchangesID, x.SymbolsID });
                    table.ForeignKey(
                        name: "FK_ExchangeSymbol_Exchange_ExchangesID",
                        column: x => x.ExchangesID,
                        principalTable: "Exchange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExchangeSymbol_Symbol_SymbolsID",
                        column: x => x.SymbolsID,
                        principalTable: "Symbol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketReview",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"MarketReviewSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TraderID = table.Column<long>(type: "bigint", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExchangeID = table.Column<long>(type: "bigint", nullable: false),
                    SymbolID = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketReview", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MarketReview_Exchange_ExchangeID",
                        column: x => x.ExchangeID,
                        principalTable: "Exchange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketReview_Symbol_SymbolID",
                        column: x => x.SymbolID,
                        principalTable: "Symbol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketReview_Trader_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Trader",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"DiarySequence\"')"),
                    TraderID = table.Column<long>(type: "bigint", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExchangeID = table.Column<long>(type: "bigint", nullable: true),
                    SymbolID = table.Column<long>(type: "bigint", nullable: false),
                    ReviewID = table.Column<long>(type: "bigint", nullable: true),
                    SessionID = table.Column<long>(type: "bigint", nullable: true),
                    EnteredID = table.Column<long>(type: "bigint", nullable: false),
                    Deal = table.Column<string>(type: "text", nullable: true),
                    Emotions = table.Column<string>(type: "text", nullable: true),
                    WalletID = table.Column<long>(type: "bigint", nullable: false),
                    TraderResultID = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diary_Exchange_ExchangeID",
                        column: x => x.ExchangeID,
                        principalTable: "Exchange",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Diary_Frame_EnteredID",
                        column: x => x.EnteredID,
                        principalTable: "Frame",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diary_MarketReview_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "MarketReview",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Diary_Result_TraderResultID",
                        column: x => x.TraderResultID,
                        principalTable: "Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diary_Session_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Session",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Diary_Symbol_SymbolID",
                        column: x => x.SymbolID,
                        principalTable: "Symbol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diary_Trader_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Trader",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Diary_Wallet_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EconomicSchedule",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"EconomicScheduleSequence\"')"),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Importance = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Factual = table.Column<string>(type: "text", nullable: false),
                    Prognosis = table.Column<string>(type: "text", nullable: false),
                    Previous = table.Column<string>(type: "text", nullable: false),
                    Last = table.Column<string>(type: "text", nullable: false),
                    HRef = table.Column<string>(type: "text", nullable: false),
                    EventID = table.Column<long>(type: "bigint", nullable: true),
                    DiaryID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicSchedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EconomicSchedule_Diary_DiaryID",
                        column: x => x.DiaryID,
                        principalTable: "Diary",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EconomicSchedule_EconomicEvent_EventID",
                        column: x => x.EventID,
                        principalTable: "EconomicEvent",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ScreenShot",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"ScreenShotSequence\"')"),
                    Path = table.Column<string>(type: "text", nullable: true),
                    DiaryID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenShot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScreenShot_Diary_DiaryID",
                        column: x => x.DiaryID,
                        principalTable: "Diary",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MarketReviewTimeFrame",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"MarketReviewTimeFrameSequence\"')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MarketID = table.Column<long>(type: "bigint", nullable: false),
                    FrameID = table.Column<long>(type: "bigint", nullable: false),
                    TrendID = table.Column<long>(type: "bigint", nullable: true),
                    ScreenShotID = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketReviewTimeFrame", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MarketReviewTimeFrame_Frame_FrameID",
                        column: x => x.FrameID,
                        principalTable: "Frame",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketReviewTimeFrame_MarketReview_MarketID",
                        column: x => x.MarketID,
                        principalTable: "MarketReview",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketReviewTimeFrame_ScreenShot_ScreenShotID",
                        column: x => x.ScreenShotID,
                        principalTable: "ScreenShot",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MarketReviewTimeFrame_Trend_TrendID",
                        column: x => x.TrendID,
                        principalTable: "Trend",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diary_EnteredID",
                table: "Diary",
                column: "EnteredID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_ExchangeID",
                table: "Diary",
                column: "ExchangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_ReviewID",
                table: "Diary",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_SessionID",
                table: "Diary",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_SymbolID",
                table: "Diary",
                column: "SymbolID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_TraderID",
                table: "Diary",
                column: "TraderID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_TraderResultID",
                table: "Diary",
                column: "TraderResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_WalletID",
                table: "Diary",
                column: "WalletID");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicSchedule_DiaryID",
                table: "EconomicSchedule",
                column: "DiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicSchedule_EventID",
                table: "EconomicSchedule",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeSymbol_SymbolsID",
                table: "ExchangeSymbol",
                column: "SymbolsID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReview_ExchangeID",
                table: "MarketReview",
                column: "ExchangeID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReview_SymbolID",
                table: "MarketReview",
                column: "SymbolID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReview_TraderID",
                table: "MarketReview",
                column: "TraderID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReviewTimeFrame_FrameID",
                table: "MarketReviewTimeFrame",
                column: "FrameID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReviewTimeFrame_MarketID",
                table: "MarketReviewTimeFrame",
                column: "MarketID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReviewTimeFrame_ScreenShotID",
                table: "MarketReviewTimeFrame",
                column: "ScreenShotID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReviewTimeFrame_TrendID",
                table: "MarketReviewTimeFrame",
                column: "TrendID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShot_DiaryID",
                table: "ScreenShot",
                column: "DiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Session_RegionID",
                table: "Session",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EconomicSchedule");

            migrationBuilder.DropTable(
                name: "ExchangeSymbol");

            migrationBuilder.DropTable(
                name: "MarketReviewTimeFrame");

            migrationBuilder.DropTable(
                name: "TradingStrategy");

            migrationBuilder.DropTable(
                name: "EconomicEvent");

            migrationBuilder.DropTable(
                name: "ScreenShot");

            migrationBuilder.DropTable(
                name: "Trend");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Frame");

            migrationBuilder.DropTable(
                name: "MarketReview");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropTable(
                name: "Symbol");

            migrationBuilder.DropTable(
                name: "Trader");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropSequence(
                name: "DiarySequence");

            migrationBuilder.DropSequence(
                name: "EconomicEventSequence");

            migrationBuilder.DropSequence(
                name: "EconomicScheduleSequence");

            migrationBuilder.DropSequence(
                name: "MarketReviewSequence");

            migrationBuilder.DropSequence(
                name: "MarketReviewTimeFrameSequence");

            migrationBuilder.DropSequence(
                name: "ScreenShotSequence");

            migrationBuilder.DropSequence(
                name: "SymbolSequence");

            migrationBuilder.DropSequence(
                name: "TimeFrameSequence");

            migrationBuilder.DropSequence(
                name: "TraderExchangeSequence");

            migrationBuilder.DropSequence(
                name: "TraderRegionSequence");

            migrationBuilder.DropSequence(
                name: "TraderResultSequence");

            migrationBuilder.DropSequence(
                name: "TraderSequence");

            migrationBuilder.DropSequence(
                name: "TraderSessionSequence");

            migrationBuilder.DropSequence(
                name: "TradingStrategySequence");

            migrationBuilder.DropSequence(
                name: "TrendSequence");

            migrationBuilder.DropSequence(
                name: "WalletSequence");
        }
    }
}
