// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace DiaryOfTrader.EditDialogs.Calendar
{
  partial class CalendarDlg
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarDlg));
      bmCalendar = new DevExpress.XtraBars.BarManager(components);
      bar2 = new DevExpress.XtraBars.Bar();
      barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      bar1 = new DevExpress.XtraBars.Bar();
      beiEconomicPeriod = new DevExpress.XtraBars.BarEditItem();
      rgEconomicPeriod = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
      beiEconomicImportance = new DevExpress.XtraBars.BarEditItem();
      cbEconomicImportance = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      ((System.ComponentModel.ISupportInitialize)bmCalendar).BeginInit();
      ((System.ComponentModel.ISupportInitialize)rgEconomicPeriod).BeginInit();
      ((System.ComponentModel.ISupportInitialize)cbEconomicImportance).BeginInit();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = Color.Transparent;
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.Location = new Point(0, 365);
      pnlDown.Size = new Size(809, 40);
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = Color.Transparent;
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.Location = new Point(0, 28);
      pnlClient.Size = new Size(809, 337);
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
      // bmCalendar
      // 
      bmCalendar.AllowHtmlText = true;
      bmCalendar.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
      bmCalendar.DockControls.Add(barDockControlTop);
      bmCalendar.DockControls.Add(barDockControlBottom);
      bmCalendar.DockControls.Add(barDockControlLeft);
      bmCalendar.DockControls.Add(barDockControlRight);
      bmCalendar.Form = this;
      bmCalendar.Items.AddRange(new DevExpress.XtraBars.BarItem[] { beiEconomicPeriod, beiEconomicImportance });
      bmCalendar.MainMenu = bar2;
      bmCalendar.MaxItemId = 5;
      bmCalendar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { rgEconomicPeriod, cbEconomicImportance });
      // 
      // bar2
      // 
      bar2.BarName = "Main menu";
      bar2.DockCol = 0;
      bar2.DockRow = 0;
      bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, beiEconomicPeriod, "", false, true, true, 418), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, beiEconomicImportance, "", false, true, true, 213) });
      bar2.OptionsBar.MultiLine = true;
      bar2.OptionsBar.UseWholeRow = true;
      bar2.Text = "Main menu";
      // 
      // barDockControlTop
      // 
      barDockControlTop.CausesValidation = false;
      barDockControlTop.Dock = DockStyle.Top;
      barDockControlTop.Location = new Point(0, 0);
      barDockControlTop.Manager = bmCalendar;
      barDockControlTop.Size = new Size(809, 28);
      // 
      // barDockControlBottom
      // 
      barDockControlBottom.CausesValidation = false;
      barDockControlBottom.Dock = DockStyle.Bottom;
      barDockControlBottom.Location = new Point(0, 405);
      barDockControlBottom.Manager = bmCalendar;
      barDockControlBottom.Size = new Size(809, 0);
      // 
      // barDockControlLeft
      // 
      barDockControlLeft.CausesValidation = false;
      barDockControlLeft.Dock = DockStyle.Left;
      barDockControlLeft.Location = new Point(0, 28);
      barDockControlLeft.Manager = bmCalendar;
      barDockControlLeft.Size = new Size(0, 377);
      // 
      // barDockControlRight
      // 
      barDockControlRight.CausesValidation = false;
      barDockControlRight.Dock = DockStyle.Right;
      barDockControlRight.Location = new Point(809, 28);
      barDockControlRight.Manager = bmCalendar;
      barDockControlRight.Size = new Size(0, 377);
      // 
      // bar1
      // 
      bar1.BarName = "Custom 3";
      bar1.DockCol = 0;
      bar1.DockRow = 1;
      bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      bar1.Text = "Custom 3";
      // 
      // beiEconomicPeriod
      // 
      beiEconomicPeriod.Edit = rgEconomicPeriod;
      beiEconomicPeriod.Id = 3;
      beiEconomicPeriod.Name = "beiEconomicPeriod";
      // 
      // rgEconomicPeriod
      // 
      rgEconomicPeriod.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Вчера"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Сегодня"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Завтра"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "На неделю"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Следующая неделя") });
      rgEconomicPeriod.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
      rgEconomicPeriod.Name = "rgEconomicPeriod";
      // 
      // beiEconomicImportance
      // 
      beiEconomicImportance.Caption = "Волатильность";
      beiEconomicImportance.CaptionToEditorIndent = 3;
      beiEconomicImportance.Description = "Волатильность";
      beiEconomicImportance.Edit = cbEconomicImportance;
      beiEconomicImportance.Id = 4;
      beiEconomicImportance.Name = "beiEconomicImportance";
      beiEconomicImportance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
      // 
      // cbEconomicImportance
      // 
      cbEconomicImportance.AutoHeight = false;
      cbEconomicImportance.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
      cbEconomicImportance.Items.AddRange(new object[] { "Все уровни", "Низкая", "Умеренная", "Высокая" });
      cbEconomicImportance.Name = "cbEconomicImportance";
      // 
      // CalendarDlg
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(809, 405);
      Controls.Add(barDockControlLeft);
      Controls.Add(barDockControlRight);
      Controls.Add(barDockControlBottom);
      Controls.Add(barDockControlTop);
      IconOptions.Icon = (Icon)resources.GetObject("CalendarDlg.IconOptions.Icon");
      Name = "CalendarDlg";
      Text = "CalendarDlg";
      Controls.SetChildIndex(barDockControlTop, 0);
      Controls.SetChildIndex(barDockControlBottom, 0);
      Controls.SetChildIndex(barDockControlRight, 0);
      Controls.SetChildIndex(barDockControlLeft, 0);
      Controls.SetChildIndex(pnlDown, 0);
      Controls.SetChildIndex(pnlClient, 0);
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      ((System.ComponentModel.ISupportInitialize)bmCalendar).EndInit();
      ((System.ComponentModel.ISupportInitialize)rgEconomicPeriod).EndInit();
      ((System.ComponentModel.ISupportInitialize)cbEconomicImportance).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.BarManager bmCalendar;
    private DevExpress.XtraBars.Bar bar2;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarEditItem brEconomicPeriod;
    private DevExpress.XtraBars.Bar bar1;
    private DevExpress.XtraBars.BarEditItem beiEconomicPeriod;
    private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup rgEconomicPeriod;
    private DevExpress.XtraBars.BarEditItem beiEconomicImportance;
    private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbEconomicImportance;
  }
}