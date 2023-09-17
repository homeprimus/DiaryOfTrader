// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs
{
  partial class PictureEditDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureEditDlg));
      pictureEdit = new Components.PictureEdit();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 461);
      pnlDown.Size = new Size(545, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(pictureEdit);
      pnlClient.Size = new Size(545, 461);
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
      // pictureEdit
      // 
      pictureEdit.Appearance.BackColor = Color.Transparent;
      pictureEdit.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      pictureEdit.Appearance.Options.UseBackColor = true;
      pictureEdit.Appearance.Options.UseFont = true;
      pictureEdit.Dock = DockStyle.Fill;
      pictureEdit.Image = null;
      pictureEdit.Location = new Point(0, 0);
      pictureEdit.Name = "pictureEdit";
      pictureEdit.Size = new Size(545, 461);
      pictureEdit.TabIndex = 0;
      // 
      // PictureEditDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(545, 501);
      IconOptions.Icon = (Icon)resources.GetObject("PictureEditDlg.IconOptions.Icon");
      Name = "PictureEditDlg";
      Text = "PictureEditDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Components.PictureEdit pictureEdit;
  }
}
