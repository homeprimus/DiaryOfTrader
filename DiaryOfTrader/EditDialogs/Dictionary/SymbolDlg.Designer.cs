// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs.Dictionary
{
  partial class SymbolDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolDlg));
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // grid
      // 
      grid.Appearance.BackColor = (Color)resources.GetObject("grid.Appearance.BackColor");
      grid.Appearance.Font = (Font)resources.GetObject("grid.Appearance.Font");
      grid.Appearance.Options.UseBackColor = true;
      grid.Appearance.Options.UseFont = true;
      resources.ApplyResources(grid, "grid");
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = (Color)resources.GetObject("pnlDown.Appearance.BackColor");
      pnlDown.Appearance.Options.UseBackColor = true;
      resources.ApplyResources(pnlDown, "pnlDown");
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = (Color)resources.GetObject("pnlClient.Appearance.BackColor");
      pnlClient.Appearance.Options.UseBackColor = true;
      resources.ApplyResources(pnlClient, "pnlClient");
      // 
      // btOK
      // 
      btOK.Appearance.Font = (Font)resources.GetObject("btOK.Appearance.Font");
      btOK.Appearance.Options.UseFont = true;
      // 
      // btCancel
      // 
      btCancel.Appearance.Font = (Font)resources.GetObject("btCancel.Appearance.Font");
      btCancel.Appearance.Options.UseFont = true;
      // 
      // SymbolDlg
      // 
      Appearance.Options.UseFont = true;
      resources.ApplyResources(this, "$this");
      IconOptions.Icon = (Icon)resources.GetObject("SymbolDlg.IconOptions.Icon");
      Name = "SymbolDlg";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
  }
}