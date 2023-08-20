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
      rbpGenaral = new DevExpress.XtraBars.Ribbon.RibbonPage();
      rbpgMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpgDictionary = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpgCalendar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      rbpАnalytics = new DevExpress.XtraBars.Ribbon.RibbonPage();
      rbpgReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
      nbMain = new DevExpress.XtraNavBar.NavBarControl();
      navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
      navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
      navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
      ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nbMain).BeginInit();
      SuspendLayout();
      // 
      // ribbon
      // 
      ribbon.ExpandCollapseItem.Id = 0;
      ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, bbtExchamge, barButtonItem2, bbtSymbol, bbtSession, bbtTimeFrame, bbtResult, bbtTrend, bbtWallet, bbtCalendar });
      ribbon.Location = new Point(0, 0);
      ribbon.MaxItemId = 10;
      ribbon.Name = "ribbon";
      ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rbpGenaral, rbpАnalytics });
      ribbon.Size = new Size(964, 158);
      ribbon.StatusBar = ribbonStatusBar;
      // 
      // bbtExchamge
      // 
      bbtExchamge.Caption = "Биржи";
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
      // rbpGenaral
      // 
      rbpGenaral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rbpgMain, rbpgDictionary, rbpgCalendar });
      rbpGenaral.Name = "rbpGenaral";
      rbpGenaral.Text = "Главная";
      // 
      // rbpgMain
      // 
      rbpgMain.Name = "rbpgMain";
      rbpgMain.Text = "Основные";
      // 
      // rbpgDictionary
      // 
      rbpgDictionary.ItemLinks.Add(bbtExchamge);
      rbpgDictionary.ItemLinks.Add(bbtSymbol);
      rbpgDictionary.ItemLinks.Add(bbtSession);
      rbpgDictionary.ItemLinks.Add(bbtTimeFrame);
      rbpgDictionary.ItemLinks.Add(bbtTrend);
      rbpgDictionary.ItemLinks.Add(bbtResult);
      rbpgDictionary.ItemLinks.Add(bbtWallet);
      rbpgDictionary.Name = "rbpgDictionary";
      rbpgDictionary.Text = "Справочники";
      // 
      // rbpgCalendar
      // 
      rbpgCalendar.ItemLinks.Add(bbtCalendar);
      rbpgCalendar.Name = "rbpgCalendar";
      rbpgCalendar.Text = "Календарь";
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
      ribbonStatusBar.Location = new Point(0, 537);
      ribbonStatusBar.Name = "ribbonStatusBar";
      ribbonStatusBar.Ribbon = ribbon;
      ribbonStatusBar.Size = new Size(964, 24);
      // 
      // nbMain
      // 
      nbMain.ActiveGroup = navBarGroup1;
      nbMain.Dock = DockStyle.Left;
      nbMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { navBarGroup1, navBarGroup2 });
      nbMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { navBarItem1 });
      nbMain.Location = new Point(0, 158);
      nbMain.Name = "nbMain";
      nbMain.Size = new Size(178, 379);
      nbMain.TabIndex = 2;
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
      // RibbonMain
      // 
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(964, 561);
      Controls.Add(nbMain);
      Controls.Add(ribbonStatusBar);
      Controls.Add(ribbon);
      Name = "RibbonMain";
      Ribbon = ribbon;
      StatusBar = ribbonStatusBar;
      Text = "Дневник трейдера";
      ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
      ((System.ComponentModel.ISupportInitialize)nbMain).EndInit();
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
    private DevExpress.XtraNavBar.NavBarControl nbMain;
    private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
    private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
    private DevExpress.XtraNavBar.NavBarItem navBarItem1;
  }
}
