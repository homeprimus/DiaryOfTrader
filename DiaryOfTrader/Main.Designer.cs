﻿namespace DiaryOfTrader
{
  partial class Main
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      btMain = new Components.Button();
      button1 = new Components.Button();
      SuspendLayout();
      // 
      // btMain
      // 
      btMain.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      btMain.Appearance.Options.UseFont = true;
      btMain.Location = new Point(36, 12);
      btMain.Name = "btMain";
      btMain.Size = new Size(107, 23);
      btMain.TabIndex = 0;
      btMain.Text = "Основное окно";
      btMain.UseVisualStyleBackColor = false;
      btMain.Click += btMain_Click;
      // 
      // button1
      // 
      button1.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      button1.Appearance.Options.UseFont = true;
      button1.Location = new Point(36, 88);
      button1.Name = "button1";
      button1.Size = new Size(107, 23);
      button1.TabIndex = 1;
      button1.Text = "RabbitMQ";
      button1.UseVisualStyleBackColor = false;
      button1.Click += button1_Click;
      // 
      // Main
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(507, 292);
      Controls.Add(button1);
      Controls.Add(btMain);
      IconOptions.Icon = (Icon)resources.GetObject("Main.IconOptions.Icon");
      Name = "Main";
      ResumeLayout(false);
    }

    #endregion

    private Components.Button btMain;
    private Components.Button button1;
  }
}