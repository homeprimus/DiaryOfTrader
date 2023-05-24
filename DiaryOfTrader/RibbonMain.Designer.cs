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
      rbpGenaral = new DevExpress.XtraBars.Ribbon.RibbonPage();
      rbpgMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
      rbpgDictionary = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
      bbtExchamge = new DevExpress.XtraBars.BarButtonItem();
      barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
      bbtSymbol = new DevExpress.XtraBars.BarButtonItem();
      bbtSession = new DevExpress.XtraBars.BarButtonItem();
      bbtTimeFrame = new DevExpress.XtraBars.BarButtonItem();
      bbtResult = new DevExpress.XtraBars.BarButtonItem();
      ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
      SuspendLayout();
      // 
      // ribbon
      // 
      ribbon.ExpandCollapseItem.Id = 0;
      ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, bbtExchamge, barButtonItem2, bbtSymbol, bbtSession, bbtTimeFrame, bbtResult });
      ribbon.Location = new Point(0, 0);
      ribbon.MaxItemId = 7;
      ribbon.Name = "ribbon";
      ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rbpGenaral });
      ribbon.Size = new Size(964, 158);
      ribbon.StatusBar = ribbonStatusBar;
      // 
      // rbpGenaral
      // 
      rbpGenaral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rbpgMain, rbpgDictionary });
      rbpGenaral.Name = "rbpGenaral";
      rbpGenaral.Text = "Главная";
      // 
      // rbpgMain
      // 
      rbpgMain.Name = "rbpgMain";
      rbpgMain.Text = "Основные";
      // 
      // ribbonStatusBar
      // 
      ribbonStatusBar.Location = new Point(0, 537);
      ribbonStatusBar.Name = "ribbonStatusBar";
      ribbonStatusBar.Ribbon = ribbon;
      ribbonStatusBar.Size = new Size(964, 24);
      // 
      // rbpgDictionary
      // 
      rbpgDictionary.ItemLinks.Add(bbtExchamge);
      rbpgDictionary.ItemLinks.Add(bbtSymbol);
      rbpgDictionary.ItemLinks.Add(bbtSession);
      rbpgDictionary.ItemLinks.Add(bbtTimeFrame);
      rbpgDictionary.ItemLinks.Add(bbtResult);
      rbpgDictionary.Name = "rbpgDictionary";
      rbpgDictionary.Text = "Справочники";
      // 
      // bbtExchamge
      // 
      bbtExchamge.Caption = "Биржи";
      bbtExchamge.Id = 1;
      bbtExchamge.ImageOptions.Image = (Image)resources.GetObject("barButtonItem1.ImageOptions.Image");
      bbtExchamge.ImageOptions.LargeImage = (Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage");
      bbtExchamge.Name = "bbtExchamge";
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
      bbtSymbol.Caption = "Торговая пара";
      bbtSymbol.Id = 3;
      bbtSymbol.ImageOptions.Image = (Image)resources.GetObject("bbtSymbol.ImageOptions.Image");
      bbtSymbol.ImageOptions.LargeImage = (Image)resources.GetObject("bbtSymbol.ImageOptions.LargeImage");
      bbtSymbol.Name = "bbtSymbol";
      // 
      // bbtSession
      // 
      bbtSession.Caption = "Сессия";
      bbtSession.Id = 4;
      bbtSession.ImageOptions.Image = (Image)resources.GetObject("barButtonItem1.ImageOptions.Image1");
      bbtSession.ImageOptions.LargeImage = (Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage1");
      bbtSession.Name = "bbtSession";
      // 
      // bbtTimeFrame
      // 
      bbtTimeFrame.Caption = "Тайм фрейм";
      bbtTimeFrame.Id = 5;
      bbtTimeFrame.ImageOptions.Image = (Image)resources.GetObject("bbtTimeFrame.ImageOptions.Image");
      bbtTimeFrame.ImageOptions.LargeImage = (Image)resources.GetObject("bbtTimeFrame.ImageOptions.LargeImage");
      bbtTimeFrame.Name = "bbtTimeFrame";
      // 
      // bbtResult
      // 
      bbtResult.Caption = "Результат сделки";
      bbtResult.Id = 6;
      bbtResult.ImageOptions.Image = (Image)resources.GetObject("barButtonItem1.ImageOptions.Image2");
      bbtResult.ImageOptions.LargeImage = (Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage2");
      bbtResult.Name = "bbtResult";
      // 
      // RibbonMain
      // 
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(964, 561);
      Controls.Add(ribbonStatusBar);
      Controls.Add(ribbon);
      Name = "RibbonMain";
      Ribbon = ribbon;
      StatusBar = ribbonStatusBar;
      Text = "Дневник трейдера";
      ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
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
  }
}
