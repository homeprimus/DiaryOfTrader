﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.Components
{
  partial class TragingView
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
      WebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
      SuspendLayout();
      // 
      // WebBrowser
      // 
      WebBrowser.ActivateBrowserOnCreation = false;
      WebBrowser.Dock = DockStyle.Fill;
      WebBrowser.Location = new Point(0, 0);
      WebBrowser.Name = "WebBrowser";
      WebBrowser.Size = new Size(444, 392);
      WebBrowser.TabIndex = 2;
      // 
      // TragingView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(WebBrowser);
      Name = "TragingView";
      Size = new Size(444, 392);
      ResumeLayout(false);
    }

    #endregion

    private CefSharp.WinForms.ChromiumWebBrowser WebBrowser;
  }
}