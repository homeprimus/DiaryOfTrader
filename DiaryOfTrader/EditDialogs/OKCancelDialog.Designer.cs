using DiaryOfTrader.Components.Primitive;
using Button = DiaryOfTrader.Components.Button;

namespace DiaryOfTrader.EditDialogs
{
  partial class OKCancelDialog
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(OKCancelDialog));
      pnlDown = new Components.Panel();
      pnlOK = new Components.Panel();
      btOK = new Button();
      pnlCancel = new Components.Panel();
      btCancel = new Button();
      lblDown = new LabeledLine();
      pnlClient = new Components.Panel();
      ((System.ComponentModel.ISupportInitialize)pnlDown).BeginInit();
      pnlDown.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pnlOK).BeginInit();
      pnlOK.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pnlCancel).BeginInit();
      pnlCancel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pnlClient).BeginInit();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.Appearance.BackColor = (Color)resources.GetObject("pnlDown.Appearance.BackColor");
      pnlDown.Appearance.Options.UseBackColor = true;
      pnlDown.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlDown.Controls.Add(pnlOK);
      pnlDown.Controls.Add(pnlCancel);
      pnlDown.Controls.Add(lblDown);
      resources.ApplyResources(pnlDown, "pnlDown");
      pnlDown.Name = "pnlDown";
      // 
      // pnlOK
      // 
      pnlOK.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlOK.Controls.Add(btOK);
      resources.ApplyResources(pnlOK, "pnlOK");
      pnlOK.Name = "pnlOK";
      // 
      // btOK
      // 
      btOK.Appearance.Font = (Font)resources.GetObject("btOK.Appearance.Font");
      btOK.Appearance.Options.UseFont = true;
      resources.ApplyResources(btOK, "btOK");
      btOK.Name = "btOK";
      btOK.UseVisualStyleBackColor = true;
      btOK.Click += DoOkClick;
      // 
      // pnlCancel
      // 
      pnlCancel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      pnlCancel.Controls.Add(btCancel);
      resources.ApplyResources(pnlCancel, "pnlCancel");
      pnlCancel.Name = "pnlCancel";
      // 
      // btCancel
      // 
      btCancel.Appearance.Font = (Font)resources.GetObject("btCancel.Appearance.Font");
      btCancel.Appearance.Options.UseFont = true;
      btCancel.DialogResult = DialogResult.Cancel;
      resources.ApplyResources(btCancel, "btCancel");
      btCancel.Name = "btCancel";
      btCancel.UseVisualStyleBackColor = true;
      // 
      // lblDown
      // 
      resources.ApplyResources(lblDown, "lblDown");
      lblDown.Name = "lblDown";
      // 
      // pnlClient
      // 
      pnlClient.Appearance.BackColor = (Color)resources.GetObject("pnlClient.Appearance.BackColor");
      pnlClient.Appearance.Options.UseBackColor = true;
      pnlClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      resources.ApplyResources(pnlClient, "pnlClient");
      pnlClient.Name = "pnlClient";
      // 
      // OKCancelDialog
      // 
      Appearance.Options.UseFont = true;
      resources.ApplyResources(this, "$this");
      Controls.Add(pnlClient);
      Controls.Add(pnlDown);
      IconOptions.Icon = (Icon)resources.GetObject("OKCancelDialog.IconOptions.Icon");
      Name = "OKCancelDialog";
      HelpRequested += DoHelpRequested;
      ((System.ComponentModel.ISupportInitialize)pnlDown).EndInit();
      pnlDown.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pnlOK).EndInit();
      pnlOK.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pnlCancel).EndInit();
      pnlCancel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pnlClient).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private LabeledLine lblDown;
    protected DiaryOfTrader.Components.Panel pnlDown;
    protected DiaryOfTrader.Components.Panel pnlClient;
    private DiaryOfTrader.Components.Panel pnlOK;
    protected DiaryOfTrader.Components.Button btOK;
    private DiaryOfTrader.Components.Panel pnlCancel;
    protected DiaryOfTrader.Components.Button btCancel;
  }
}
