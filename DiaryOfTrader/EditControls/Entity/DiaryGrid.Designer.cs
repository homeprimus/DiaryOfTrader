// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls.Entity
{
  partial class DiaryGrid
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(DiaryGrid));
      bmGrid = new DevExpress.XtraBars.BarManager(components);
      navMarketReview = new DevExpress.XtraBars.Bar();
      bbtAdd = new DevExpress.XtraBars.BarButtonItem();
      bbtEdit = new DevExpress.XtraBars.BarButtonItem();
      bbtDelete = new DevExpress.XtraBars.BarButtonItem();
      bbtRefresh = new DevExpress.XtraBars.BarButtonItem();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      gcDiaryGrid = new DevExpress.XtraGrid.GridControl();
      gvDiaryGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)bmGrid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gcDiaryGrid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvDiaryGrid).BeginInit();
      SuspendLayout();
      // 
      // bmGrid
      // 
      bmGrid.AllowCustomization = false;
      bmGrid.AllowHtmlText = true;
      bmGrid.Bars.AddRange(new DevExpress.XtraBars.Bar[] { navMarketReview });
      bmGrid.DockControls.Add(barDockControlTop);
      bmGrid.DockControls.Add(barDockControlBottom);
      bmGrid.DockControls.Add(barDockControlLeft);
      bmGrid.DockControls.Add(barDockControlRight);
      bmGrid.Form = this;
      bmGrid.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbtDelete, bbtAdd, bbtEdit, bbtRefresh });
      bmGrid.MainMenu = navMarketReview;
      bmGrid.MaxItemId = 4;
      // 
      // navMarketReview
      // 
      navMarketReview.BarName = "Main menu";
      navMarketReview.DockCol = 0;
      navMarketReview.DockRow = 0;
      navMarketReview.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      navMarketReview.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbtEdit), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete), new DevExpress.XtraBars.LinkPersistInfo(bbtRefresh) });
      navMarketReview.OptionsBar.MultiLine = true;
      navMarketReview.OptionsBar.UseWholeRow = true;
      navMarketReview.Text = "Main menu";
      // 
      // bbtAdd
      // 
      bbtAdd.Caption = "Новая запись";
      bbtAdd.Id = 1;
      bbtAdd.ImageOptions.Image = (Image)resources.GetObject("bbtAdd.ImageOptions.Image");
      bbtAdd.ImageOptions.LargeImage = (Image)resources.GetObject("bbtAdd.ImageOptions.LargeImage");
      bbtAdd.Name = "bbtAdd";
      // 
      // bbtEdit
      // 
      bbtEdit.Caption = "Изменить";
      bbtEdit.Id = 2;
      bbtEdit.ImageOptions.Image = (Image)resources.GetObject("bbtEdit.ImageOptions.Image");
      bbtEdit.ImageOptions.LargeImage = (Image)resources.GetObject("bbtEdit.ImageOptions.LargeImage");
      bbtEdit.Name = "bbtEdit";
      // 
      // bbtDelete
      // 
      bbtDelete.Caption = "Удалить";
      bbtDelete.Id = 0;
      bbtDelete.ImageOptions.Image = (Image)resources.GetObject("bbtDelete.ImageOptions.Image");
      bbtDelete.ImageOptions.LargeImage = (Image)resources.GetObject("bbtDelete.ImageOptions.LargeImage");
      bbtDelete.Name = "bbtDelete";
      // 
      // bbtRefresh
      // 
      bbtRefresh.Caption = "Обновить";
      bbtRefresh.Id = 3;
      bbtRefresh.ImageOptions.Image = (Image)resources.GetObject("bbtRefresh.ImageOptions.Image");
      bbtRefresh.ImageOptions.LargeImage = (Image)resources.GetObject("bbtRefresh.ImageOptions.LargeImage");
      bbtRefresh.Name = "bbtRefresh";
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmGrid;
      barDockControlTop.Size = new Size(900, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 394);
      barDockControlBottom.Manager = bmGrid;
      barDockControlBottom.Size = new Size(900, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmGrid;
      barDockControlLeft.Size = new Size(0, 370);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(900, 24);
      barDockControlRight.Manager = bmGrid;
      barDockControlRight.Size = new Size(0, 370);
      // 
      // gcDiaryGrid
      // 
      gcDiaryGrid.Dock = DockStyle.Fill;
      gcDiaryGrid.Location = new Point(0, 24);
      gcDiaryGrid.MainView = gvDiaryGrid;
      gcDiaryGrid.MenuManager = bmGrid;
      gcDiaryGrid.Name = "gcDiaryGrid";
      gcDiaryGrid.Size = new Size(900, 370);
      gcDiaryGrid.TabIndex = 9;
      gcDiaryGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDiaryGrid });
      // 
      // gvDiaryGrid
      // 
      gvDiaryGrid.GridControl = gcDiaryGrid;
      gvDiaryGrid.Name = "gvDiaryGrid";
      gvDiaryGrid.OptionsBehavior.AllowIncrementalSearch = true;
      gvDiaryGrid.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
      gvDiaryGrid.OptionsCustomization.AllowColumnMoving = false;
      gvDiaryGrid.OptionsCustomization.AllowGroup = false;
      gvDiaryGrid.OptionsCustomization.AllowQuickHideColumns = false;
      gvDiaryGrid.OptionsView.RowAutoHeight = true;
      gvDiaryGrid.OptionsView.ShowDetailButtons = false;
      gvDiaryGrid.OptionsView.ShowGroupPanel = false;
      // 
      // DiaryGrid
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(gcDiaryGrid);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "DiaryGrid";
      Size = new Size(900, 394);
      ((System.ComponentModel.ISupportInitialize)bmGrid).EndInit();
      ((System.ComponentModel.ISupportInitialize)gcDiaryGrid).EndInit();
      ((System.ComponentModel.ISupportInitialize)gvDiaryGrid).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    public DevExpress.XtraBars.BarManager bmGrid;
    public DevExpress.XtraBars.Bar navMarketReview;
    public DevExpress.XtraBars.BarButtonItem bbtAdd;
    public DevExpress.XtraBars.BarButtonItem bbtEdit;
    public DevExpress.XtraBars.BarButtonItem bbtDelete;
    public DevExpress.XtraBars.BarButtonItem bbtRefresh;
    public DevExpress.XtraBars.BarDockControl barDockControlTop;
    public DevExpress.XtraBars.BarDockControl barDockControlBottom;
    public DevExpress.XtraBars.BarDockControl barDockControlLeft;
    public DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraGrid.GridControl gcDiaryGrid;
    private DevExpress.XtraGrid.Views.Grid.GridView gvDiaryGrid;
  }
}
