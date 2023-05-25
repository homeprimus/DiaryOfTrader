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
      components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(GridCntrl));
      pmGrid = new DevExpress.XtraBars.PopupMenu(components);
      bmGrid = new DevExpress.XtraBars.BarManager(components);
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      bar2 = new DevExpress.XtraBars.Bar();
      bbtDelete = new DevExpress.XtraBars.BarButtonItem();
      bbtAdd = new DevExpress.XtraBars.BarButtonItem();
      gcDictionary = new DevExpress.XtraGrid.GridControl();
      gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      bbEdit = new DevExpress.XtraBars.BarButtonItem();
      ((System.ComponentModel.ISupportInitialize)pmGrid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gcDictionary).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
      SuspendLayout();
      // 
      // pmGrid
      // 
      pmGrid.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete), new DevExpress.XtraBars.LinkPersistInfo(bbEdit) });
      pmGrid.Manager = bmGrid;
      pmGrid.Name = "pmGrid";
      // 
      // bmGrid
      // 
      bmGrid.AllowCustomization = false;
      bmGrid.AllowHtmlText = true;
      bmGrid.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
      bmGrid.DockControls.Add(barDockControlTop);
      bmGrid.DockControls.Add(barDockControlBottom);
      bmGrid.DockControls.Add(barDockControlLeft);
      bmGrid.DockControls.Add(barDockControlRight);
      bmGrid.Form = this;
      bmGrid.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbtDelete, bbtAdd, bbEdit });
      bmGrid.MainMenu = bar2;
      bmGrid.MaxItemId = 3;
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmGrid;
      barDockControlTop.Size = new Size(441, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 191);
      barDockControlBottom.Manager = bmGrid;
      barDockControlBottom.Size = new Size(441, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmGrid;
      barDockControlLeft.Size = new Size(0, 167);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(441, 24);
      barDockControlRight.Manager = bmGrid;
      barDockControlRight.Size = new Size(0, 167);
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbEdit), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete) });
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
      // 
      // bbtDelete
      // 
      bbtDelete.Caption = "Удалить";
      bbtDelete.Id = 0;
      bbtDelete.ImageOptions.Image = (Image)resources.GetObject("bbtDelete.ImageOptions.Image");
      bbtDelete.ImageOptions.LargeImage = (Image)resources.GetObject("bbtDelete.ImageOptions.LargeImage");
      bbtDelete.Name = "bbtDelete";
      // 
      // bbtAdd
      // 
      bbtAdd.Caption = "Новая запись";
      bbtAdd.Id = 1;
      bbtAdd.ImageOptions.Image = (Image)resources.GetObject("bbtAdd.ImageOptions.Image");
      bbtAdd.ImageOptions.LargeImage = (Image)resources.GetObject("bbtAdd.ImageOptions.LargeImage");
      bbtAdd.Name = "bbtAdd";
      // 
      // gcDictionary
      // 
      gcDictionary.Dock = DockStyle.Fill;
      gcDictionary.Location = new Point(0, 24);
      gcDictionary.MainView = gridView1;
      gcDictionary.MenuManager = bmGrid;
      gcDictionary.Name = "gcDictionary";
      gcDictionary.Size = new Size(441, 167);
      gcDictionary.TabIndex = 4;
      gcDictionary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
      // 
      // gridView1
      // 
      gridView1.GridControl = gcDictionary;
      gridView1.Name = "gridView1";
      // 
      // bbEdit
      // 
      bbEdit.Caption = "Изменить";
      bbEdit.Id = 2;
      bbEdit.ImageOptions.Image = (Image)resources.GetObject("bbEdit.ImageOptions.Image");
      bbEdit.ImageOptions.LargeImage = (Image)resources.GetObject("bbEdit.ImageOptions.LargeImage");
      bbEdit.Name = "bbEdit";
      // 
      // GridCntrl
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(gcDictionary);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "GridCntrl";
      Size = new Size(441, 191);
      ((System.ComponentModel.ISupportInitialize)pmGrid).EndInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).EndInit();
      ((System.ComponentModel.ISupportInitialize)gcDictionary).EndInit();
      ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.PopupMenu pmGrid;
    private DevExpress.XtraBars.BarButtonItem bbtAdd;
    private DevExpress.XtraBars.BarButtonItem bbtDelete;
    private DevExpress.XtraBars.BarManager bmGrid;
    private DevExpress.XtraBars.Bar bar2;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarButtonItem bbEdit;
    private DevExpress.XtraGrid.GridControl gcDictionary;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
  }
}
