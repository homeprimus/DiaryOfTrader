// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs.Dictionary
{
  partial class ResultDlg
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
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // grid
      // 
      grid.Appearance.BackColor = Color.Transparent;
      grid.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      grid.Appearance.Options.UseBackColor = true;
      grid.Appearance.Options.UseFont = true;
      grid.Size = new Size(436, 174);
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 174);
      pnlDown.Size = new Size(436, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Size = new Size(436, 174);
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
      // ResultDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(436, 214);
      Name = "ResultDlg";
      Text = "ResultDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
  }
}