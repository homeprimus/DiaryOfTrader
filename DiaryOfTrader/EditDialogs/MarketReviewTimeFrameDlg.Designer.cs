// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs
{
  partial class MarketReviewTimeFrameDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketReviewTimeFrameDlg));
      marketReviewTimeFrameCtrl = new EditControls.Entity.MarketReviewTimeFrameCtrl();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 544);
      pnlDown.Size = new Size(1008, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(marketReviewTimeFrameCtrl);
      pnlClient.Size = new Size(1008, 544);
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
      // marketReviewTimeFrameCtrl
      // 
      marketReviewTimeFrameCtrl.Appearance.BackColor = Color.Transparent;
      marketReviewTimeFrameCtrl.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      marketReviewTimeFrameCtrl.Appearance.Options.UseBackColor = true;
      marketReviewTimeFrameCtrl.Appearance.Options.UseFont = true;
      marketReviewTimeFrameCtrl.AutoScroll = true;
      marketReviewTimeFrameCtrl.Dock = DockStyle.Fill;
      marketReviewTimeFrameCtrl.Location = new Point(0, 0);
      marketReviewTimeFrameCtrl.Name = "marketReviewTimeFrameCtrl";
      marketReviewTimeFrameCtrl.Size = new Size(1008, 544);
      marketReviewTimeFrameCtrl.TabIndex = 0;
      // 
      // MarketReviewTimeFrameDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(1008, 584);
      IconOptions.Icon = (Icon)resources.GetObject("MarketReviewTimeFrameDlg.IconOptions.Icon");
      Name = "MarketReviewTimeFrameDlg";
      Text = "MarketReviewTimeFrameDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private EditControls.Entity.MarketReviewTimeFrameCtrl marketReviewTimeFrameCtrl;
  }
}