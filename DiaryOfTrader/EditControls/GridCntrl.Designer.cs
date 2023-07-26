// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls
{
  partial class GridCntrl
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
      gridNavigator = new GridNavigator();
      grid = new DevExpress.XtraGrid.GridControl();
      gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      gcName = new DevExpress.XtraGrid.Columns.GridColumn();
      gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemMemoExEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
      gcOrder = new DevExpress.XtraGrid.Columns.GridColumn();
      repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
      ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit).BeginInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).BeginInit();
      SuspendLayout();
      // 
      // gridNavigator
      // 
      gridNavigator.Appearance.BackColor = Color.Transparent;
      gridNavigator.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      gridNavigator.Appearance.Options.UseBackColor = true;
      gridNavigator.Appearance.Options.UseFont = true;
      gridNavigator.Dock = DockStyle.Top;
      gridNavigator.Location = new Point(0, 0);
      gridNavigator.Name = "gridNavigator";
      gridNavigator.Size = new Size(352, 27);
      gridNavigator.TabIndex = 5;
      gridNavigator.View = null;
      // 
      // grid
      // 
      grid.Dock = DockStyle.Fill;
      grid.Location = new Point(0, 27);
      grid.MainView = gridView;
      grid.Name = "grid";
      grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoEdit, repositoryItemMemoExEdit });
      grid.Size = new Size(352, 136);
      grid.TabIndex = 6;
      grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
      // 
      // gridView
      // 
      gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gcName, gcDescription, gcOrder });
      gridView.GridControl = grid;
      gridView.Name = "gridView";
      gridView.OptionsBehavior.AllowIncrementalSearch = true;
      gridView.OptionsCustomization.AllowColumnMoving = false;
      gridView.OptionsCustomization.AllowGroup = false;
      gridView.OptionsCustomization.AllowQuickHideColumns = false;
      gridView.OptionsView.RowAutoHeight = true;
      gridView.OptionsView.ShowDetailButtons = false;
      gridView.OptionsView.ShowGroupPanel = false;
      // 
      // gcName
      // 
      gcName.AppearanceHeader.Options.UseTextOptions = true;
      gcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      gcName.Caption = "Наименование";
      gcName.FieldName = "Name";
      gcName.Name = "gcName";
      gcName.UnboundDataType = typeof(string);
      gcName.Visible = true;
      gcName.VisibleIndex = 0;
      gcName.Width = 110;
      // 
      // gcDescription
      // 
      gcDescription.AppearanceHeader.Options.UseTextOptions = true;
      gcDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      gcDescription.Caption = "Описание";
      gcDescription.ColumnEdit = repositoryItemMemoEdit;
      gcDescription.FieldName = "Description";
      gcDescription.Name = "gcDescription";
      gcDescription.UnboundDataType = typeof(string);
      gcDescription.Visible = true;
      gcDescription.VisibleIndex = 1;
      gcDescription.Width = 152;
      // 
      // repositoryItemMemoExEdit
      // 
      repositoryItemMemoExEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      repositoryItemMemoExEdit.Name = "repositoryItemMemoExEdit";
      // 
      // gcOrder
      // 
      gcOrder.AppearanceHeader.Options.UseTextOptions = true;
      gcOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      gcOrder.Caption = "Сортировка";
      gcOrder.FieldName = "Order";
      gcOrder.MinWidth = 50;
      gcOrder.Name = "gcOrder";
      gcOrder.OptionsColumn.FixedWidth = true;
      gcOrder.UnboundDataType = typeof(int);
      gcOrder.Visible = true;
      gcOrder.VisibleIndex = 2;
      gcOrder.Width = 70;
      // 
      // repositoryItemMemoEdit
      // 
      repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
      // 
      // GridCntrl
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(grid);
      Controls.Add(gridNavigator);
      Name = "GridCntrl";
      Size = new Size(352, 163);
      ((System.ComponentModel.ISupportInitialize)grid).EndInit();
      ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit).EndInit();
      ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private GridNavigator gridNavigator;
    public DevExpress.XtraGrid.GridControl grid;
    public DevExpress.XtraGrid.Views.Grid.GridView gridView;
    public DevExpress.XtraGrid.Columns.GridColumn gcName;
    public DevExpress.XtraGrid.Columns.GridColumn gcDescription;
    public DevExpress.XtraGrid.Columns.GridColumn gcOrder;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit;
  }
}
