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
            migrationBuilder.CreateTable(
                name: "EconomicEvent",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    SourceRef = table.Column<string>(type: "TEXT", nullable: false),
                    LocalRef = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicEvent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Frame",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frame", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trader",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trader", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TradingStrategy",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingStrategy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trend",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trend", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionID = table.Column<long>(type: "INTEGER", nullable: false),
                    WinterStarting = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WinterFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SummerStarting = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SummerFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
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
                    ExchangesID = table.Column<long>(type: "INTEGER", nullable: false),
                    SymbolsID = table.Column<long>(type: "INTEGER", nullable: false)
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
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExchangeID = table.Column<long>(type: "INTEGER", nullable: false),
                    SymbolID = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExchangeID = table.Column<long>(type: "INTEGER", nullable: true),
                    SymbolID = table.Column<long>(type: "INTEGER", nullable: false),
                    ReviewID = table.Column<long>(type: "INTEGER", nullable: true),
                    SessionID = table.Column<long>(type: "INTEGER", nullable: true),
                    EnteredID = table.Column<long>(type: "INTEGER", nullable: false),
                    Deal = table.Column<string>(type: "TEXT", nullable: true),
                    Emotions = table.Column<string>(type: "TEXT", nullable: true),
                    WalletID = table.Column<long>(type: "INTEGER", nullable: false),
                    TraderResultID = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
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
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Importance = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Factual = table.Column<string>(type: "TEXT", nullable: false),
                    Prognosis = table.Column<string>(type: "TEXT", nullable: false),
                    Previous = table.Column<string>(type: "TEXT", nullable: false),
                    Last = table.Column<string>(type: "TEXT", nullable: false),
                    HRef = table.Column<string>(type: "TEXT", nullable: false),
                    EventID = table.Column<long>(type: "INTEGER", nullable: true),
                    DiaryID = table.Column<long>(type: "INTEGER", nullable: true)
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
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    DiaryID = table.Column<long>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true)
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
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MarketID = table.Column<long>(type: "INTEGER", nullable: false),
                    FrameID = table.Column<long>(type: "INTEGER", nullable: false),
                    TrendID = table.Column<long>(type: "INTEGER", nullable: true),
                    ScreenShotID = table.Column<long>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Trader");

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
                name: "Region");
        }
    }
}
