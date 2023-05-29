// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls
{
  partial class GridNavigator
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(GridNavigator));
      pmGrid = new DevExpress.XtraBars.PopupMenu(components);
      bbtAdd = new DevExpress.XtraBars.BarButtonItem();
      bbtDelete = new DevExpress.XtraBars.BarButtonItem();
      bbEdit = new DevExpress.XtraBars.BarButtonItem();
      bbRefresh = new DevExpress.XtraBars.BarButtonItem();
      bmGrid = new DevExpress.XtraBars.BarManager(components);
      bar2 = new DevExpress.XtraBars.Bar();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      ((System.ComponentModel.ISupportInitialize)pmGrid).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).BeginInit();
      SuspendLayout();
      // 
      // pmGrid
      // 
      pmGrid.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete), new DevExpress.XtraBars.LinkPersistInfo(bbEdit), new DevExpress.XtraBars.LinkPersistInfo(bbRefresh) });
      pmGrid.Manager = bmGrid;
      pmGrid.Name = "pmGrid";
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
      // bbtDelete
      // 
      bbtDelete.Caption = "Удалить";
      bbtDelete.Id = 0;
      bbtDelete.ImageOptions.Image = (Image)resources.GetObject("bbtDelete.ImageOptions.Image");
      bbtDelete.ImageOptions.LargeImage = (Image)resources.GetObject("bbtDelete.ImageOptions.LargeImage");
      bbtDelete.Name = "bbtDelete";
      bbtDelete.ItemClick += bbtDelete_ItemClick;
      // 
      // bbEdit
      // 
      bbEdit.Caption = "Изменить";
      bbEdit.Id = 2;
      bbEdit.ImageOptions.Image = (Image)resources.GetObject("bbEdit.ImageOptions.Image");
      bbEdit.ImageOptions.LargeImage = (Image)resources.GetObject("bbEdit.ImageOptions.LargeImage");
      bbEdit.Name = "bbEdit";
      bbEdit.ItemClick += bbEdit_ItemClick;
      // 
      // bbRefresh
      // 
      bbRefresh.Caption = "Обновить";
      bbRefresh.Id = 3;
      bbRefresh.ImageOptions.Image = (Image)resources.GetObject("bbRefresh.ImageOptions.Image");
      bbRefresh.ImageOptions.LargeImage = (Image)resources.GetObject("bbRefresh.ImageOptions.LargeImage");
      bbRefresh.Name = "bbRefresh";
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
      bmGrid.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbtDelete, bbtAdd, bbEdit, bbRefresh });
      bmGrid.MainMenu = bar2;
      bmGrid.MaxItemId = 4;
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbEdit), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete), new DevExpress.XtraBars.LinkPersistInfo(bbRefresh) });
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
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
      barDockControlBottom.Location = new Point(0, 27);
      barDockControlBottom.Manager = bmGrid;
      barDockControlBottom.Size = new Size(441, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmGrid;
      barDockControlLeft.Size = new Size(0, 3);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(441, 24);
      barDockControlRight.Manager = bmGrid;
      barDockControlRight.Size = new Size(0, 3);
      // 
      // GridNavigator
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "GridNavigator";
      Size = new Size(441, 27);
      ((System.ComponentModel.ISupportInitialize)pmGrid).EndInit();
      ((System.ComponentModel.ISupportInitialize)bmGrid).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    public DevExpress.XtraBars.PopupMenu pmGrid;
    public DevExpress.XtraBars.BarButtonItem bbtAdd;
    public DevExpress.XtraBars.BarButtonItem bbtDelete;
    public DevExpress.XtraBars.BarManager bmGrid;
    public DevExpress.XtraBars.BarDockControl barDockControlTop;
    public DevExpress.XtraBars.BarDockControl barDockControlBottom;
    public DevExpress.XtraBars.BarDockControl barDockControlLeft;
    public DevExpress.XtraBars.BarDockControl barDockControlRight;
    public DevExpress.XtraBars.BarButtonItem bbEdit;
    public DevExpress.XtraBars.BarButtonItem bbRefresh;
    public DevExpress.XtraBars.Bar bar2;
  }
}
