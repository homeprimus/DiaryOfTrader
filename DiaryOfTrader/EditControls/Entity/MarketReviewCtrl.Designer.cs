// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls.Entity
{
  partial class MarketReviewCtrl
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
      pnlHeader = new Panel();
      mmDescription = new Components.MemoEdit();
      lblDescription = new Label();
      lblName = new Label();
      txtName = new Components.TextBox();
      lblCoin = new Label();
      lcbSymbol = new Components.LookComboBox(components);
      lblExchange = new Label();
      lcbExchange = new Components.LookComboBox(components);
      lblDate = new Label();
      dateEdit = new DevExpress.XtraEditors.DateEdit();
      pnlClient = new Panel();
      gcTimeFrame = new DevExpress.XtraGrid.GridControl();
      gvTimeFrame = new DevExpress.XtraGrid.Views.Grid.GridView();
      clTimeFrame = new DevExpress.XtraGrid.Columns.GridColumn();
      luFrame = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      clTrend = new DevExpress.XtraGrid.Columns.GridColumn();
      luTrend = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      clImage = new DevExpress.XtraGrid.Columns.GridColumn();
      ieImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
      clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      meDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
      gnReview = new GridNavigator();
      pnlHeader.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)lcbSymbol.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)lcbExchange.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)dateEdit.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)dateEdit.Properties.CalendarTimeProperties).BeginInit();
      pnlClient.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gcTimeFrame).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvTimeFrame).BeginInit();
      ((System.ComponentModel.ISupportInitialize)luFrame).BeginInit();
      ((System.ComponentModel.ISupportInitialize)luTrend).BeginInit();
      ((System.ComponentModel.ISupportInitialize)ieImage).BeginInit();
      ((System.ComponentModel.ISupportInitialize)meDescription).BeginInit();
      SuspendLayout();
      // 
      // pnlHeader
      // 
      pnlHeader.Controls.Add(mmDescription);
      pnlHeader.Controls.Add(lblDescription);
      pnlHeader.Controls.Add(lblName);
      pnlHeader.Controls.Add(txtName);
      pnlHeader.Controls.Add(lblCoin);
      pnlHeader.Controls.Add(lcbSymbol);
      pnlHeader.Controls.Add(lblExchange);
      pnlHeader.Controls.Add(lcbExchange);
      pnlHeader.Controls.Add(lblDate);
      pnlHeader.Controls.Add(dateEdit);
      pnlHeader.Dock = DockStyle.Top;
      pnlHeader.Location = new Point(0, 0);
      pnlHeader.Name = "pnlHeader";
      pnlHeader.Size = new Size(873, 127);
      pnlHeader.TabIndex = 0;
      // 
      // mmDescription
      // 
      mmDescription.Location = new Point(105, 70);
      mmDescription.Name = "mmDescription";
      mmDescription.Properties.Appearance.BackColor = Color.Transparent;
      mmDescription.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      mmDescription.Properties.Appearance.Options.UseBackColor = true;
      mmDescription.Properties.Appearance.Options.UseFont = true;
      mmDescription.Size = new Size(753, 46);
      mmDescription.TabIndex = 9;
      // 
      // lblDescription
      // 
      lblDescription.AutoSize = true;
      lblDescription.Location = new Point(18, 72);
      lblDescription.Name = "lblDescription";
      lblDescription.Size = new Size(56, 13);
      lblDescription.TabIndex = 8;
      lblDescription.Text = "Описание";
      // 
      // lblName
      // 
      lblName.AutoSize = true;
      lblName.Location = new Point(18, 47);
      lblName.Name = "lblName";
      lblName.Size = new Size(80, 13);
      lblName.TabIndex = 7;
      lblName.Text = "Наименование";
      // 
      // txtName
      // 
      txtName.Location = new Point(105, 44);
      txtName.MaxLength = 0;
      txtName.Name = "txtName";
      txtName.Properties.Appearance.BackColor = Color.Transparent;
      txtName.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      txtName.Properties.Appearance.Options.UseBackColor = true;
      txtName.Properties.Appearance.Options.UseFont = true;
      txtName.Size = new Size(753, 20);
      txtName.TabIndex = 6;
      // 
      // lblCoin
      // 
      lblCoin.AutoSize = true;
      lblCoin.Location = new Point(573, 21);
      lblCoin.Name = "lblCoin";
      lblCoin.Size = new Size(67, 13);
      lblCoin.TabIndex = 5;
      lblCoin.Text = "Инструмент";
      // 
      // lcbSymbol
      // 
      lcbSymbol.Location = new Point(646, 18);
      lcbSymbol.Name = "lcbSymbol";
      lcbSymbol.Properties.Appearance.BackColor = Color.Transparent;
      lcbSymbol.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      lcbSymbol.Properties.Appearance.Options.UseBackColor = true;
      lcbSymbol.Properties.Appearance.Options.UseFont = true;
      lcbSymbol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      lcbSymbol.Properties.NullText = "";
      lcbSymbol.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      lcbSymbol.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
      lcbSymbol.Properties.ShowFooter = false;
      lcbSymbol.Properties.ShowHeader = false;
      lcbSymbol.Size = new Size(212, 20);
      lcbSymbol.TabIndex = 4;
      // 
      // lblExchange
      // 
      lblExchange.AutoSize = true;
      lblExchange.Location = new Point(275, 21);
      lblExchange.Name = "lblExchange";
      lblExchange.Size = new Size(39, 13);
      lblExchange.TabIndex = 3;
      lblExchange.Text = "Биржа";
      // 
      // lcbExchange
      // 
      lcbExchange.Location = new Point(320, 18);
      lcbExchange.Name = "lcbExchange";
      lcbExchange.Properties.Appearance.BackColor = Color.Transparent;
      lcbExchange.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      lcbExchange.Properties.Appearance.Options.UseBackColor = true;
      lcbExchange.Properties.Appearance.Options.UseFont = true;
      lcbExchange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      lcbExchange.Properties.NullText = "";
      lcbExchange.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      lcbExchange.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
      lcbExchange.Properties.ShowFooter = false;
      lcbExchange.Properties.ShowHeader = false;
      lcbExchange.Size = new Size(227, 20);
      lcbExchange.TabIndex = 2;
      // 
      // lblDate
      // 
      lblDate.AutoSize = true;
      lblDate.Location = new Point(18, 21);
      lblDate.Name = "lblDate";
      lblDate.Size = new Size(33, 13);
      lblDate.TabIndex = 1;
      lblDate.Text = "Дата";
      // 
      // dateEdit
      // 
      dateEdit.EditValue = new DateTime(2023, 9, 3, 13, 30, 13, 766);
      dateEdit.Location = new Point(104, 18);
      dateEdit.Name = "dateEdit";
      dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      dateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
      dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      dateEdit.Size = new Size(136, 20);
      dateEdit.TabIndex = 0;
      // 
      // pnlClient
      // 
      pnlClient.Controls.Add(gcTimeFrame);
      pnlClient.Controls.Add(gnReview);
      pnlClient.Dock = DockStyle.Fill;
      pnlClient.Location = new Point(0, 127);
      pnlClient.Name = "pnlClient";
      pnlClient.Padding = new Padding(3, 0, 3, 0);
      pnlClient.Size = new Size(873, 421);
      pnlClient.TabIndex = 1;
      // 
      // gcTimeFrame
      // 
      gcTimeFrame.Dock = DockStyle.Fill;
      gcTimeFrame.Location = new Point(3, 27);
      gcTimeFrame.MainView = gvTimeFrame;
      gcTimeFrame.Name = "gcTimeFrame";
      gcTimeFrame.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { luTrend, luFrame, ieImage, meDescription });
      gcTimeFrame.Size = new Size(867, 394);
      gcTimeFrame.TabIndex = 1;
      gcTimeFrame.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvTimeFrame });
      // 
      // gvTimeFrame
      // 
      gvTimeFrame.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clTimeFrame, clTrend, clImage, clDescription });
      gvTimeFrame.GridControl = gcTimeFrame;
      gvTimeFrame.Name = "gvTimeFrame";
      gvTimeFrame.OptionsView.RowAutoHeight = true;
      gvTimeFrame.OptionsView.ShowGroupPanel = false;
      // 
      // clTimeFrame
      // 
      clTimeFrame.Caption = "ТаймФрейм";
      clTimeFrame.ColumnEdit = luFrame;
      clTimeFrame.FieldName = "Frame";
      clTimeFrame.Name = "clTimeFrame";
      clTimeFrame.OptionsColumn.FixedWidth = true;
      clTimeFrame.Visible = true;
      clTimeFrame.VisibleIndex = 0;
      clTimeFrame.Width = 65;
      // 
      // luFrame
      // 
      luFrame.AutoHeight = false;
      luFrame.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      luFrame.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Наименование") });
      luFrame.DisplayMember = "Key";
      luFrame.KeyMember = "Value";
      luFrame.Name = "luFrame";
      luFrame.ValueMember = "Value";
      // 
      // clTrend
      // 
      clTrend.Caption = "Тренд";
      clTrend.ColumnEdit = luTrend;
      clTrend.FieldName = "Trend";
      clTrend.Name = "clTrend";
      clTrend.OptionsColumn.FixedWidth = true;
      clTrend.Visible = true;
      clTrend.VisibleIndex = 1;
      clTrend.Width = 150;
      // 
      // luTrend
      // 
      luTrend.AutoHeight = false;
      luTrend.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      luTrend.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Наименование") });
      luTrend.DisplayMember = "Key";
      luTrend.KeyMember = "Value";
      luTrend.Name = "luTrend";
      luTrend.ValueMember = "Value";
      // 
      // clImage
      // 
      clImage.Caption = "Снимок";
      clImage.ColumnEdit = ieImage;
      clImage.FieldName = "Image";
      clImage.Name = "clImage";
      clImage.OptionsColumn.FixedWidth = true;
      clImage.Visible = true;
      clImage.VisibleIndex = 2;
      clImage.Width = 300;
      // 
      // ieImage
      // 
      ieImage.AutoHeight = false;
      ieImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      ieImage.Name = "ieImage";
      // 
      // clDescription
      // 
      clDescription.Caption = "Анализ";
      clDescription.ColumnEdit = meDescription;
      clDescription.FieldName = "Description";
      clDescription.Name = "clDescription";
      clDescription.Visible = true;
      clDescription.VisibleIndex = 3;
      clDescription.Width = 327;
      // 
      // meDescription
      // 
      meDescription.AutoHeight = false;
      meDescription.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      meDescription.Name = "meDescription";
      meDescription.ShowIcon = false;
      meDescription.WordWrap = false;
      // 
      // gnReview
      // 
      gnReview.Appearance.BackColor = Color.Transparent;
      gnReview.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      gnReview.Appearance.Options.UseBackColor = true;
      gnReview.Appearance.Options.UseFont = true;
      gnReview.Dock = DockStyle.Top;
      gnReview.Location = new Point(3, 0);
      gnReview.Name = "gnReview";
      gnReview.Size = new Size(867, 27);
      gnReview.TabIndex = 0;
      gnReview.View = gvTimeFrame;
      // 
      // MarketReviewCtrl
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pnlClient);
      Controls.Add(pnlHeader);
      Name = "MarketReviewCtrl";
      Size = new Size(873, 548);
      pnlHeader.ResumeLayout(false);
      pnlHeader.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)lcbSymbol.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)lcbExchange.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)dateEdit.Properties.CalendarTimeProperties).EndInit();
      ((System.ComponentModel.ISupportInitialize)dateEdit.Properties).EndInit();
      pnlClient.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gcTimeFrame).EndInit();
      ((System.ComponentModel.ISupportInitialize)gvTimeFrame).EndInit();
      ((System.ComponentModel.ISupportInitialize)luFrame).EndInit();
      ((System.ComponentModel.ISupportInitialize)luTrend).EndInit();
      ((System.ComponentModel.ISupportInitialize)ieImage).EndInit();
      ((System.ComponentModel.ISupportInitialize)meDescription).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Panel pnlClient;
    private DevExpress.XtraGrid.GridControl gcTimeFrame;
    private DevExpress.XtraGrid.Views.Grid.GridView gvTimeFrame;
    private GridNavigator gnReview;
    private DevExpress.XtraGrid.Columns.GridColumn clTimeFrame;
    private DevExpress.XtraGrid.Columns.GridColumn clTrend;
    private DevExpress.XtraGrid.Columns.GridColumn clImage;
    private DevExpress.XtraGrid.Columns.GridColumn clDescription;
    private Label lblExchange;
    private Components.LookComboBox lcbExchange;
    private Label lblDate;
    private DevExpress.XtraEditors.DateEdit dateEdit;
    private Label lblName;
    private Components.TextBox txtName;
    private Label lblCoin;
    private Components.LookComboBox lcbSymbol;
    private Components.MemoEdit mmDescription;
    private Label lblDescription;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTrend;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luFrame;
    private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit ieImage;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit meDescription;
  }
}
