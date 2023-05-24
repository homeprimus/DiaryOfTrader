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
      SuspendLayout();
      // 
      // Main
      // 
      Appearance.Options.UseFont = true;
      AutoScaleDimensions = new SizeF(6F, 13F);
      ClientSize = new Size(507, 292);
      IconOptions.Icon = (Icon)resources.GetObject("Main.IconOptions.Icon");
      Name = "Main";
      ResumeLayout(false);
    }

    #endregion
  }
}