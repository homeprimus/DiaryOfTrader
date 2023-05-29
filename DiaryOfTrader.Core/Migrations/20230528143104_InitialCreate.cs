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
                name: "Exchange",
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
                    table.PrimaryKey("PK_Exchange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Frame",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.ID);
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
                name: "Session",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionID = table.Column<long>(type: "INTEGER", nullable: false),
                    SummerStarting = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SummerFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WinterStarting = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WinterFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
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
                name: "MarketReview",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SymbolID = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketReview", x => x.ID);
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
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExchangeID = table.Column<long>(type: "INTEGER", nullable: true),
                    SymbolID = table.Column<long>(type: "INTEGER", nullable: false),
                    EnteredID = table.Column<long>(type: "INTEGER", nullable: false),
                    TrendID = table.Column<long>(type: "INTEGER", nullable: true),
                    Monthly = table.Column<string>(type: "TEXT", nullable: false),
                    Daily = table.Column<string>(type: "TEXT", nullable: false),
                    Emotions = table.Column<string>(type: "TEXT", nullable: true),
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
                        name: "FK_Diary_Result_TraderResultID",
                        column: x => x.TraderResultID,
                        principalTable: "Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diary_Symbol_SymbolID",
                        column: x => x.SymbolID,
                        principalTable: "Symbol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diary_Trend_TrendID",
                        column: x => x.TrendID,
                        principalTable: "Trend",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ScreenShot",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    DiaryID = table.Column<long>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Diary_EnteredID",
                table: "Diary",
                column: "EnteredID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_ExchangeID",
                table: "Diary",
                column: "ExchangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_SymbolID",
                table: "Diary",
                column: "SymbolID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_TraderResultID",
                table: "Diary",
                column: "TraderResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Diary_TrendID",
                table: "Diary",
                column: "TrendID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketReview_SymbolID",
                table: "MarketReview",
                column: "SymbolID");

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
                name: "MarketReview");

            migrationBuilder.DropTable(
                name: "ScreenShot");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropTable(
                name: "Frame");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Symbol");

            migrationBuilder.DropTable(
                name: "Trend");
        }
    }
}
