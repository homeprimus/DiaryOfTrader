// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs.Dictionary
{
  partial class TradeSessionDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeSessionDlg));
      splitterControl = new DevExpress.XtraEditors.SplitterControl();
      pnlSession = new Components.Panel();
      gridSession = new DevExpress.XtraGrid.GridControl();
      gvSession = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
      gbName = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
      clName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      clDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
      gbSummer = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
      clSummerStarting = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
      clSummerFinished = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      gbWinter = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
      clWinterStarting = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      clWinterFinished = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
      gnSession = new EditControls.GridNavigator();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pnlSession).BeginInit();
      pnlSession.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gridSession).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvSession).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit.CalendarTimeProperties).BeginInit();
      SuspendLayout();
      // 
      // grid
      // 
      grid.Appearance.BackColor = (Color)resources.GetObject("grid.Appearance.BackColor");
      grid.Appearance.Font = (Font)resources.GetObject("grid.Appearance.Font");
      grid.Appearance.Options.UseBackColor = true;
      grid.Appearance.Options.UseFont = true;
      resources.ApplyResources(grid, "grid");
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = (Color)resources.GetObject("pnlDown.Appearance.BackColor");
      pnlDown.Appearance.Options.UseBackColor = true;
      resources.ApplyResources(pnlDown, "pnlDown");
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = (Color)resources.GetObject("pnlClient.Appearance.BackColor");
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(pnlSession);
      pnlClient.Controls.Add(splitterControl);
      resources.ApplyResources(pnlClient, "pnlClient");
      pnlClient.Controls.SetChildIndex(grid, 0);
      pnlClient.Controls.SetChildIndex(splitterControl, 0);
      pnlClient.Controls.SetChildIndex(pnlSession, 0);
      // 
      // btOK
      // 
      btOK.Appearance.Font = (Font)resources.GetObject("btOK.Appearance.Font");
      btOK.Appearance.Options.UseFont = true;
      // 
      // btCancel
      // 
      btCancel.Appearance.Font = (Font)resources.GetObject("btCancel.Appearance.Font");
      btCancel.Appearance.Options.UseFont = true;
      // 
      // splitterControl
      // 
      resources.ApplyResources(splitterControl, "splitterControl");
      splitterControl.Name = "splitterControl";
      splitterControl.TabStop = false;
      // 
      // pnlSession
      // 
      pnlSession.Appearance.BackColor = (Color)resources.GetObject("pnlSession.Appearance.BackColor");
      pnlSession.Appearance.Options.UseBackColor = true;
      pnlSession.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlSession.Controls.Add(gridSession);
      pnlSession.Controls.Add(gnSession);
      resources.ApplyResources(pnlSession, "pnlSession");
      pnlSession.Name = "pnlSession";
      // 
      // gridSession
      // 
      resources.ApplyResources(gridSession, "gridSession");
      gridSession.MainView = gvSession;
      gridSession.Name = "gridSession";
      gridSession.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemDateEdit, repositoryItemMemoEdit });
      gridSession.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvSession });
      // 
      // gvSession
      // 
      gvSession.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gbName, gbSummer, gbWinter });
      gvSession.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { clName, clSummerStarting, clSummerFinished, clWinterStarting, clWinterFinished, clDescription });
      gvSession.GridControl = gridSession;
      gvSession.Name = "gvSession";
      gvSession.OptionsBehavior.AllowIncrementalSearch = true;
      gvSession.OptionsCustomization.AllowColumnMoving = false;
      gvSession.OptionsCustomization.AllowGroup = false;
      gvSession.OptionsCustomization.AllowQuickHideColumns = false;
      gvSession.OptionsView.RowAutoHeight = true;
      gvSession.OptionsView.ShowDetailButtons = false;
      gvSession.OptionsView.ShowGroupPanel = false;
      // 
      // gbName
      // 
      gbName.AppearanceHeader.Options.UseTextOptions = true;
      gbName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(gbName, "gbName");
      gbName.Columns.Add(clName);
      gbName.Columns.Add(clDescription);
      gbName.OptionsBand.AllowMove = false;
      gbName.OptionsBand.ShowCaption = false;
      gbName.VisibleIndex = 0;
      // 
      // clName
      // 
      clName.AppearanceHeader.Options.UseTextOptions = true;
      clName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clName, "clName");
      clName.FieldName = "Name";
      clName.Name = "clName";
      clName.OptionsColumn.AllowMove = false;
      clName.UnboundDataType = typeof(string);
      // 
      // clDescription
      // 
      clDescription.AppearanceHeader.Options.UseTextOptions = true;
      clDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clDescription, "clDescription");
      clDescription.ColumnEdit = repositoryItemMemoEdit;
      clDescription.FieldName = "Description";
      clDescription.Name = "clDescription";
      // 
      // repositoryItemMemoEdit
      // 
      repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      // 
      // gbSummer
      // 
      gbSummer.AppearanceHeader.Options.UseTextOptions = true;
      gbSummer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(gbSummer, "gbSummer");
      gbSummer.Columns.Add(clSummerStarting);
      gbSummer.Columns.Add(clSummerFinished);
      gbSummer.OptionsBand.AllowMove = false;
      gbSummer.OptionsBand.FixedWidth = true;
      gbSummer.VisibleIndex = 1;
      // 
      // clSummerStarting
      // 
      clSummerStarting.AppearanceHeader.Options.UseTextOptions = true;
      clSummerStarting.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clSummerStarting, "clSummerStarting");
      clSummerStarting.ColumnEdit = repositoryItemDateEdit;
      clSummerStarting.DisplayFormat.FormatString = "hh:mm";
      clSummerStarting.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clSummerStarting.FieldName = "SummerStarting";
      clSummerStarting.Name = "clSummerStarting";
      clSummerStarting.OptionsColumn.AllowMove = false;
      clSummerStarting.OptionsColumn.FixedWidth = true;
      // 
      // repositoryItemDateEdit
      // 
      resources.ApplyResources(repositoryItemDateEdit, "repositoryItemDateEdit");
      repositoryItemDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("repositoryItemDateEdit.Buttons")) });
      repositoryItemDateEdit.CalendarDateEditing = false;
      repositoryItemDateEdit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
      repositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("repositoryItemDateEdit.CalendarTimeProperties.Buttons")) });
      repositoryItemDateEdit.DisplayFormat.FormatString = "hh:mm";
      repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      repositoryItemDateEdit.EditFormat.FormatString = "hh:mm";
      repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      repositoryItemDateEdit.MaskSettings.Set("mask", "hh:mm");
      repositoryItemDateEdit.Name = "repositoryItemDateEdit";
      // 
      // clSummerFinished
      // 
      clSummerFinished.AppearanceHeader.Options.UseTextOptions = true;
      clSummerFinished.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clSummerFinished, "clSummerFinished");
      clSummerFinished.ColumnEdit = repositoryItemDateEdit;
      clSummerFinished.DisplayFormat.FormatString = "hh:mm";
      clSummerFinished.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clSummerFinished.FieldName = "SummerFinished";
      clSummerFinished.Name = "clSummerFinished";
      clSummerFinished.OptionsColumn.AllowMove = false;
      clSummerFinished.OptionsColumn.FixedWidth = true;
      // 
      // gbWinter
      // 
      gbWinter.AppearanceHeader.Options.UseTextOptions = true;
      gbWinter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(gbWinter, "gbWinter");
      gbWinter.Columns.Add(clWinterStarting);
      gbWinter.Columns.Add(clWinterFinished);
      gbWinter.OptionsBand.AllowMove = false;
      gbWinter.OptionsBand.FixedWidth = true;
      gbWinter.VisibleIndex = 2;
      // 
      // clWinterStarting
      // 
      clWinterStarting.AppearanceHeader.Options.UseTextOptions = true;
      clWinterStarting.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clWinterStarting, "clWinterStarting");
      clWinterStarting.ColumnEdit = repositoryItemDateEdit;
      clWinterStarting.DisplayFormat.FormatString = "hh:mm";
      clWinterStarting.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clWinterStarting.FieldName = "WinterStarting";
      clWinterStarting.Name = "clWinterStarting";
      clWinterStarting.OptionsColumn.AllowMove = false;
      clWinterStarting.OptionsColumn.FixedWidth = true;
      // 
      // clWinterFinished
      // 
      clWinterFinished.AppearanceHeader.Options.UseTextOptions = true;
      clWinterFinished.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      resources.ApplyResources(clWinterFinished, "clWinterFinished");
      clWinterFinished.ColumnEdit = repositoryItemDateEdit;
      clWinterFinished.DisplayFormat.FormatString = "hh:mm";
      clWinterFinished.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      clWinterFinished.FieldName = "WinterFinished";
      clWinterFinished.Name = "clWinterFinished";
      clWinterFinished.OptionsColumn.AllowMove = false;
      clWinterFinished.OptionsColumn.FixedWidth = true;
      // 
      // gnSession
      // 
      gnSession.Appearance.BackColor = (Color)resources.GetObject("gnSession.Appearance.BackColor");
      gnSession.Appearance.Font = (Font)resources.GetObject("gnSession.Appearance.Font");
      gnSession.Appearance.Options.UseBackColor = true;
      gnSession.Appearance.Options.UseFont = true;
      resources.ApplyResources(gnSession, "gnSession");
      gnSession.Name = "gnSession";
      gnSession.View = null;
      // 
      // TradeSessionDlg
      // 
      Appearance.Options.UseFont = true;
      resources.ApplyResources(this, "$this");
      IconOptions.Icon = (Icon)resources.GetObject("TradeSessionDlg.IconOptions.Icon");
      Name = "TradeSessionDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pnlSession).EndInit();
      pnlSession.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gridSession).EndInit();
      ((System.ComponentModel.ISupportInitialize)gvSession).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit.CalendarTimeProperties).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Components.Panel pnlSession;
    public DevExpress.XtraGrid.GridControl gridSession;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvSession;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clName;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clDescription;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clSummerStarting;
    private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clSummerFinished;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clWinterStarting;
    private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clWinterFinished;
    private EditControls.GridNavigator gnSession;
    private DevExpress.XtraEditors.SplitterControl splitterControl;
    private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbName;
    private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbSummer;
    private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbWinter;
  }
}
