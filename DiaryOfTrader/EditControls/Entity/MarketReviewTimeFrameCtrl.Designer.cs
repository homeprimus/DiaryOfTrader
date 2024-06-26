﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditControls.Entity
{
  partial class MarketReviewTimeFrameCtrl
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
      pnlTop = new Panel();
      gcMarketReview = new DevExpress.XtraEditors.GroupControl();
      lblTrend = new Label();
      lcbTrend = new Components.LookComboBox(components);
      lblTimeFrame = new Label();
      lcbTimeFrame = new Components.LookComboBox(components);
      pnlDown = new Panel();
      gcDescription = new DevExpress.XtraEditors.GroupControl();
      mmDescription = new DevExpress.XtraEditors.MemoEdit();
      pnlCenter = new Panel();
      gcTragingView = new DevExpress.XtraEditors.GroupControl();
      tragingView = new Components.TragingView();
      splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
      pnlTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gcMarketReview).BeginInit();
      gcMarketReview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)lcbTrend.Properties).BeginInit();
      ((System.ComponentModel.ISupportInitialize)lcbTimeFrame.Properties).BeginInit();
      pnlDown.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gcDescription).BeginInit();
      gcDescription.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).BeginInit();
      pnlCenter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gcTragingView).BeginInit();
      gcTragingView.SuspendLayout();
      SuspendLayout();
      // 
      // pnlTop
      // 
      pnlTop.Controls.Add(gcMarketReview);
      pnlTop.Dock = DockStyle.Top;
      pnlTop.Location = new Point(0, 0);
      pnlTop.Name = "pnlTop";
      pnlTop.Size = new Size(674, 63);
      pnlTop.TabIndex = 0;
      // 
      // gcMarketReview
      // 
      gcMarketReview.Controls.Add(lblTrend);
      gcMarketReview.Controls.Add(lcbTrend);
      gcMarketReview.Controls.Add(lblTimeFrame);
      gcMarketReview.Controls.Add(lcbTimeFrame);
      gcMarketReview.Dock = DockStyle.Fill;
      gcMarketReview.Location = new Point(0, 0);
      gcMarketReview.Name = "gcMarketReview";
      gcMarketReview.Size = new Size(674, 63);
      gcMarketReview.TabIndex = 0;
      gcMarketReview.Text = "Общее";
      // 
      // lblTrend
      // 
      lblTrend.AutoSize = true;
      lblTrend.Location = new Point(246, 32);
      lblTrend.Name = "lblTrend";
      lblTrend.Size = new Size(42, 13);
      lblTrend.TabIndex = 13;
      lblTrend.Text = "Тренд:";
      // 
      // lcbTrend
      // 
      lcbTrend.Location = new Point(326, 28);
      lcbTrend.Name = "lcbTrend";
      lcbTrend.Properties.Appearance.BackColor = Color.Transparent;
      lcbTrend.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      lcbTrend.Properties.Appearance.Options.UseBackColor = true;
      lcbTrend.Properties.Appearance.Options.UseFont = true;
      lcbTrend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      lcbTrend.Properties.NullText = "";
      lcbTrend.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      lcbTrend.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
      lcbTrend.Properties.ShowFooter = false;
      lcbTrend.Properties.ShowHeader = false;
      lcbTrend.Size = new Size(149, 20);
      lcbTrend.TabIndex = 12;
      // 
      // lblTimeFrame
      // 
      lblTimeFrame.AutoSize = true;
      lblTimeFrame.Location = new Point(14, 32);
      lblTimeFrame.Name = "lblTimeFrame";
      lblTimeFrame.Size = new Size(67, 13);
      lblTimeFrame.TabIndex = 11;
      lblTimeFrame.Text = "Таймфрейм:";
      // 
      // lcbTimeFrame
      // 
      lcbTimeFrame.Location = new Point(83, 28);
      lcbTimeFrame.Name = "lcbTimeFrame";
      lcbTimeFrame.Properties.Appearance.BackColor = Color.Transparent;
      lcbTimeFrame.Properties.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      lcbTimeFrame.Properties.Appearance.Options.UseBackColor = true;
      lcbTimeFrame.Properties.Appearance.Options.UseFont = true;
      lcbTimeFrame.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      lcbTimeFrame.Properties.NullText = "";
      lcbTimeFrame.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      lcbTimeFrame.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
      lcbTimeFrame.Properties.ShowFooter = false;
      lcbTimeFrame.Properties.ShowHeader = false;
      lcbTimeFrame.Size = new Size(137, 20);
      lcbTimeFrame.TabIndex = 10;
      // 
      // pnlDown
      // 
      pnlDown.Controls.Add(gcDescription);
      pnlDown.Dock = DockStyle.Bottom;
      pnlDown.Location = new Point(0, 448);
      pnlDown.Name = "pnlDown";
      pnlDown.Padding = new Padding(5);
      pnlDown.Size = new Size(674, 119);
      pnlDown.TabIndex = 1;
      // 
      // gcDescription
      // 
      gcDescription.Controls.Add(mmDescription);
      gcDescription.Dock = DockStyle.Fill;
      gcDescription.Location = new Point(5, 5);
      gcDescription.Name = "gcDescription";
      gcDescription.Size = new Size(664, 109);
      gcDescription.TabIndex = 0;
      gcDescription.Text = "Анализ таймфрейма";
      // 
      // mmDescription
      // 
      mmDescription.Dock = DockStyle.Fill;
      mmDescription.Location = new Point(2, 23);
      mmDescription.Name = "mmDescription";
      mmDescription.Size = new Size(660, 84);
      mmDescription.TabIndex = 1;
      // 
      // pnlCenter
      // 
      pnlCenter.Controls.Add(gcTragingView);
      pnlCenter.Controls.Add(splitterControl1);
      pnlCenter.Dock = DockStyle.Fill;
      pnlCenter.Location = new Point(0, 63);
      pnlCenter.Name = "pnlCenter";
      pnlCenter.Size = new Size(674, 385);
      pnlCenter.TabIndex = 2;
      // 
      // gcTragingView
      // 
      gcTragingView.Controls.Add(tragingView);
      gcTragingView.Dock = DockStyle.Fill;
      gcTragingView.Location = new Point(0, 0);
      gcTragingView.Name = "gcTragingView";
      gcTragingView.Size = new Size(674, 375);
      gcTragingView.TabIndex = 2;
      gcTragingView.Text = "График торговли";
      // 
      // tragingView
      // 
      tragingView.Dock = DockStyle.Fill;
      tragingView.EnabledTimeFrame = false;
      tragingView.Location = new Point(2, 23);
      tragingView.LowGroup = false;
      tragingView.Name = "tragingView";
      tragingView.Size = new Size(670, 350);
      tragingView.TabIndex = 0;
      tragingView.VisibleSymbol = false;
      // 
      // splitterControl1
      // 
      splitterControl1.Dock = DockStyle.Bottom;
      splitterControl1.Location = new Point(0, 375);
      splitterControl1.Name = "splitterControl1";
      splitterControl1.Size = new Size(674, 10);
      splitterControl1.TabIndex = 1;
      splitterControl1.TabStop = false;
      // 
      // MarketReviewTimeFrameCtrl
      // 
      Appearance.BackColor = Color.Transparent;
      Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      Appearance.Options.UseBackColor = true;
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pnlCenter);
      Controls.Add(pnlDown);
      Controls.Add(pnlTop);
      Name = "MarketReviewTimeFrameCtrl";
      Size = new Size(674, 567);
      pnlTop.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gcMarketReview).EndInit();
      gcMarketReview.ResumeLayout(false);
      gcMarketReview.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)lcbTrend.Properties).EndInit();
      ((System.ComponentModel.ISupportInitialize)lcbTimeFrame.Properties).EndInit();
      pnlDown.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gcDescription).EndInit();
      gcDescription.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).EndInit();
      pnlCenter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gcTragingView).EndInit();
      gcTragingView.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Panel pnlDown;
    private Panel pnlCenter;
    private DevExpress.XtraEditors.GroupControl gcDescription;
    private DevExpress.XtraEditors.MemoEdit mmDescription;
    private DevExpress.XtraEditors.GroupControl gcTragingView;
    private DevExpress.XtraEditors.SplitterControl splitterControl1;
    private DevExpress.XtraEditors.GroupControl gcMarketReview;
    private Label lblTrend;
    private Components.LookComboBox lcbTrend;
    private Label lblTimeFrame;
    private Components.LookComboBox lcbTimeFrame;
    private Components.TragingView tragingView;
  }
}
