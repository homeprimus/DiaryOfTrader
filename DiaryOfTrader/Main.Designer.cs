namespace DiaryOfTrader
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
      btTool = new Components.Button();
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
      // btTool
      // 
      btTool.Appearance.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
      btTool.Appearance.Options.UseFont = true;
      btTool.Location = new Point(45, 58);
      btTool.Name = "btTool";
      btTool.Size = new Size(107, 23);
      btTool.TabIndex = 1;
      btTool.Text = "Tool окно";
      btTool.UseVisualStyleBackColor = false;
      btTool.Click += btTool_Click;
      // 
      // Main
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(507, 292);
      Controls.Add(btTool);
      Controls.Add(btMain);
      IconOptions.Icon = (Icon)resources.GetObject("Main.IconOptions.Icon");
      Name = "Main";
      ResumeLayout(false);
    }

    #endregion

    private Components.Button btMain;
    private Components.Button btTool;
  }
}