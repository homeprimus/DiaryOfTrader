// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs
{
  partial class MarketReviewDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketReviewDlg));
      marketReviewCtrl = new EditControls.Entity.MarketReviewCtrl();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 486);
      pnlDown.Size = new Size(879, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(marketReviewCtrl);
      pnlClient.Size = new Size(879, 486);
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
      // marketReviewCtrl
      // 
      marketReviewCtrl.Appearance.BackColor = Color.Transparent;
      marketReviewCtrl.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      marketReviewCtrl.Appearance.Options.UseBackColor = true;
      marketReviewCtrl.Appearance.Options.UseFont = true;
      marketReviewCtrl.AutoScroll = true;
      marketReviewCtrl.Dock = DockStyle.Fill;
      marketReviewCtrl.Location = new Point(0, 0);
      marketReviewCtrl.Name = "marketReviewCtrl";
      marketReviewCtrl.Size = new Size(879, 486);
      marketReviewCtrl.TabIndex = 0;
      // 
      // MarketReviewDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(879, 526);
      IconOptions.Icon = (Icon)resources.GetObject("MarketReviewDlg.IconOptions.Icon");
      Name = "MarketReviewDlg";
      Text = "MarketReviewDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private EditControls.Entity.MarketReviewCtrl marketReviewCtrl;
  }
}