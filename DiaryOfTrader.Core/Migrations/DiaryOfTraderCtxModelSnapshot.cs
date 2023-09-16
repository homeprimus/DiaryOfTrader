﻿// <auto-generated />
using System;
using DiaryOfTrader.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiaryOfTrader.Core.Migrations
{
    [DbContext(typeof(DiaryOfTraderCtx))]
    partial class DiaryOfTraderCtxModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Diary", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Emotions")
                        .HasColumnType("TEXT");

                    b.Property<long>("EnteredID")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ExchangeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ReviewID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SymbolID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TraderResultID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WalletID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EnteredID");

                    b.HasIndex("ExchangeID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("SymbolID");

                    b.HasIndex("TraderResultID");

                    b.HasIndex("WalletID");

                    b.ToTable("Diary");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Economic.EconomicEvent", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalRef")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceRef")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("EconomicEvent");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Economic.EconomicSchedule", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("DiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Factual")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HRef")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Importance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Previous")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prognosis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("DiaryID");

                    b.HasIndex("EventID");

                    b.ToTable("EconomicSchedule");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.MarketReview", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long>("ExchangeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("SymbolID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ExchangeID");

                    b.HasIndex("SymbolID");

                    b.ToTable("MarketReview");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.MarketReviewTimeFrame", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long>("FrameID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MarketID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ScreenShotID")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TrendID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FrameID");

                    b.HasIndex("MarketID");

                    b.HasIndex("ScreenShotID");

                    b.HasIndex("TrendID");

                    b.ToTable("MarketReviewTimeFrame");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.ScreenShot", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long?>("DiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("DiaryID");

                    b.ToTable("ScreenShot");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Symbol", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Symbol");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TimeFrame", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Frame");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Trader", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Trader");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderExchange", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Exchange");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderRegion", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Region");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderResult", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Result");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderSession", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SummerFinished")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SummerStarting")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WinterFinished")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WinterStarting")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("RegionID");

                    b.ToTable("Session");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Trend", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Trend");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Wallet", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Wallet");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("SymbolTraderExchange", b =>
                {
                    b.Property<long>("ExchangesID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SymbolsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExchangesID", "SymbolsID");

                    b.HasIndex("SymbolsID");

                    b.ToTable("ExchangeSymbol", (string)null);
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Diary", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.TimeFrame", "Entered")
                        .WithMany()
                        .HasForeignKey("EnteredID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.TraderExchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID");

                    b.HasOne("DiaryOfTrader.Core.Entity.MarketReview", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.TraderResult", "TraderResult")
                        .WithMany()
                        .HasForeignKey("TraderResultID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entered");

                    b.Navigation("Exchange");

                    b.Navigation("Review");

                    b.Navigation("Symbol");

                    b.Navigation("TraderResult");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Economic.EconomicSchedule", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.Diary", null)
                        .WithMany("Events")
                        .HasForeignKey("DiaryID");

                    b.HasOne("DiaryOfTrader.Core.Entity.Economic.EconomicEvent", "Event")
                        .WithMany()
                        .HasForeignKey("EventID");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.MarketReview", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.TraderExchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.MarketReviewTimeFrame", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.TimeFrame", "Frame")
                        .WithMany()
                        .HasForeignKey("FrameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.MarketReview", "Market")
                        .WithMany("Frames")
                        .HasForeignKey("MarketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.ScreenShot", "ScreenShot")
                        .WithMany()
                        .HasForeignKey("ScreenShotID");

                    b.HasOne("DiaryOfTrader.Core.Entity.Trend", "Trend")
                        .WithMany()
                        .HasForeignKey("TrendID");

                    b.Navigation("Frame");

                    b.Navigation("Market");

                    b.Navigation("ScreenShot");

                    b.Navigation("Trend");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.ScreenShot", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.Diary", null)
                        .WithMany("Screenshot")
                        .HasForeignKey("DiaryID");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderSession", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.TraderRegion", "Region")
                        .WithMany("Sessions")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("SymbolTraderExchange", b =>
                {
                    b.HasOne("DiaryOfTrader.Core.Entity.TraderExchange", null)
                        .WithMany()
                        .HasForeignKey("ExchangesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiaryOfTrader.Core.Entity.Symbol", null)
                        .WithMany()
                        .HasForeignKey("SymbolsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.Diary", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Screenshot");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.MarketReview", b =>
                {
                    b.Navigation("Frames");
                });

            modelBuilder.Entity("DiaryOfTrader.Core.Entity.TraderRegion", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
