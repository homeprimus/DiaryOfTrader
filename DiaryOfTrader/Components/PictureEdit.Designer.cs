// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.Components
{
  partial class PictureEdit
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureEdit));
      pnlCenter = new Panel();
      Picture = new DevExpress.XtraEditors.PictureEdit();
      bmPicture = new DevExpress.XtraBars.BarManager(components);
      bar2 = new DevExpress.XtraBars.Bar();
      bbtAdd = new DevExpress.XtraBars.BarButtonItem();
      bbtEdit = new DevExpress.XtraBars.BarButtonItem();
      bbtDelete = new DevExpress.XtraBars.BarButtonItem();
      bbtRefresh = new DevExpress.XtraBars.BarButtonItem();
      bbiStrech = new DevExpress.XtraBars.BarButtonItem();
      bbiClip = new DevExpress.XtraBars.BarButtonItem();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      ((System.ComponentModel.ISupportInitialize)pnlCenter).BeginInit();
      pnlCenter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)Picture.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmPicture).BeginInit();
      SuspendLayout();
      // 
      // pnlCenter
      // 
      pnlCenter.Appearance.BackColor = Color.Transparent;
      pnlCenter.Appearance.Options.UseBackColor = true;
      pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlCenter.Controls.Add(Picture);
      pnlCenter.Dock = DockStyle.Fill;
      pnlCenter.Location = new Point(0, 24);
      pnlCenter.Name = "pnlCenter";
      pnlCenter.Size = new Size(411, 415);
      pnlCenter.TabIndex = 1;
      // 
      // Picture
      // 
      Picture.Dock = DockStyle.Fill;
      Picture.Location = new Point(0, 0);
      Picture.Name = "Picture";
      Picture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
      Picture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
      Picture.Size = new Size(411, 415);
      Picture.TabIndex = 0;
      // 
      // bmPicture
      // 
      bmPicture.AllowCustomization = false;
      bmPicture.AllowHtmlText = true;
      bmPicture.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
      bmPicture.DockControls.Add(barDockControlTop);
      bmPicture.DockControls.Add(barDockControlBottom);
      bmPicture.DockControls.Add(barDockControlLeft);
      bmPicture.DockControls.Add(barDockControlRight);
      bmPicture.Form = this;
      bmPicture.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbtDelete, bbtAdd, bbtEdit, bbtRefresh, bbiStrech, bbiClip });
      bmPicture.MainMenu = bar2;
      bmPicture.MaxItemId = 6;
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbtAdd), new DevExpress.XtraBars.LinkPersistInfo(bbtEdit), new DevExpress.XtraBars.LinkPersistInfo(bbtDelete), new DevExpress.XtraBars.LinkPersistInfo(bbtRefresh), new DevExpress.XtraBars.LinkPersistInfo(bbiStrech), new DevExpress.XtraBars.LinkPersistInfo(bbiClip) });
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
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
      bbtEdit.ItemClick += bbtEdit_ItemClick;
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
      // bbiStrech
      // 
      bbiStrech.Caption = "barButtonItem1";
      bbiStrech.Id = 4;
      bbiStrech.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiStrech.ImageOptions.SvgImage");
      bbiStrech.Name = "bbiStrech";
      bbiStrech.ItemClick += bbiStrech_ItemClick;
      // 
      // bbiClip
      // 
      bbiClip.Caption = "barButtonItem1";
      bbiClip.Id = 5;
      bbiClip.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiClip.ImageOptions.SvgImage");
      bbiClip.Name = "bbiClip";
      bbiClip.ItemClick += bbiClip_ItemClick;
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmPicture;
      barDockControlTop.Size = new Size(411, 24);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 439);
      barDockControlBottom.Manager = bmPicture;
      barDockControlBottom.Size = new Size(411, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 24);
      barDockControlLeft.Manager = bmPicture;
      barDockControlLeft.Size = new Size(0, 415);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(411, 24);
      barDockControlRight.Manager = bmPicture;
      barDockControlRight.Size = new Size(0, 415);
      // 
      // PictureEdit
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pnlCenter);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "PictureEdit";
      Size = new Size(411, 439);
      ((System.ComponentModel.ISupportInitialize)pnlCenter).EndInit();
      pnlCenter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)Picture.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)bmPicture).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Panel pnlCenter;
    private DevExpress.XtraEditors.PictureEdit Picture;
    public DevExpress.XtraBars.BarManager bmPicture;
    public DevExpress.XtraBars.Bar bar2;
    public DevExpress.XtraBars.BarButtonItem bbtAdd;
    public DevExpress.XtraBars.BarButtonItem bbtEdit;
    public DevExpress.XtraBars.BarButtonItem bbtDelete;
    public DevExpress.XtraBars.BarButtonItem bbtRefresh;
    public DevExpress.XtraBars.BarDockControl barDockControlTop;
    public DevExpress.XtraBars.BarDockControl barDockControlBottom;
    public DevExpress.XtraBars.BarDockControl barDockControlLeft;
    public DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarButtonItem bbiStrech;
    private DevExpress.XtraBars.BarButtonItem bbiClip;
  }
}
