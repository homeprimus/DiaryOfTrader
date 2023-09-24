// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls.Entity
{
  partial class MarketReviewGrid
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
      var gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketReviewGrid));
      viewFrames = new DevExpress.XtraGrid.Views.Grid.GridView();
      clFrameName = new DevExpress.XtraGrid.Columns.GridColumn();
      clFrameTimeFrame = new DevExpress.XtraGrid.Columns.GridColumn();
      clFrameTrend = new DevExpress.XtraGrid.Columns.GridColumn();
      clFrameShot = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemPictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
      clFrameDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
      gcMarketReview = new DevExpress.XtraGrid.GridControl();
      gvMarketReview = new DevExpress.XtraGrid.Views.Grid.GridView();
      clDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
      clName = new DevExpress.XtraGrid.Columns.GridColumn();
      clExchange = new DevExpress.XtraGrid.Columns.GridColumn();
      clSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
      clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
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
      ((System.ComponentModel.ISupportInitialize)viewFrames).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gcMarketReview).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvMarketReview).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).BeginInit();
      SuspendLayout();
      // 
      // viewFrames
      // 
      viewFrames.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clFrameName, clFrameTimeFrame, clFrameTrend, clFrameShot, clFrameDescription });
      viewFrames.GridControl = gcMarketReview;
      viewFrames.Name = "viewFrames";
      viewFrames.OptionsBehavior.AllowIncrementalSearch = true;
      viewFrames.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
      viewFrames.OptionsCustomization.AllowColumnMoving = false;
      viewFrames.OptionsCustomization.AllowGroup = false;
      viewFrames.OptionsCustomization.AllowQuickHideColumns = false;
      viewFrames.OptionsView.RowAutoHeight = true;
      viewFrames.OptionsView.ShowDetailButtons = false;
      viewFrames.OptionsView.ShowGroupPanel = false;
      // 
      // clFrameName
      // 
      clFrameName.AppearanceHeader.Options.UseTextOptions = true;
      clFrameName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFrameName.Caption = "Наименование";
      clFrameName.FieldName = "Name";
      clFrameName.Name = "clFrameName";
      clFrameName.OptionsColumn.AllowEdit = false;
      clFrameName.Visible = true;
      clFrameName.VisibleIndex = 0;
      // 
      // clFrameTimeFrame
      // 
      clFrameTimeFrame.AppearanceHeader.Options.UseTextOptions = true;
      clFrameTimeFrame.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFrameTimeFrame.Caption = "Таймфрейм";
      clFrameTimeFrame.FieldName = "Frame";
      clFrameTimeFrame.Name = "clFrameTimeFrame";
      clFrameTimeFrame.OptionsColumn.AllowEdit = false;
      clFrameTimeFrame.Visible = true;
      clFrameTimeFrame.VisibleIndex = 2;
      // 
      // clFrameTrend
      // 
      clFrameTrend.AppearanceHeader.Options.UseTextOptions = true;
      clFrameTrend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFrameTrend.Caption = "Тренд";
      clFrameTrend.FieldName = "Trend";
      clFrameTrend.Name = "clFrameTrend";
      clFrameTrend.OptionsColumn.AllowEdit = false;
      clFrameTrend.Visible = true;
      clFrameTrend.VisibleIndex = 1;
      // 
      // clFrameShot
      // 
      clFrameShot.AppearanceHeader.Options.UseTextOptions = true;
      clFrameShot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFrameShot.Caption = "Изображение";
      clFrameShot.ColumnEdit = repositoryItemPictureEdit;
      clFrameShot.FieldName = "ScreenShot.Image";
      clFrameShot.Name = "clFrameShot";
      clFrameShot.OptionsColumn.AllowEdit = false;
      clFrameShot.Visible = true;
      clFrameShot.VisibleIndex = 3;
      // 
      // repositoryItemPictureEdit
      // 
      repositoryItemPictureEdit.CustomHeight = 80;
      repositoryItemPictureEdit.Name = "repositoryItemPictureEdit";
      repositoryItemPictureEdit.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
      repositoryItemPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
      repositoryItemPictureEdit.FormatEditValue += repositoryItemPictureEdit_FormatEditValue;
      // 
      // clFrameDescription
      // 
      clFrameDescription.AppearanceHeader.Options.UseTextOptions = true;
      clFrameDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFrameDescription.Caption = "Анализ таймфрейма";
      clFrameDescription.ColumnEdit = repositoryItemMemoEdit;
      clFrameDescription.FieldName = "Description";
      clFrameDescription.Name = "clFrameDescription";
      clFrameDescription.OptionsColumn.AllowEdit = false;
      clFrameDescription.Visible = true;
      clFrameDescription.VisibleIndex = 4;
      // 
      // repositoryItemMemoEdit
      // 
      repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      // 
      // gcMarketReview
      // 
      gcMarketReview.Dock = DockStyle.Fill;
      gridLevelNode1.LevelTemplate = viewFrames;
      gridLevelNode1.RelationName = "Frames";
      gcMarketReview.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
      gcMarketReview.Location = new Point(0, 24);
      gcMarketReview.MainView = gvMarketReview;
      gcMarketReview.MenuManager = bmGrid;
      gcMarketReview.Name = "gcMarketReview";
      gcMarketReview.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoEdit, repositoryItemPictureEdit });
      gcMarketReview.Size = new Size(751, 397);
      gcMarketReview.TabIndex = 4;
      gcMarketReview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMarketReview, viewFrames });
      // 
      // gvMarketReview
      // 
      gvMarketReview.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      gvMarketReview.ChildGridLevelName = "Frames";
      gvMarketReview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clDateTime, clName, clExchange, clSymbol, clDescription });
      gvMarketReview.DetailHeight = 303;
      gvMarketReview.GridControl = gcMarketReview;
      gvMarketReview.Name = "gvMarketReview";
      gvMarketReview.OptionsCustomization.AllowColumnMoving = false;
      gvMarketReview.OptionsCustomization.AllowGroup = false;
      gvMarketReview.OptionsCustomization.AllowQuickHideColumns = false;
      gvMarketReview.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
      gvMarketReview.OptionsDetail.ShowDetailTabs = false;
      gvMarketReview.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
      gvMarketReview.OptionsMenu.EnableGroupPanelMenu = false;
      gvMarketReview.OptionsView.AllowHtmlDrawHeaders = true;
      gvMarketReview.OptionsView.RowAutoHeight = true;
      gvMarketReview.OptionsView.ShowGroupPanel = false;
      // 
      // clDateTime
      // 
      clDateTime.AppearanceHeader.Options.UseTextOptions = true;
      clDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clDateTime.Caption = "Дата";
      clDateTime.FieldName = "DateTime";
      clDateTime.MinWidth = 17;
      clDateTime.Name = "clDateTime";
      clDateTime.OptionsColumn.AllowEdit = false;
      clDateTime.OptionsColumn.AllowSize = false;
      clDateTime.OptionsColumn.FixedWidth = true;
      clDateTime.Visible = true;
      clDateTime.VisibleIndex = 1;
      clDateTime.Width = 64;
      // 
      // clName
      // 
      clName.AppearanceHeader.Options.UseTextOptions = true;
      clName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clName.Caption = "Наименование";
      clName.FieldName = "DateTime";
      clName.MinWidth = 17;
      clName.Name = "clName";
      clName.OptionsColumn.AllowEdit = false;
      clName.Visible = true;
      clName.VisibleIndex = 0;
      clName.Width = 64;
      // 
      // clExchange
      // 
      clExchange.AppearanceHeader.Options.UseTextOptions = true;
      clExchange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clExchange.Caption = "Брокер";
      clExchange.FieldName = "Exchange";
      clExchange.MinWidth = 17;
      clExchange.Name = "clExchange";
      clExchange.OptionsColumn.AllowEdit = false;
      clExchange.Visible = true;
      clExchange.VisibleIndex = 2;
      clExchange.Width = 64;
      // 
      // clSymbol
      // 
      clSymbol.AppearanceHeader.Options.UseTextOptions = true;
      clSymbol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clSymbol.Caption = "Инструмент";
      clSymbol.FieldName = "Symbol";
      clSymbol.MinWidth = 17;
      clSymbol.Name = "clSymbol";
      clSymbol.OptionsColumn.AllowEdit = false;
      clSymbol.Visible = true;
      clSymbol.VisibleIndex = 3;
      clSymbol.Width = 64;
      // 
      // clDescription
      // 
      clDescription.AppearanceHeader.Options.UseTextOptions = true;
      clDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clDescription.Caption = "Описпание";
      clDescription.ColumnEdit = repositoryItemMemoEdit;
      clDescription.FieldName = "Description";
      clDescription.MinWidth = 17;
      clDescription.Name = "clDescription";
      clDescription.OptionsColumn.AllowEdit = false;
      clDescription.Visible = true;
      clDescription.VisibleIndex = 4;
      clDescription.Width = 64;
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
      bbtAdd.ItemClick += bbtAdd_ItemClick;
      // 
      // bbtEdit
      // 
      bbtEdit.Caption = "Изменить";
      bbtEdit.Id = 2;
      bbtEdit.ImageOptions.Image = (Image)resources.GetObject("bbtEdit.ImageOptions.Image");
      bbtEdit.ImageOptions.LargeImage = (Image)resources.GetObject("bbtEdit.ImageOptions.LargeImage");
      bbtEdit.Name = "bbtEdit";
      bbtEdit.ItemClick += bbEdit_ItemClick;
      // 
      // bbtDelete
      // 
      bbtDelete.Caption = "Удалить";
      bbtDelete.Id = 0;
      bbtDelete.ImageOptions.Image = (Image)resources.GetObject("bbtDelete.ImageOptions.Image");
      bbtDelete.ImageOptions.LargeImage = (Image)resources.GetObject("bbtDelete.ImageOptions.LargeImage");
      bbtDelete.Name = "bbtDelete";
      bbtDelete.ItemClick += bbtDelete_ItemClick;
      // 
      // bbtRefresh
      // 
      bbtRefresh.Caption = "Обновить";
      bbtRefresh.Id = 3;
      bbtRefresh.ImageOptions.Image = (Image)resources.GetObject("bbtRefresh.ImageOptions.Image");
      bbtRefresh.ImageOptions.LargeImage = (Image)resources.GetObject("bbtRefresh.ImageOptions.LargeImage");
      bbtRefresh.Name = "bbtRefresh";
      bbtRefresh.ItemClick += bbtRefresh_ItemClick;
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmGrid;
      barDockControlTop.Size = new Size(751, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 421);
      barDockControlBottom.Manager = bmGrid;
      barDockControlBottom.Size = new Size(751, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmGrid;
      barDockControlLeft.Size = new Size(0, 397);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(751, 24);
      barDockControlRight.Manager = bmGrid;
      barDockControlRight.Size = new Size(0, 397);
      // 
      // MarketReviewGrid
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(gcMarketReview);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "MarketReviewGrid";
      Size = new Size(751, 421);
      ((System.ComponentModel.ISupportInitialize)viewFrames).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).EndInit();
      ((System.ComponentModel.ISupportInitialize)gcMarketReview).EndInit();
      ((System.ComponentModel.ISupportInitialize)gvMarketReview).EndInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).EndInit();
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
    private DevExpress.XtraGrid.GridControl gcMarketReview;
    private DevExpress.XtraGrid.Views.Grid.GridView gvMarketReview;
    private DevExpress.XtraGrid.Columns.GridColumn clDateTime;
    private DevExpress.XtraGrid.Columns.GridColumn clName;
    private DevExpress.XtraGrid.Columns.GridColumn clExchange;
    private DevExpress.XtraGrid.Columns.GridColumn clSymbol;
    private DevExpress.XtraGrid.Columns.GridColumn clDescription;
    private DevExpress.XtraGrid.Views.Grid.GridView viewFrames;
    private DevExpress.XtraGrid.Columns.GridColumn clFrameName;
    private DevExpress.XtraGrid.Columns.GridColumn clFrameTimeFrame;
    private DevExpress.XtraGrid.Columns.GridColumn clFrameTrend;
    private DevExpress.XtraGrid.Columns.GridColumn clFrameShot;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit;
    private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit;
    private DevExpress.XtraGrid.Columns.GridColumn clFrameDescription;
  }
}
