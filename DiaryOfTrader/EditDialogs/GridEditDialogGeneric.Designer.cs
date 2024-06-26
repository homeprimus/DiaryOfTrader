﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs
{
  partial class GridEditDialogGeneric<T>
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(GridEditDialogGeneric<T>));
      grid = new EditControls.GridCntrl();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      pnlClient.SuspendLayout();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.Options.UseBackColor = true;
      // 
      // pnlClient
      // 
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Controls.Add(grid);
      // 
      // btOK
      // 
      btOK.Appearance.Options.UseFont = true;
      // 
      // btCancel
      // 
      btCancel.Appearance.Options.UseFont = true;
      // 
      // grid
      // 
      grid.Appearance.Options.UseBackColor = true;
      grid.Appearance.Options.UseFont = true;
      grid.DataSource = null;
      grid.Name = "grid";
      // 
      // GridEditDialogGeneric
      // 
      Appearance.Options.UseFont = true;
      Name = "GridEditDialogGeneric";
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      pnlClient.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    protected EditControls.GridCntrl grid;
  }
}
