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
      clStartedDate = new DevExpress.XtraGrid.Columns.GridColumn();
      clFinished = new DevExpress.XtraGrid.Columns.GridColumn();
      clTraderExchange = new DevExpress.XtraGrid.Columns.GridColumn();
      clSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
      clReview = new DevExpress.XtraGrid.Columns.GridColumn();
      clEconomicSchedule = new DevExpress.XtraGrid.Columns.GridColumn();
      clSession = new DevExpress.XtraGrid.Columns.GridColumn();
      clStrategy = new DevExpress.XtraGrid.Columns.GridColumn();
      clEntered = new DevExpress.XtraGrid.Columns.GridColumn();
      clDeal = new DevExpress.XtraGrid.Columns.GridColumn();
      clEmotions = new DevExpress.XtraGrid.Columns.GridColumn();
      clScreenshot = new DevExpress.XtraGrid.Columns.GridColumn();
      clWallet = new DevExpress.XtraGrid.Columns.GridColumn();
      clTraderResult = new DevExpress.XtraGrid.Columns.GridColumn();
      clAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
      barDockControlTop.Size = new Size(1128, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 496);
      barDockControlBottom.Manager = bmGrid;
      barDockControlBottom.Size = new Size(1128, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmGrid;
      barDockControlLeft.Size = new Size(0, 472);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(1128, 24);
      barDockControlRight.Manager = bmGrid;
      barDockControlRight.Size = new Size(0, 472);
      // 
      // gcDiaryGrid
      // 
      gcDiaryGrid.Dock = DockStyle.Fill;
      gcDiaryGrid.Location = new Point(0, 24);
      gcDiaryGrid.MainView = gvDiaryGrid;
      gcDiaryGrid.MenuManager = bmGrid;
      gcDiaryGrid.Name = "gcDiaryGrid";
      gcDiaryGrid.Size = new Size(1128, 472);
      gcDiaryGrid.TabIndex = 9;
      gcDiaryGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDiaryGrid });
      // 
      // gvDiaryGrid
      // 
      gvDiaryGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clStartedDate, clFinished, clTraderExchange, clSymbol, clReview, clEconomicSchedule, clSession, clStrategy, clEntered, clDeal, clEmotions, clScreenshot, clWallet, clTraderResult, clAmount });
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
      // clStartedDate
      // 
      clStartedDate.AppearanceHeader.Options.UseTextOptions = true;
      clStartedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clStartedDate.Caption = "Начало";
      clStartedDate.FieldName = "StartedDate";
      clStartedDate.Name = "clStartedDate";
      clStartedDate.Visible = true;
      clStartedDate.VisibleIndex = 0;
      // 
      // clFinished
      // 
      clFinished.AppearanceHeader.Options.UseTextOptions = true;
      clFinished.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFinished.Caption = "Окончание";
      clFinished.FieldName = "FinishedDate";
      clFinished.Name = "clFinished";
      clFinished.Visible = true;
      clFinished.VisibleIndex = 13;
      // 
      // clTraderExchange
      // 
      clTraderExchange.AppearanceHeader.Options.UseTextOptions = true;
      clTraderExchange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clTraderExchange.Caption = "Брокер";
      clTraderExchange.FieldName = "TraderExchange";
      clTraderExchange.Name = "clTraderExchange";
      clTraderExchange.Visible = true;
      clTraderExchange.VisibleIndex = 1;
      // 
      // clSymbol
      // 
      clSymbol.AppearanceHeader.Options.UseTextOptions = true;
      clSymbol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clSymbol.Caption = "Инструмент";
      clSymbol.FieldName = "Symbol";
      clSymbol.Name = "clSymbol";
      clSymbol.Visible = true;
      clSymbol.VisibleIndex = 2;
      // 
      // clReview
      // 
      clReview.AppearanceHeader.Options.UseTextOptions = true;
      clReview.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clReview.Caption = "Анализ рынка";
      clReview.FieldName = "Review";
      clReview.Name = "clReview";
      clReview.Visible = true;
      clReview.VisibleIndex = 3;
      // 
      // clEconomicSchedule
      // 
      clEconomicSchedule.AppearanceHeader.Options.UseTextOptions = true;
      clEconomicSchedule.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clEconomicSchedule.Caption = "Экогом. новости";
      clEconomicSchedule.FieldName = "EconomicSchedule";
      clEconomicSchedule.Name = "clEconomicSchedule";
      clEconomicSchedule.Visible = true;
      clEconomicSchedule.VisibleIndex = 4;
      // 
      // clSession
      // 
      clSession.AppearanceHeader.Options.UseTextOptions = true;
      clSession.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clSession.Caption = "Сессия";
      clSession.FieldName = "Session";
      clSession.Name = "clSession";
      clSession.Visible = true;
      clSession.VisibleIndex = 5;
      // 
      // clStrategy
      // 
      clStrategy.AppearanceHeader.Options.UseTextOptions = true;
      clStrategy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clStrategy.Caption = "Cтратегия";
      clStrategy.FieldName = "Strategy";
      clStrategy.Name = "clStrategy";
      clStrategy.Visible = true;
      clStrategy.VisibleIndex = 14;
      // 
      // clEntered
      // 
      clEntered.AppearanceHeader.Options.UseTextOptions = true;
      clEntered.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clEntered.Caption = "ТФ входа";
      clEntered.FieldName = "Entered";
      clEntered.Name = "clEntered";
      clEntered.Visible = true;
      clEntered.VisibleIndex = 6;
      // 
      // clDeal
      // 
      clDeal.AppearanceHeader.Options.UseTextOptions = true;
      clDeal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clDeal.Caption = "Сделка, ход и сопровождение";
      clDeal.FieldName = "Deal";
      clDeal.Name = "clDeal";
      clDeal.Visible = true;
      clDeal.VisibleIndex = 7;
      // 
      // clEmotions
      // 
      clEmotions.AppearanceHeader.Options.UseTextOptions = true;
      clEmotions.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clEmotions.Caption = "Чек лист эмиций";
      clEmotions.FieldName = "Emotions";
      clEmotions.Name = "clEmotions";
      clEmotions.Visible = true;
      clEmotions.VisibleIndex = 8;
      // 
      // clScreenshot
      // 
      clScreenshot.AppearanceHeader.Options.UseTextOptions = true;
      clScreenshot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clScreenshot.Caption = "Снимок";
      clScreenshot.FieldName = "Screenshot";
      clScreenshot.Name = "clScreenshot";
      clScreenshot.Visible = true;
      clScreenshot.VisibleIndex = 9;
      // 
      // clWallet
      // 
      clWallet.Caption = "Кошелек";
      clWallet.FieldName = "Wallet";
      clWallet.Name = "clWallet";
      clWallet.Visible = true;
      clWallet.VisibleIndex = 10;
      // 
      // clTraderResult
      // 
      clTraderResult.AppearanceHeader.Options.UseTextOptions = true;
      clTraderResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clTraderResult.Caption = "Результат сделки";
      clTraderResult.FieldName = "TraderResult";
      clTraderResult.Name = "clTraderResult";
      clTraderResult.Visible = true;
      clTraderResult.VisibleIndex = 11;
      // 
      // clAmount
      // 
      clAmount.AppearanceHeader.Options.UseTextOptions = true;
      clAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clAmount.Caption = "Сумма профита или убытка";
      clAmount.FieldName = "Amount";
      clAmount.Name = "clAmount";
      clAmount.Visible = true;
      clAmount.VisibleIndex = 12;
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
      Size = new Size(1128, 496);
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
    private DevExpress.XtraGrid.Columns.GridColumn clStartedDate;
    private DevExpress.XtraGrid.Columns.GridColumn clFinished;
    private DevExpress.XtraGrid.Columns.GridColumn clTraderExchange;
    private DevExpress.XtraGrid.Columns.GridColumn clSymbol;
    private DevExpress.XtraGrid.Columns.GridColumn clReview;
    private DevExpress.XtraGrid.Columns.GridColumn clEconomicSchedule;
    private DevExpress.XtraGrid.Columns.GridColumn clSession;
    private DevExpress.XtraGrid.Columns.GridColumn clStrategy;
    private DevExpress.XtraGrid.Columns.GridColumn clEntered;
    private DevExpress.XtraGrid.Columns.GridColumn clDeal;
    private DevExpress.XtraGrid.Columns.GridColumn clEmotions;
    private DevExpress.XtraGrid.Columns.GridColumn clScreenshot;
    private DevExpress.XtraGrid.Columns.GridColumn clWallet;
    private DevExpress.XtraGrid.Columns.GridColumn clTraderResult;
    private DevExpress.XtraGrid.Columns.GridColumn clAmount;
  }
}
