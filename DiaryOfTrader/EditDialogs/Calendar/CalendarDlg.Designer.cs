// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs.Calendar
{
  partial class CalendarDlg
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
      components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarDlg));
      bmCalendar = new DevExpress.XtraBars.BarManager(components);
      bar2 = new DevExpress.XtraBars.Bar();
      beiEconomicPeriod = new DevExpress.XtraBars.BarEditItem();
      rgEconomicPeriod = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
      beiEconomicImportance = new DevExpress.XtraBars.BarEditItem();
      cbEconomicImportance = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
      bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      bar1 = new DevExpress.XtraBars.Bar();
      splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(ProgressIndicator), true, true);
      pnlNode = new Panel();
      html = new DevExpress.XtraEditors.HtmlContentControl();
      splitterControl = new DevExpress.XtraEditors.SplitterControl();
      grid = new DevExpress.XtraGrid.GridControl();
      gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      clDate = new DevExpress.XtraGrid.Columns.GridColumn();
      clTime = new DevExpress.XtraGrid.Columns.GridColumn();
      clCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
      clImportance = new DevExpress.XtraGrid.Columns.GridColumn();
      clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
      clFactual = new DevExpress.XtraGrid.Columns.GridColumn();
      clPrognosis = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemMemoExEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)bmCalendar).BeginInit();
      ((System.ComponentModel.ISupportInitialize)rgEconomicPeriod).BeginInit();
      ((System.ComponentModel.ISupportInitialize)cbEconomicImportance).BeginInit();
      pnlNode.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)html).BeginInit();
      ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit).BeginInit();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 365);
      pnlDown.Size = new Size(809, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(grid);
      pnlClient.Controls.Add(splitterControl);
      pnlClient.Controls.Add(pnlNode);
      pnlClient.Location = new Point(0, 28);
      pnlClient.Size = new Size(809, 337);
      // 
      // btOK
      // 
      btOK.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      btOK.Appearance.Options.UseFont = true;
      // 
      // btCancel
      // 
      btCancel.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      btCancel.Appearance.Options.UseFont = true;
      // 
      // bmCalendar
      // 
      bmCalendar.AllowHtmlText = true;
      bmCalendar.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
      bmCalendar.DockControls.Add(barDockControlTop);
      bmCalendar.DockControls.Add(barDockControlBottom);
      bmCalendar.DockControls.Add(barDockControlLeft);
      bmCalendar.DockControls.Add(barDockControlRight);
      bmCalendar.Form = this;
      bmCalendar.Items.AddRange(new DevExpress.XtraBars.BarItem[] { beiEconomicPeriod, beiEconomicImportance, bbiRefresh });
      bmCalendar.MainMenu = bar2;
      bmCalendar.MaxItemId = 6;
      bmCalendar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { rgEconomicPeriod, cbEconomicImportance });
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, beiEconomicPeriod, "", true, true, true, 418), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, beiEconomicImportance, "", true, true, true, 157), new DevExpress.XtraBars.LinkPersistInfo(bbiRefresh, true) });
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
      // 
      // beiEconomicPeriod
      // 
      beiEconomicPeriod.Edit = rgEconomicPeriod;
      beiEconomicPeriod.Id = 3;
      beiEconomicPeriod.Name = "beiEconomicPeriod";
      // 
      // rgEconomicPeriod
      // 
      rgEconomicPeriod.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Вчера", true, (short)0), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Сегодня", true, (short)1), new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Завтра", true, (short)2), new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "На неделю", true, (short)3), new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Следующая неделя", true, (short)4) });
      rgEconomicPeriod.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
      rgEconomicPeriod.Name = "rgEconomicPeriod";
      // 
      // beiEconomicImportance
      // 
      beiEconomicImportance.Caption = "Волатильность";
      beiEconomicImportance.CaptionToEditorIndent = 3;
      beiEconomicImportance.Description = "Волатильность";
      beiEconomicImportance.Edit = cbEconomicImportance;
      beiEconomicImportance.Id = 4;
      beiEconomicImportance.Name = "beiEconomicImportance";
      beiEconomicImportance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
      // 
      // cbEconomicImportance
      // 
      cbEconomicImportance.AutoHeight = false;
      cbEconomicImportance.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      cbEconomicImportance.Items.AddRange(new object[] { "Все уровни", "Низкая", "Умеренная", "Высокая" });
      cbEconomicImportance.Name = "cbEconomicImportance";
      cbEconomicImportance.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      // 
      // bbiRefresh
      // 
      bbiRefresh.Caption = "Обновить";
      bbiRefresh.Id = 5;
      bbiRefresh.ImageOptions.Image = (Image)resources.GetObject("bbiRefresh.ImageOptions.Image");
      bbiRefresh.ImageOptions.LargeImage = (Image)resources.GetObject("bbiRefresh.ImageOptions.LargeImage");
      bbiRefresh.Name = "bbiRefresh";
      bbiRefresh.ItemClick += bbiRefresh_ItemClick;
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmCalendar;
      barDockControlTop.Size = new Size(809, 28);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 405);
      barDockControlBottom.Manager = bmCalendar;
      barDockControlBottom.Size = new Size(809, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 28);
      barDockControlLeft.Manager = bmCalendar;
      barDockControlLeft.Size = new Size(0, 377);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(809, 28);
      barDockControlRight.Manager = bmCalendar;
      barDockControlRight.Size = new Size(0, 377);
      // 
      // bar1
      // 
      bar1.BarName = "Custom 3";
      bar1.DockCol = 0;
      bar1.DockRow = 1;
      bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar1.Text = "Custom 3";
      // 
      // splashScreenManager
      // 
      splashScreenManager.ClosingDelay = 500;
      // 
      // pnlNode
      // 
      pnlNode.Controls.Add(html);
      pnlNode.Dock = DockStyle.Bottom;
      pnlNode.Location = new Point(0, 250);
      pnlNode.Margin = new Padding(5, 3, 5, 3);
      pnlNode.Name = "pnlNode";
      pnlNode.Size = new Size(809, 87);
      pnlNode.TabIndex = 8;
      // 
      // html
      // 
      html.Dock = DockStyle.Fill;
      html.Location = new Point(0, 0);
      html.Name = "html";
      html.Padding = new Padding(20, 3, 10, 3);
      html.Size = new Size(809, 87);
      html.TabIndex = 0;
      // 
      // splitterControl
      // 
      splitterControl.Dock = DockStyle.Bottom;
      splitterControl.Location = new Point(0, 240);
      splitterControl.Name = "splitterControl";
      splitterControl.Size = new Size(809, 10);
      splitterControl.TabIndex = 9;
      splitterControl.TabStop = false;
      // 
      // grid
      // 
      grid.Dock = DockStyle.Fill;
      grid.Location = new Point(0, 0);
      grid.MainView = gridView;
      grid.Name = "grid";
      grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoEdit, repositoryItemMemoExEdit });
      grid.Size = new Size(809, 240);
      grid.TabIndex = 10;
      grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
      // 
      // gridView
      // 
      gridView.Appearance.GroupPanel.Options.UseTextOptions = true;
      gridView.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clDate, clTime, clCurrency, clImportance, clDescription, clFactual, clPrognosis });
      gridView.GridControl = grid;
      gridView.GroupFormat = "[#image]{1} {2}";
      gridView.Name = "gridView";
      gridView.OptionsBehavior.AllowIncrementalSearch = true;
      gridView.OptionsBehavior.AutoExpandAllGroups = true;
      gridView.OptionsBehavior.KeepGroupExpandedOnSorting = false;
      gridView.OptionsCustomization.AllowColumnMoving = false;
      gridView.OptionsCustomization.AllowQuickHideColumns = false;
      gridView.OptionsView.RowAutoHeight = true;
      gridView.OptionsView.ShowDetailButtons = false;
      gridView.OptionsView.ShowGroupPanel = false;
      gridView.FocusedRowChanged += FocusedRowChanged;
      // 
      // clDate
      // 
      clDate.AppearanceHeader.Options.UseTextOptions = true;
      clDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clDate.Caption = "Дата";
      clDate.DisplayFormat.FormatString = "dddd, dd MMMM yyyy";
      clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clDate.FieldName = "Date";
      clDate.GroupFormat.FormatString = "dddd, dd MMMM yyyy";
      clDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clDate.Name = "clDate";
      clDate.OptionsColumn.AllowEdit = false;
      clDate.Visible = true;
      clDate.VisibleIndex = 0;
      clDate.Width = 163;
      // 
      // clTime
      // 
      clTime.AppearanceHeader.Options.UseTextOptions = true;
      clTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clTime.Caption = "Время";
      clTime.FieldName = "Time";
      clTime.Name = "clTime";
      clTime.OptionsColumn.AllowEdit = false;
      clTime.OptionsColumn.FixedWidth = true;
      clTime.Visible = true;
      clTime.VisibleIndex = 1;
      clTime.Width = 50;
      // 
      // clCurrency
      // 
      clCurrency.AppearanceHeader.Options.UseTextOptions = true;
      clCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clCurrency.Caption = "Валюта";
      clCurrency.FieldName = "Currency";
      clCurrency.Name = "clCurrency";
      clCurrency.OptionsColumn.AllowEdit = false;
      clCurrency.OptionsColumn.FixedWidth = true;
      clCurrency.Visible = true;
      clCurrency.VisibleIndex = 2;
      clCurrency.Width = 50;
      // 
      // clImportance
      // 
      clImportance.AppearanceHeader.Options.UseTextOptions = true;
      clImportance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clImportance.Caption = "Важность";
      clImportance.FieldName = "Importance";
      clImportance.Name = "clImportance";
      clImportance.OptionsColumn.AllowEdit = false;
      clImportance.Visible = true;
      clImportance.VisibleIndex = 3;
      clImportance.Width = 100;
      // 
      // clDescription
      // 
      clDescription.AppearanceHeader.Options.UseTextOptions = true;
      clDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clDescription.Caption = "Событие";
      clDescription.ColumnEdit = repositoryItemMemoEdit;
      clDescription.FieldName = "Description";
      clDescription.Name = "clDescription";
      clDescription.OptionsColumn.AllowEdit = false;
      clDescription.Visible = true;
      clDescription.VisibleIndex = 4;
      clDescription.Width = 281;
      // 
      // repositoryItemMemoEdit
      // 
      repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      // 
      // clFactual
      // 
      clFactual.AppearanceHeader.Options.UseTextOptions = true;
      clFactual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clFactual.Caption = "Факт.";
      clFactual.FieldName = "Factual";
      clFactual.Name = "clFactual";
      clFactual.OptionsColumn.AllowEdit = false;
      clFactual.OptionsColumn.FixedWidth = true;
      clFactual.Visible = true;
      clFactual.VisibleIndex = 5;
      clFactual.Width = 70;
      // 
      // clPrognosis
      // 
      clPrognosis.AppearanceHeader.Options.UseTextOptions = true;
      clPrognosis.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      clPrognosis.Caption = "Прогноз";
      clPrognosis.FieldName = "Prognosis";
      clPrognosis.Name = "clPrognosis";
      clPrognosis.OptionsColumn.AllowEdit = false;
      clPrognosis.OptionsColumn.FixedWidth = true;
      clPrognosis.Visible = true;
      clPrognosis.VisibleIndex = 6;
      clPrognosis.Width = 70;
      // 
      // repositoryItemMemoExEdit
      // 
      repositoryItemMemoExEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      repositoryItemMemoExEdit.Name = "repositoryItemMemoExEdit";
      // 
      // CalendarDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(809, 405);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      IconOptions.Icon = (Icon)resources.GetObject("CalendarDlg.IconOptions.Icon");
      Name = "CalendarDlg";
      Text = "CalendarDlg";
      Load += CalendarDlg_Load;
      Controls.SetChildIndex(barDockControlTop, 0);
      Controls.SetChildIndex(barDockControlBottom, 0);
      Controls.SetChildIndex(barDockControlRight, 0);
      Controls.SetChildIndex(barDockControlLeft, 0);
      Controls.SetChildIndex(pnlDown, 0);
      Controls.SetChildIndex(pnlClient, 0);
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)bmCalendar).EndInit();
      ((System.ComponentModel.ISupportInitialize)rgEconomicPeriod).EndInit();
      ((System.ComponentModel.ISupportInitialize)cbEconomicImportance).EndInit();
      pnlNode.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)html).EndInit();
      ((System.ComponentModel.ISupportInitialize)grid).EndInit();
      ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.BarManager bmCalendar;
    private DevExpress.XtraBars.Bar bar2;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarEditItem brEconomicPeriod;
    private DevExpress.XtraBars.Bar bar1;
    private DevExpress.XtraBars.BarEditItem beiEconomicPeriod;
    private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup rgEconomicPeriod;
    private DevExpress.XtraBars.BarEditItem beiEconomicImportance;
    private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbEconomicImportance;
    private DevExpress.XtraBars.BarButtonItem bbiRefresh;
    private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    private DevExpress.XtraEditors.SplitterControl splitterControl;
    private Panel pnlNode;
    private DevExpress.XtraEditors.HtmlContentControl html;
    private DevExpress.XtraGrid.GridControl grid;
    public DevExpress.XtraGrid.Views.Grid.GridView gridView;
    private DevExpress.XtraGrid.Columns.GridColumn clDate;
    private DevExpress.XtraGrid.Columns.GridColumn clTime;
    private DevExpress.XtraGrid.Columns.GridColumn clCurrency;
    private DevExpress.XtraGrid.Columns.GridColumn clImportance;
    private DevExpress.XtraGrid.Columns.GridColumn clDescription;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit;
    private DevExpress.XtraGrid.Columns.GridColumn clFactual;
    private DevExpress.XtraGrid.Columns.GridColumn clPrognosis;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit;
  }
}
