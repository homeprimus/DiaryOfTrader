// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader
{
  partial class RibbonMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonMain));
      ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
      bbtExchamge = new DevExpress.XtraBars.BarButtonItem();
      barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
      bbtSymbol = new DevExpress.XtraBars.BarButtonItem();
      bbtSession = new DevExpress.XtraBars.BarButtonItem();
      bbtTimeFrame = new DevExpress.XtraBars.BarButtonItem();
      bbtResult = new DevExpress.XtraBars.BarButtonItem();
      bbtTrend = new DevExpress.XtraBars.BarButtonItem();
      bbtWallet = new DevExpress.XtraBars.BarButtonItem();
      bbtCalendar = new DevExpress.XtraBars.BarButtonItem();
      bbiMarketReview = new DevExpress.XtraBars.BarButtonItem();
      bbiDiary = new DevExpress.XtraBars.BarButtonItem();
      barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
      bbtMarket = new DevExpress.XtraBars.BarButtonItem();
      bbiNewDiary = new DevExpress.XtraBars.BarButtonItem();
      rbpGenaral = new DevExpress.XtraBars.Ribbon.RibbonPage();
      rbpgMarket = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpgMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpgCalendar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpgDictionary = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpАnalytics = new DevExpress.XtraBars.Ribbon.RibbonPage();
      rbpgReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
      panel1 = new Components.Panel();
      nbMain = new DevExpress.XtraNavBar.NavBarControl();
      navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
      navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
      navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
      splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
      pnlCenter = new Panel();
      tcMain = new Components.TabControl();
      tpMarket = new DevExpress.XtraTab.XtraTabPage();
      tcMarket = new Components.TabControl();
      xtpFirst = new DevExpress.XtraTab.XtraTabPage();
      tpMarketReview = new DevExpress.XtraTab.XtraTabPage();
      tpDiary = new DevExpress.XtraTab.XtraTabPage();
      pnlDiary = new Panel();
      diaryGrid = new EditControls.Entity.DiaryGrid();
      pnlMarketReview = new Panel();
      ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
      ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nbMain).BeginInit();
      pnlCenter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)tcMain).BeginInit();
      tcMain.SuspendLayout();
      tpMarket.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)tcMarket).BeginInit();
      tcMarket.SuspendLayout();
      tpMarketReview.SuspendLayout();
      tpDiary.SuspendLayout();
      pnlDiary.SuspendLayout();
      SuspendLayout();
      // 
      // ribbon
      // 
      ribbon.ExpandCollapseItem.Id = 0;
      ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, bbtExchamge, barButtonItem2, bbtSymbol, bbtSession, bbtTimeFrame, bbtResult, bbtTrend, bbtWallet, bbtCalendar, bbiMarketReview, bbiDiary, barButtonItem3, bbtMarket, bbiNewDiary });
      ribbon.Location = new Point(0, 0);
      ribbon.MaxItemId = 15;
      ribbon.Name = "ribbon";
      ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rbpGenaral, rbpАnalytics });
      ribbon.Size = new Size(1025, 158);
      ribbon.StatusBar = ribbonStatusBar;
      // 
      // bbtExchamge
      // 
      bbtExchamge.Caption = "Брокер";
      bbtExchamge.Id = 1;
      bbtExchamge.ImageOptions.Image = (Image)resources.GetObject("bbtExchamge.ImageOptions.Image");
      bbtExchamge.ImageOptions.LargeImage = (Image)resources.GetObject("bbtExchamge.ImageOptions.LargeImage");
      bbtExchamge.Name = "bbtExchamge";
      bbtExchamge.ItemClick += bbtExchamge_ItemClick;
      // 
      // barButtonItem2
      // 
      barButtonItem2.Caption = "barButtonItem2";
      barButtonItem2.Id = 2;
      barButtonItem2.Name = "barButtonItem2";
      // 
      // bbtSymbol
      // 
      bbtSymbol.AllowAllUp = true;
      bbtSymbol.Caption = "Инструмент";
      bbtSymbol.Id = 3;
      bbtSymbol.ImageOptions.Image = (Image)resources.GetObject("bbtSymbol.ImageOptions.Image");
      bbtSymbol.ImageOptions.LargeImage = (Image)resources.GetObject("bbtSymbol.ImageOptions.LargeImage");
      bbtSymbol.Name = "bbtSymbol";
      bbtSymbol.ItemClick += bbtSymbol_ItemClick;
      // 
      // bbtSession
      // 
      bbtSession.Caption = "Торговая сессия";
      bbtSession.Id = 4;
      bbtSession.ImageOptions.Image = (Image)resources.GetObject("bbtSession.ImageOptions.Image");
      bbtSession.ImageOptions.LargeImage = (Image)resources.GetObject("bbtSession.ImageOptions.LargeImage");
      bbtSession.Name = "bbtSession";
      bbtSession.ItemClick += bbtSession_ItemClick;
      // 
      // bbtTimeFrame
      // 
      bbtTimeFrame.Caption = "Тайм фрейм";
      bbtTimeFrame.Id = 5;
      bbtTimeFrame.ImageOptions.Image = (Image)resources.GetObject("bbtTimeFrame.ImageOptions.Image");
      bbtTimeFrame.ImageOptions.LargeImage = (Image)resources.GetObject("bbtTimeFrame.ImageOptions.LargeImage");
      bbtTimeFrame.Name = "bbtTimeFrame";
      bbtTimeFrame.ItemClick += bbtTimeFrame_ItemClick;
      // 
      // bbtResult
      // 
      bbtResult.Caption = "Результат сделки";
      bbtResult.Id = 6;
      bbtResult.ImageOptions.Image = (Image)resources.GetObject("bbtResult.ImageOptions.Image");
      bbtResult.ImageOptions.LargeImage = (Image)resources.GetObject("bbtResult.ImageOptions.LargeImage");
      bbtResult.Name = "bbtResult";
      bbtResult.ItemClick += bbtResult_ItemClick;
      // 
      // bbtTrend
      // 
      bbtTrend.Caption = "Тренд";
      bbtTrend.Id = 7;
      bbtTrend.ImageOptions.Image = (Image)resources.GetObject("bbtTrend.ImageOptions.Image");
      bbtTrend.ImageOptions.LargeImage = (Image)resources.GetObject("bbtTrend.ImageOptions.LargeImage");
      bbtTrend.Name = "bbtTrend";
      bbtTrend.ItemClick += bbtTrend_ItemClick;
      // 
      // bbtWallet
      // 
      bbtWallet.Caption = "Тип кошелька";
      bbtWallet.Id = 8;
      bbtWallet.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtWallet.ImageOptions.SvgImage");
      bbtWallet.Name = "bbtWallet";
      bbtWallet.ItemClick += bbtWallet_ItemClick;
      // 
      // bbtCalendar
      // 
      bbtCalendar.Caption = "Экономический календарь";
      bbtCalendar.Id = 9;
      bbtCalendar.ImageOptions.Image = (Image)resources.GetObject("bbtCalendar.ImageOptions.Image");
      bbtCalendar.ImageOptions.LargeImage = (Image)resources.GetObject("bbtCalendar.ImageOptions.LargeImage");
      bbtCalendar.Name = "bbtCalendar";
      bbtCalendar.ItemClick += bbtCalendar_ItemClick;
      // 
      // bbiMarketReview
      // 
      bbiMarketReview.Caption = "Анализ рынка";
      bbiMarketReview.Id = 10;
      bbiMarketReview.ImageOptions.Image = (Image)resources.GetObject("bbiMarketReview.ImageOptions.Image");
      bbiMarketReview.ImageOptions.LargeImage = (Image)resources.GetObject("bbiMarketReview.ImageOptions.LargeImage");
      bbiMarketReview.Name = "bbiMarketReview";
      bbiMarketReview.ItemClick += bbiMarketReview_ItemClick;
      // 
      // bbiDiary
      // 
      bbiDiary.Caption = "Журнал сделок";
      bbiDiary.Id = 11;
      bbiDiary.ImageOptions.Image = (Image)resources.GetObject("bbiDiary.ImageOptions.Image");
      bbiDiary.ImageOptions.LargeImage = (Image)resources.GetObject("bbiDiary.ImageOptions.LargeImage");
      bbiDiary.Name = "bbiDiary";
      bbiDiary.ItemClick += barButtonItem1_ItemClick;
      // 
      // barButtonItem3
      // 
      barButtonItem3.Caption = "Торговая стратегия";
      barButtonItem3.Id = 12;
      barButtonItem3.ImageOptions.Image = (Image)resources.GetObject("barButtonItem3.ImageOptions.Image");
      barButtonItem3.ImageOptions.LargeImage = (Image)resources.GetObject("barButtonItem3.ImageOptions.LargeImage");
      barButtonItem3.Name = "barButtonItem3";
      barButtonItem3.ItemClick += barButtonItem3_ItemClick;
      // 
      // bbtMarket
      // 
      bbtMarket.Caption = "Рынок";
      bbtMarket.Id = 13;
      bbtMarket.ImageOptions.Image = (Image)resources.GetObject("bbtMarket.ImageOptions.Image");
      bbtMarket.ImageOptions.LargeImage = (Image)resources.GetObject("bbtMarket.ImageOptions.LargeImage");
      bbtMarket.Name = "bbtMarket";
      bbtMarket.ItemClick += bbtMarket_ItemClick;
      // 
      // bbiNewDiary
      // 
      bbiNewDiary.Caption = "Новая сделка";
      bbiNewDiary.Id = 14;
      bbiNewDiary.ImageOptions.Image = (Image)resources.GetObject("bbiNewDiary.ImageOptions.Image");
      bbiNewDiary.ImageOptions.LargeImage = (Image)resources.GetObject("bbiNewDiary.ImageOptions.LargeImage");
      bbiNewDiary.Name = "bbiNewDiary";
      // 
      // rbpGenaral
      // 
      rbpGenaral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rbpgMarket, rbpgMain, rbpgCalendar, rbpgDictionary });
      rbpGenaral.Name = "rbpGenaral";
      rbpGenaral.Text = "Главная";
      // 
      // rbpgMarket
      // 
      rbpgMarket.ItemLinks.Add(bbtMarket);
      rbpgMarket.ItemLinks.Add(bbiNewDiary);
      rbpgMarket.Name = "rbpgMarket";
      rbpgMarket.Text = "Рынок";
      // 
      // rbpgMain
      // 
      rbpgMain.ItemLinks.Add(bbiDiary);
      rbpgMain.ItemLinks.Add(bbiMarketReview);
      rbpgMain.Name = "rbpgMain";
      rbpgMain.Text = "Основные";
      // 
      // rbpgCalendar
      // 
      rbpgCalendar.ItemLinks.Add(bbtCalendar);
      rbpgCalendar.Name = "rbpgCalendar";
      rbpgCalendar.Text = "Календарь";
      // 
      // rbpgDictionary
      // 
      rbpgDictionary.ItemLinks.Add(bbtExchamge);
      rbpgDictionary.ItemLinks.Add(bbtSymbol);
      rbpgDictionary.ItemLinks.Add(bbtSession);
      rbpgDictionary.ItemLinks.Add(barButtonItem3);
      rbpgDictionary.ItemLinks.Add(bbtTimeFrame);
      rbpgDictionary.ItemLinks.Add(bbtTrend);
      rbpgDictionary.ItemLinks.Add(bbtResult);
      rbpgDictionary.ItemLinks.Add(bbtWallet);
      rbpgDictionary.Name = "rbpgDictionary";
      rbpgDictionary.Text = "Справочники";
      // 
      // rbpАnalytics
      // 
      rbpАnalytics.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rbpgReports });
      rbpАnalytics.Name = "rbpАnalytics";
      rbpАnalytics.Text = "Аналитика";
      // 
      // rbpgReports
      // 
      rbpgReports.Name = "rbpgReports";
      rbpgReports.Text = "Отчеты";
      // 
      // ribbonStatusBar
      // 
      ribbonStatusBar.Location = new Point(0, 589);
      ribbonStatusBar.Name = "ribbonStatusBar";
      ribbonStatusBar.Ribbon = ribbon;
      ribbonStatusBar.Size = new Size(1025, 24);
      // 
      // panel1
      // 
      panel1.Appearance.BackColor = Color.Transparent;
      panel1.Appearance.Options.UseBackColor = true;
      panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      panel1.Controls.Add(nbMain);
      panel1.Dock = DockStyle.Left;
      panel1.Location = new Point(0, 158);
      panel1.Name = "panel1";
      panel1.Size = new Size(200, 431);
      panel1.TabIndex = 9;
      // 
      // nbMain
      // 
      nbMain.ActiveGroup = navBarGroup1;
      nbMain.Dock = DockStyle.Fill;
      nbMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { navBarGroup1, navBarGroup2 });
      nbMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { navBarItem1 });
      nbMain.Location = new Point(0, 0);
      nbMain.Name = "nbMain";
      nbMain.OptionsNavPane.ExpandedWidth = 200;
      nbMain.Size = new Size(200, 431);
      nbMain.TabIndex = 3;
      nbMain.Text = "navBarControl1";
      // 
      // navBarGroup1
      // 
      navBarGroup1.Caption = "navBarGroup1";
      navBarGroup1.Expanded = true;
      navBarGroup1.Name = "navBarGroup1";
      // 
      // navBarGroup2
      // 
      navBarGroup2.Caption = "navBarGroup2";
      navBarGroup2.Expanded = true;
      navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(navBarItem1) });
      navBarGroup2.Name = "navBarGroup2";
      // 
      // navBarItem1
      // 
      navBarItem1.Caption = "navBarItem1";
      navBarItem1.Name = "navBarItem1";
      // 
      // splitterControl1
      // 
      splitterControl1.Location = new Point(200, 158);
      splitterControl1.Name = "splitterControl1";
      splitterControl1.Size = new Size(10, 431);
      splitterControl1.TabIndex = 10;
      splitterControl1.TabStop = false;
      // 
      // pnlCenter
      // 
      pnlCenter.Controls.Add(tcMain);
      pnlCenter.Dock = DockStyle.Fill;
      pnlCenter.Location = new Point(210, 158);
      pnlCenter.Name = "pnlCenter";
      pnlCenter.Size = new Size(815, 431);
      pnlCenter.TabIndex = 11;
      // 
      // tcMain
      // 
      tcMain.Appearance.BackColor = Color.Transparent;
      tcMain.Appearance.Options.UseBackColor = true;
      tcMain.Dock = DockStyle.Fill;
      tcMain.Location = new Point(0, 0);
      tcMain.Name = "tcMain";
      tcMain.SelectedTabPage = tpMarketReview;
      tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
      tcMain.Size = new Size(815, 431);
      tcMain.TabIndex = 0;
      tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tpMarket, tpMarketReview, tpDiary });
      // 
      // tpMarket
      // 
      tpMarket.Controls.Add(tcMarket);
      tpMarket.Name = "tpMarket";
      tpMarket.Size = new Size(813, 429);
      tpMarket.Text = "Рынок";
      // 
      // tcMarket
      // 
      tcMarket.Appearance.BackColor = Color.Transparent;
      tcMarket.Appearance.Options.UseBackColor = true;
      tcMarket.Dock = DockStyle.Fill;
      tcMarket.Location = new Point(0, 0);
      tcMarket.Name = "tcMarket";
      tcMarket.SelectedTabPage = xtpFirst;
      tcMarket.Size = new Size(813, 429);
      tcMarket.TabIndex = 0;
      tcMarket.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtpFirst });
      // 
      // xtpFirst
      // 
      xtpFirst.Name = "xtpFirst";
      xtpFirst.Size = new Size(811, 404);
      xtpFirst.Text = "BTCUSDT";
      // 
      // tpMarketReview
      // 
      tpMarketReview.Controls.Add(pnlMarketReview);
      tpMarketReview.Name = "tpMarketReview";
      tpMarketReview.Size = new Size(813, 429);
      tpMarketReview.Text = "Журнал сделок";
      // 
      // tpDiary
      // 
      tpDiary.Controls.Add(pnlDiary);
      tpDiary.Name = "tpDiary";
      tpDiary.Size = new Size(813, 429);
      tpDiary.Text = "Обзор рынка";
      // 
      // pnlDiary
      // 
      pnlDiary.Controls.Add(diaryGrid);
      pnlDiary.Dock = DockStyle.Fill;
      pnlDiary.Location = new Point(0, 0);
      pnlDiary.Name = "pnlDiary";
      pnlDiary.Padding = new Padding(3);
      pnlDiary.Size = new Size(813, 429);
      pnlDiary.TabIndex = 0;
      // 
      // diaryGrid
      // 
      diaryGrid.Appearance.BackColor = Color.Transparent;
      diaryGrid.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      diaryGrid.Appearance.Options.UseBackColor = true;
      diaryGrid.Appearance.Options.UseFont = true;
      diaryGrid.Dock = DockStyle.Fill;
      diaryGrid.Location = new Point(3, 3);
      diaryGrid.Name = "diaryGrid";
      diaryGrid.Size = new Size(807, 423);
      diaryGrid.TabIndex = 0;
      // 
      // pnlMarketReview
      // 
      pnlMarketReview.Dock = DockStyle.Fill;
      pnlMarketReview.Location = new Point(0, 0);
      pnlMarketReview.Name = "pnlMarketReview";
      pnlMarketReview.Padding = new Padding(3);
      pnlMarketReview.Size = new Size(813, 429);
      pnlMarketReview.TabIndex = 0;
      // 
      // RibbonMain
      // 
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1025, 613);
      Controls.Add(pnlCenter);
      Controls.Add(splitterControl1);
      Controls.Add(panel1);
      Controls.Add(ribbonStatusBar);
      Controls.Add(ribbon);
      IconOptions.Icon = (Icon)resources.GetObject("RibbonMain.IconOptions.Icon");
      Name = "RibbonMain";
      Ribbon = ribbon;
      StatusBar = ribbonStatusBar;
      Text = "Дневник трейдера";
      ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
      ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
      panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)nbMain).EndInit();
      pnlCenter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)tcMain).EndInit();
      tcMain.ResumeLayout(false);
      tpMarket.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)tcMarket).EndInit();
      tcMarket.ResumeLayout(false);
      tpMarketReview.ResumeLayout(false);
      tpDiary.ResumeLayout(false);
      pnlDiary.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
    private DevExpress.XtraBars.Ribbon.RibbonPage rbpGenaral;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgMain;
    private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgDictionary;
    private DevExpress.XtraBars.BarButtonItem bbtExchamge;
    private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    private DevExpress.XtraBars.BarButtonItem bbtSymbol;
    private DevExpress.XtraBars.BarButtonItem bbtSession;
    private DevExpress.XtraBars.BarButtonItem bbtTimeFrame;
    private DevExpress.XtraBars.BarButtonItem bbtResult;
    private DevExpress.XtraBars.Ribbon.RibbonPage rbpАnalytics;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgReports;
    private DevExpress.XtraBars.BarButtonItem bbtTrend;
    private DevExpress.XtraBars.BarButtonItem bbtWallet;
    private DevExpress.XtraBars.BarButtonItem bbtCalendar;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgCalendar;
    private DevExpress.XtraBars.BarButtonItem bbiMarketReview;
    private DevExpress.XtraBars.BarButtonItem bbiDiary;
    private Components.Panel panel1;
    private DevExpress.XtraNavBar.NavBarControl nbMain;
    private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
    private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
    private DevExpress.XtraNavBar.NavBarItem navBarItem1;
    private DevExpress.XtraEditors.SplitterControl splitterControl1;
    private Panel pnlCenter;
    private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    private DevExpress.XtraBars.BarButtonItem bbtMarket;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgMarket;
    private Components.TabControl tcMain;
    private DevExpress.XtraTab.XtraTabPage tpMarket;
    private DevExpress.XtraTab.XtraTabPage tpMarketReview;
    private DevExpress.XtraTab.XtraTabPage tpDiary;
    private Components.TabControl tcMarket;
    private DevExpress.XtraTab.XtraTabPage xtpFirst;
    private DevExpress.XtraBars.BarButtonItem bbiNewDiary;
    private Panel pnlDiary;
    private EditControls.Entity.DiaryGrid diaryGrid;
    private Panel pnlMarketReview;
  }
}
