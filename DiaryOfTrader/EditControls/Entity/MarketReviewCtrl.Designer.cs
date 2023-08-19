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
      pnlHeader = new Panel();
      pnlClient = new Panel();
      gnReview = new GridNavigator();
      gcTimeFrame = new DevExpress.XtraGrid.GridControl();
      gvTimeFrame = new DevExpress.XtraGrid.Views.Grid.GridView();
      clTimeFrame = new DevExpress.XtraGrid.Columns.GridColumn();
      clTrend = new DevExpress.XtraGrid.Columns.GridColumn();
      clImage = new DevExpress.XtraGrid.Columns.GridColumn();
      clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      pnlClient.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gcTimeFrame).BeginInit();
      ((System.ComponentModel.ISupportInitialize)gvTimeFrame).BeginInit();
      SuspendLayout();
      // 
      // pnlHeader
      // 
      pnlHeader.Dock = DockStyle.Top;
      pnlHeader.Location = new Point(0, 0);
      pnlHeader.Name = "pnlHeader";
      pnlHeader.Size = new Size(488, 46);
      pnlHeader.TabIndex = 0;
      // 
      // pnlClient
      // 
      pnlClient.Controls.Add(gcTimeFrame);
      pnlClient.Controls.Add(gnReview);
      pnlClient.Dock = DockStyle.Fill;
      pnlClient.Location = new Point(0, 46);
      pnlClient.Name = "pnlClient";
      pnlClient.Padding = new Padding(3, 0, 3, 0);
      pnlClient.Size = new Size(488, 195);
      pnlClient.TabIndex = 1;
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
      gnReview.Size = new Size(482, 27);
      gnReview.TabIndex = 0;
      // 
      // gcTimeFrame
      // 
      gcTimeFrame.Dock = DockStyle.Fill;
      gcTimeFrame.Location = new Point(3, 27);
      gcTimeFrame.MainView = gvTimeFrame;
      gcTimeFrame.Name = "gcTimeFrame";
      gcTimeFrame.Size = new Size(482, 168);
      gcTimeFrame.TabIndex = 1;
      gcTimeFrame.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvTimeFrame });
      // 
      // gvTimeFrame
      // 
      gvTimeFrame.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { clTimeFrame, clTrend, clImage, clDescription });
      gvTimeFrame.GridControl = gcTimeFrame;
      gvTimeFrame.Name = "gvTimeFrame";
      gvTimeFrame.OptionsView.ShowGroupPanel = false;
      // 
      // clTimeFrame
      // 
      clTimeFrame.Caption = "ТаймФрейм";
      clTimeFrame.FieldName = "FrameFrame";
      clTimeFrame.Name = "clTimeFrame";
      clTimeFrame.Visible = true;
      clTimeFrame.VisibleIndex = 0;
      // 
      // clTrend
      // 
      clTrend.Caption = "Тренд";
      clTrend.FieldName = "Trend";
      clTrend.Name = "clTrend";
      clTrend.Visible = true;
      clTrend.VisibleIndex = 1;
      // 
      // clImage
      // 
      clImage.Caption = "Снимок";
      clImage.FieldName = "Image";
      clImage.Name = "clImage";
      clImage.Visible = true;
      clImage.VisibleIndex = 2;
      // 
      // clDescription
      // 
      clDescription.Caption = "Анализ";
      clDescription.FieldName = "Description";
      clDescription.Name = "clDescription";
      clDescription.Visible = true;
      clDescription.VisibleIndex = 3;
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
      Size = new Size(488, 241);
      pnlClient.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gcTimeFrame).EndInit();
      ((System.ComponentModel.ISupportInitialize)gvTimeFrame).EndInit();
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
  }
}
