// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader
{
  partial class ToolbarForm1
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
      components = new System.ComponentModel.Container();
      barManager1 = new DevExpress.XtraBars.BarManager(components);
      bar1 = new DevExpress.XtraBars.Bar();
      bar2 = new DevExpress.XtraBars.Bar();
      bar3 = new DevExpress.XtraBars.Bar();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
      barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
      barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
      ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
      SuspendLayout();
      // 
      // barManager1
      // 
      barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2, bar3 });
      barManager1.DockControls.Add(barDockControlTop);
      barManager1.DockControls.Add(barDockControlBottom);
      barManager1.DockControls.Add(barDockControlLeft);
      barManager1.DockControls.Add(barDockControlRight);
      barManager1.Form = this;
      barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, barButtonItem3 });
      barManager1.MainMenu = bar2;
      barManager1.MaxItemId = 3;
      barManager1.StatusBar = bar3;
      // 
      // bar1
      // 
      bar1.BarName = "Tools";
      bar1.DockCol = 0;
      bar1.DockRow = 1;
      bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem3) });
      bar1.Text = "Tools";
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
      // 
      // bar3
      // 
      bar3.BarName = "Status bar";
      bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
      bar3.DockCol = 0;
      bar3.DockRow = 0;
      bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
      bar3.OptionsBar.AllowQuickCustomization = false;
      bar3.OptionsBar.DrawDragBorder = false;
      bar3.OptionsBar.UseWholeRow = true;
      bar3.Text = "Status bar";
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = barManager1;
      barDockControlTop.Size = new Size(632, 41);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 258);
      barDockControlBottom.Manager = barManager1;
      barDockControlBottom.Size = new Size(632, 20);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 41);
      barDockControlLeft.Manager = barManager1;
      barDockControlLeft.Size = new Size(0, 217);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(632, 41);
      barDockControlRight.Manager = barManager1;
      barDockControlRight.Size = new Size(0, 217);
      // 
      // barButtonItem1
      // 
      barButtonItem1.Caption = "barButtonItem1";
      barButtonItem1.Id = 0;
      barButtonItem1.Name = "barButtonItem1";
      // 
      // barButtonItem2
      // 
      barButtonItem2.Caption = "barButtonItem2";
      barButtonItem2.Id = 1;
      barButtonItem2.Name = "barButtonItem2";
      // 
      // barButtonItem3
      // 
      barButtonItem3.Caption = "barButtonItem3";
      barButtonItem3.Id = 2;
      barButtonItem3.Name = "barButtonItem3";
      // 
      // ToolbarForm1
      // 
      AutoScaleDimensions = new SizeF(6F, 13F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(632, 278);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      Name = "ToolbarForm1";
      Text = "ToolbarForm1";
      ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.Bar bar1;
    private DevExpress.XtraBars.Bar bar2;
    private DevExpress.XtraBars.Bar bar3;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    private DevExpress.XtraBars.BarButtonItem barButtonItem3;
  }
}