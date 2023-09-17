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
      gvMarketReviewTimeFrames = new DevExpress.XtraGrid.Views.Grid.GridView();
      clReviewName = new DevExpress.XtraGrid.Columns.GridColumn();
      clclReviewFrame = new DevExpress.XtraGrid.Columns.GridColumn();
      clReviewTrend = new DevExpress.XtraGrid.Columns.GridColumn();
      clReviewScreenShot = new DevExpress.XtraGrid.Columns.GridColumn();
      clReviewDescription = new DevExpress.XtraGrid.Columns.GridColumn();
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
      ((System.ComponentModel.ISupportInitialize)gvMarketReviewTimeFrames).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gcMarketReview).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvMarketReview).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).BeginInit();
      SuspendLayout();
      // 
      // gvMarketReviewTimeFrames
      // 
      gvMarketReviewTimeFrames.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clReviewName, clclReviewFrame, clReviewTrend, clReviewScreenShot, clReviewDescription });
      gvMarketReviewTimeFrames.DetailHeight = 303;
      gvMarketReviewTimeFrames.GridControl = gcMarketReview;
      gvMarketReviewTimeFrames.Name = "gvMarketReviewTimeFrames";
      // 
      // clReviewName
      // 
      clReviewName.Caption = "Наименование";
      clReviewName.FieldName = "Name";
      clReviewName.MinWidth = 17;
      clReviewName.Name = "clReviewName";
      clReviewName.Visible = true;
      clReviewName.VisibleIndex = 0;
      clReviewName.Width = 64;
      // 
      // clclReviewFrame
      // 
      clclReviewFrame.Caption = "ТФ";
      clclReviewFrame.FieldName = "Frame";
      clclReviewFrame.MinWidth = 17;
      clclReviewFrame.Name = "clclReviewFrame";
      clclReviewFrame.Visible = true;
      clclReviewFrame.VisibleIndex = 1;
      clclReviewFrame.Width = 64;
      // 
      // clReviewTrend
      // 
      clReviewTrend.Caption = "Тренд";
      clReviewTrend.FieldName = "Trend";
      clReviewTrend.MinWidth = 17;
      clReviewTrend.Name = "clReviewTrend";
      clReviewTrend.Visible = true;
      clReviewTrend.VisibleIndex = 2;
      clReviewTrend.Width = 64;
      // 
      // clReviewScreenShot
      // 
      clReviewScreenShot.Caption = "Изображение";
      clReviewScreenShot.FieldName = "ScreenShot.Image";
      clReviewScreenShot.MinWidth = 17;
      clReviewScreenShot.Name = "clReviewScreenShot";
      clReviewScreenShot.Visible = true;
      clReviewScreenShot.VisibleIndex = 3;
      clReviewScreenShot.Width = 64;
      // 
      // clReviewDescription
      // 
      clReviewDescription.Caption = "Анализ";
      clReviewDescription.FieldName = "Description";
      clReviewDescription.MinWidth = 17;
      clReviewDescription.Name = "clReviewDescription";
      clReviewDescription.Visible = true;
      clReviewDescription.VisibleIndex = 4;
      clReviewDescription.Width = 64;
      // 
      // gcMarketReview
      // 
      gcMarketReview.Dock = DockStyle.Fill;
      gridLevelNode1.LevelTemplate = gvMarketReviewTimeFrames;
      gridLevelNode1.RelationName = "MarketReviewTimeFrames";
      gcMarketReview.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
      gcMarketReview.Location = new Point(0, 24);
      gcMarketReview.MainView = gvMarketReview;
      gcMarketReview.MenuManager = bmGrid;
      gcMarketReview.Name = "gcMarketReview";
      gcMarketReview.Size = new Size(751, 397);
      gcMarketReview.TabIndex = 4;
      gcMarketReview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMarketReview, gvMarketReviewTimeFrames });
      // 
      // gvMarketReview
      // 
      gvMarketReview.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      gvMarketReview.ChildGridLevelName = "gvMarketReviewTimeFrames";
      gvMarketReview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clDateTime, clName, clExchange, clSymbol, clDescription });
      gvMarketReview.DetailHeight = 303;
      gvMarketReview.GridControl = gcMarketReview;
      gvMarketReview.Name = "gvMarketReview";
      gvMarketReview.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
      gvMarketReview.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
      gvMarketReview.OptionsMenu.EnableGroupPanelMenu = false;
      gvMarketReview.OptionsView.AllowHtmlDrawHeaders = true;
      gvMarketReview.OptionsView.ShowChildrenInGroupPanel = true;
      // 
      // clDateTime
      // 
      clDateTime.Caption = "Двта";
      clDateTime.FieldName = "DateTime";
      clDateTime.MinWidth = 17;
      clDateTime.Name = "clDateTime";
      clDateTime.OptionsColumn.AllowSize = false;
      clDateTime.OptionsColumn.FixedWidth = true;
      clDateTime.Visible = true;
      clDateTime.VisibleIndex = 1;
      clDateTime.Width = 64;
      // 
      // clName
      // 
      clName.Caption = "Наименование";
      clName.FieldName = "DateTime";
      clName.MinWidth = 17;
      clName.Name = "clName";
      clName.Visible = true;
      clName.VisibleIndex = 0;
      clName.Width = 64;
      // 
      // clExchange
      // 
      clExchange.Caption = "Биржа";
      clExchange.FieldName = "Exchange";
      clExchange.MinWidth = 17;
      clExchange.Name = "clExchange";
      clExchange.Visible = true;
      clExchange.VisibleIndex = 2;
      clExchange.Width = 64;
      // 
      // clSymbol
      // 
      clSymbol.Caption = "Инструмент";
      clSymbol.FieldName = "Symbol";
      clSymbol.MinWidth = 17;
      clSymbol.Name = "clSymbol";
      clSymbol.Visible = true;
      clSymbol.VisibleIndex = 3;
      clSymbol.Width = 64;
      // 
      // clDescription
      // 
      clDescription.Caption = "Описпание";
      clDescription.FieldName = "Description";
      clDescription.MinWidth = 17;
      clDescription.Name = "clDescription";
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
      ((System.ComponentModel.ISupportInitialize)gvMarketReviewTimeFrames).EndInit();
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
    private DevExpress.XtraGrid.Views.Grid.GridView gvMarketReviewTimeFrames;
    private DevExpress.XtraGrid.Columns.GridColumn clReviewName;
    private DevExpress.XtraGrid.Columns.GridColumn clclReviewFrame;
    private DevExpress.XtraGrid.Columns.GridColumn clReviewTrend;
    private DevExpress.XtraGrid.Columns.GridColumn clReviewScreenShot;
    private DevExpress.XtraGrid.Columns.GridColumn clReviewDescription;
    private DevExpress.XtraGrid.Columns.GridColumn clDateTime;
    private DevExpress.XtraGrid.Columns.GridColumn clName;
    private DevExpress.XtraGrid.Columns.GridColumn clExchange;
    private DevExpress.XtraGrid.Columns.GridColumn clSymbol;
    private DevExpress.XtraGrid.Columns.GridColumn clDescription;
  }
}
