// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.Components
{
  partial class TragingView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(TragingView));
      bmWeb = new DevExpress.XtraBars.BarManager(components);
      navMarketReview = new DevExpress.XtraBars.Bar();
      bsiExchange = new DevExpress.XtraBars.BarStaticItem();
      bsiSymbol = new DevExpress.XtraBars.BarStaticItem();
      bsiSplit = new DevExpress.XtraBars.BarStaticItem();
      bsiTimeframe = new DevExpress.XtraBars.BarStaticItem();
      bci1m = new DevExpress.XtraBars.BarCheckItem();
      bci5m = new DevExpress.XtraBars.BarCheckItem();
      bci15m = new DevExpress.XtraBars.BarCheckItem();
      bci30m = new DevExpress.XtraBars.BarCheckItem();
      bci1h = new DevExpress.XtraBars.BarCheckItem();
      bci4h = new DevExpress.XtraBars.BarCheckItem();
      bci1d = new DevExpress.XtraBars.BarCheckItem();
      bci1w = new DevExpress.XtraBars.BarCheckItem();
      bci1mon = new DevExpress.XtraBars.BarCheckItem();
      split = new DevExpress.XtraBars.BarStaticItem();
      bbiScreeShot = new DevExpress.XtraBars.BarButtonItem();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      lblExcengeSymbol = new DevExpress.XtraBars.BarStaticItem();
      bbiScreenShot = new DevExpress.XtraBars.BarButtonItem();
      bbiExchange = new DevExpress.XtraBars.BarButtonItem();
      bbiSplit = new DevExpress.XtraBars.BarStaticItem();
      bbiSymbol = new DevExpress.XtraBars.BarButtonItem();
      pnlWebBrowser = new Panel();
      WebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
      ((System.ComponentModel.ISupportInitialize)bmWeb).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlWebBrowser).BeginInit();
      pnlWebBrowser.SuspendLayout();
      SuspendLayout();
      // 
      // bmWeb
      // 
      bmWeb.AllowCustomization = false;
      bmWeb.AllowHtmlText = true;
      bmWeb.Bars.AddRange(new DevExpress.XtraBars.Bar[] { navMarketReview });
      bmWeb.DockControls.Add(barDockControlTop);
      bmWeb.DockControls.Add(barDockControlBottom);
      bmWeb.DockControls.Add(barDockControlLeft);
      bmWeb.DockControls.Add(barDockControlRight);
      bmWeb.Form = this;
      bmWeb.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bci1m, bci5m, bci15m, bci30m, bci1h, bci4h, bci1d, bci1w, bci1mon, split, lblExcengeSymbol, bbiScreenShot, bbiScreeShot, bbiExchange, bbiSplit, bbiSymbol, bsiExchange, bsiSymbol, bsiTimeframe, bsiSplit });
      bmWeb.MainMenu = navMarketReview;
      bmWeb.MaxItemId = 27;
      // 
      // navMarketReview
      // 
      navMarketReview.BarName = "Main menu";
      navMarketReview.DockCol = 0;
      navMarketReview.DockRow = 0;
      navMarketReview.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      navMarketReview.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bsiExchange), new DevExpress.XtraBars.LinkPersistInfo(bsiSymbol), new DevExpress.XtraBars.LinkPersistInfo(bsiSplit), new DevExpress.XtraBars.LinkPersistInfo(bsiTimeframe), new DevExpress.XtraBars.LinkPersistInfo(bci1m), new DevExpress.XtraBars.LinkPersistInfo(bci5m), new DevExpress.XtraBars.LinkPersistInfo(bci15m), new DevExpress.XtraBars.LinkPersistInfo(bci30m), new DevExpress.XtraBars.LinkPersistInfo(bci1h), new DevExpress.XtraBars.LinkPersistInfo(bci4h), new DevExpress.XtraBars.LinkPersistInfo(bci1d), new DevExpress.XtraBars.LinkPersistInfo(bci1w), new DevExpress.XtraBars.LinkPersistInfo(bci1mon), new DevExpress.XtraBars.LinkPersistInfo(split), new DevExpress.XtraBars.LinkPersistInfo(bbiScreeShot) });
      navMarketReview.OptionsBar.MultiLine = true;
      navMarketReview.OptionsBar.UseWholeRow = true;
      navMarketReview.Text = "Main menu";
      // 
      // bsiExchange
      // 
      bsiExchange.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
      bsiExchange.Caption = "Binance   ";
      bsiExchange.Id = 23;
      bsiExchange.ImageOptions.Image = (Image)resources.GetObject("bsiExchange.ImageOptions.Image");
      bsiExchange.ImageOptions.LargeImage = (Image)resources.GetObject("bsiExchange.ImageOptions.LargeImage");
      bsiExchange.Name = "bsiExchange";
      bsiExchange.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      // 
      // bsiSymbol
      // 
      bsiSymbol.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
      bsiSymbol.Caption = "BTCUSDT";
      bsiSymbol.Id = 24;
      bsiSymbol.ImageOptions.Image = (Image)resources.GetObject("bsiSymbol.ImageOptions.Image");
      bsiSymbol.ImageOptions.LargeImage = (Image)resources.GetObject("bsiSymbol.ImageOptions.LargeImage");
      bsiSymbol.Name = "bsiSymbol";
      bsiSymbol.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      // 
      // bsiSplit
      // 
      bsiSplit.Caption = "   ";
      bsiSplit.Id = 26;
      bsiSplit.Name = "bsiSplit";
      // 
      // bsiTimeframe
      // 
      bsiTimeframe.Caption = "Таймфрейм:";
      bsiTimeframe.Id = 25;
      bsiTimeframe.ImageOptions.Image = (Image)resources.GetObject("bsiTimeframe.ImageOptions.Image");
      bsiTimeframe.ImageOptions.LargeImage = (Image)resources.GetObject("bsiTimeframe.ImageOptions.LargeImage");
      bsiTimeframe.Name = "bsiTimeframe";
      bsiTimeframe.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      // 
      // bci1m
      // 
      bci1m.Caption = "1м";
      bci1m.GroupIndex = 1;
      bci1m.Id = 4;
      bci1m.Name = "bci1m";
      bci1m.ItemClick += bci1m_ItemClick;
      // 
      // bci5m
      // 
      bci5m.Caption = "5м";
      bci5m.GroupIndex = 1;
      bci5m.Id = 5;
      bci5m.Name = "bci5m";
      bci5m.ItemClick += bci1m_ItemClick;
      // 
      // bci15m
      // 
      bci15m.Caption = "15м";
      bci15m.GroupIndex = 1;
      bci15m.Id = 7;
      bci15m.Name = "bci15m";
      bci15m.ItemClick += bci1m_ItemClick;
      // 
      // bci30m
      // 
      bci30m.Caption = "30м";
      bci30m.GroupIndex = 1;
      bci30m.Id = 8;
      bci30m.Name = "bci30m";
      bci30m.ItemClick += bci1m_ItemClick;
      // 
      // bci1h
      // 
      bci1h.Caption = "1ч";
      bci1h.GroupIndex = 1;
      bci1h.Id = 9;
      bci1h.Name = "bci1h";
      bci1h.ItemClick += bci1m_ItemClick;
      // 
      // bci4h
      // 
      bci4h.Caption = "4ч";
      bci4h.GroupIndex = 1;
      bci4h.Id = 10;
      bci4h.Name = "bci4h";
      bci4h.ItemClick += bci1m_ItemClick;
      // 
      // bci1d
      // 
      bci1d.Caption = "1д";
      bci1d.GroupIndex = 1;
      bci1d.Id = 11;
      bci1d.Name = "bci1d";
      bci1d.ItemClick += bci1m_ItemClick;
      // 
      // bci1w
      // 
      bci1w.Caption = "1н";
      bci1w.GroupIndex = 1;
      bci1w.Id = 12;
      bci1w.Name = "bci1w";
      bci1w.ItemClick += bci1m_ItemClick;
      // 
      // bci1mon
      // 
      bci1mon.Caption = "1М";
      bci1mon.GroupIndex = 1;
      bci1mon.Id = 13;
      bci1mon.Name = "bci1mon";
      bci1mon.ItemClick += bci1m_ItemClick;
      // 
      // split
      // 
      split.Caption = "   ";
      split.Id = 15;
      split.Name = "split";
      // 
      // bbiScreeShot
      // 
      bbiScreeShot.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      bbiScreeShot.Id = 18;
      bbiScreeShot.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiScreeShot.ImageOptions.SvgImage");
      bbiScreeShot.Name = "bbiScreeShot";
      bbiScreeShot.ItemClick += bbiScreeShot_ItemClick;
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmWeb;
      barDockControlTop.Size = new Size(676, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 416);
      barDockControlBottom.Manager = bmWeb;
      barDockControlBottom.Size = new Size(676, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmWeb;
      barDockControlLeft.Size = new Size(0, 392);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(676, 24);
      barDockControlRight.Manager = bmWeb;
      barDockControlRight.Size = new Size(0, 392);
      // 
      // lblExcengeSymbol
      // 
      lblExcengeSymbol.Caption = "<b><color=\"blue\">Binance: <color=\"green\">BTCUSTD</b>  ";
      lblExcengeSymbol.Id = 16;
      lblExcengeSymbol.Name = "lblExcengeSymbol";
      // 
      // bbiScreenShot
      // 
      bbiScreenShot.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      bbiScreenShot.Id = 17;
      bbiScreenShot.ImageOptions.Image = (Image)resources.GetObject("bbiScreenShot.ImageOptions.Image");
      bbiScreenShot.Name = "bbiScreenShot";
      // 
      // bbiExchange
      // 
      bbiExchange.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
      bbiExchange.Caption = "Binance";
      bbiExchange.Id = 19;
      bbiExchange.ImageOptions.Image = (Image)resources.GetObject("bbiExchange.ImageOptions.Image");
      bbiExchange.ImageOptions.LargeImage = (Image)resources.GetObject("bbiExchange.ImageOptions.LargeImage");
      bbiExchange.Name = "bbiExchange";
      bbiExchange.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      // 
      // bbiSplit
      // 
      bbiSplit.Caption = ":";
      bbiSplit.Id = 20;
      bbiSplit.Name = "bbiSplit";
      // 
      // bbiSymbol
      // 
      bbiSymbol.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
      bbiSymbol.Caption = "BTCUSDT";
      bbiSymbol.Id = 21;
      bbiSymbol.ImageOptions.Image = (Image)resources.GetObject("bbiSymbol.ImageOptions.Image");
      bbiSymbol.ImageOptions.LargeImage = (Image)resources.GetObject("bbiSymbol.ImageOptions.LargeImage");
      bbiSymbol.Name = "bbiSymbol";
      bbiSymbol.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      // 
      // pnlWebBrowser
      // 
      pnlWebBrowser.Appearance.BackColor = Color.Transparent;
      pnlWebBrowser.Appearance.Options.UseBackColor = true;
      pnlWebBrowser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlWebBrowser.Controls.Add(WebBrowser);
      pnlWebBrowser.Dock = DockStyle.Fill;
      pnlWebBrowser.Location = new Point(0, 24);
      pnlWebBrowser.Name = "pnlWebBrowser";
      pnlWebBrowser.Padding = new Padding(3);
      pnlWebBrowser.Size = new Size(676, 392);
      pnlWebBrowser.TabIndex = 7;
      // 
      // WebBrowser
      // 
      WebBrowser.ActivateBrowserOnCreation = false;
      WebBrowser.Dock = DockStyle.Fill;
      WebBrowser.Location = new Point(3, 3);
      WebBrowser.Name = "WebBrowser";
      WebBrowser.Size = new Size(670, 386);
      WebBrowser.TabIndex = 3;
      // 
      // TragingView
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pnlWebBrowser);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "TragingView";
      Size = new Size(676, 416);
      ((System.ComponentModel.ISupportInitialize)bmWeb).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlWebBrowser).EndInit();
      pnlWebBrowser.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    public DevExpress.XtraBars.BarManager bmWeb;
    public DevExpress.XtraBars.Bar navMarketReview;
    public DevExpress.XtraBars.BarDockControl barDockControlTop;
    public DevExpress.XtraBars.BarDockControl barDockControlBottom;
    public DevExpress.XtraBars.BarDockControl barDockControlLeft;
    public DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarCheckItem bci1m;
    private DevExpress.XtraBars.BarCheckItem bci5m;
    private DevExpress.XtraBars.BarCheckItem bci15m;
    private DevExpress.XtraBars.BarCheckItem bci30m;
    private DevExpress.XtraBars.BarCheckItem bci1h;
    private DevExpress.XtraBars.BarCheckItem bci4h;
    private DevExpress.XtraBars.BarCheckItem bci1d;
    private DevExpress.XtraBars.BarCheckItem bci1w;
    private DevExpress.XtraBars.BarCheckItem bci1mon;
    private DevExpress.XtraBars.BarStaticItem split;
    private DevExpress.XtraBars.BarStaticItem lblExcengeSymbol;
    private DevExpress.XtraBars.BarButtonItem bbiScreenShot;
    private DevExpress.XtraBars.BarButtonItem bbiScreeShot;
    private DevExpress.XtraBars.BarButtonItem bbiExchange;
    private DevExpress.XtraBars.BarStaticItem bbiSplit;
    private DevExpress.XtraBars.BarButtonItem bbiSymbol;
    private DevExpress.XtraBars.BarStaticItem bsiExchange;
    private DevExpress.XtraBars.BarStaticItem bsiSymbol;
    private DevExpress.XtraBars.BarStaticItem bsiTimeframe;
    private DevExpress.XtraBars.BarStaticItem bsiSplit;
    private Panel pnlWebBrowser;
    private CefSharp.WinForms.ChromiumWebBrowser WebBrowser;
  }
}
