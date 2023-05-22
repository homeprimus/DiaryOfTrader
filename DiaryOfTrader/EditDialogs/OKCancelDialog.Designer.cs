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
      pnlDown = new DiaryOfTrader.Components.Panel();
      pnlOK = new DiaryOfTrader.Components.Panel();
      btOK = new DiaryOfTrader.Components.Button();
      pnlCancel = new DiaryOfTrader.Components.Panel();
      lblDown = new LabeledLine();
      pnlClient = new DiaryOfTrader.Components.Panel();
      btCancel = new Button();
      pnlDown.SuspendLayout();
      pnlOK.SuspendLayout();
      pnlCancel.SuspendLayout();
      SuspendLayout();
      // 
      // pnlDown
      // 
      pnlDown.BackColor = Color.Transparent;
      pnlDown.Controls.Add(pnlOK);
      pnlDown.Controls.Add(pnlCancel);
      pnlDown.Controls.Add(lblDown);
      resources.ApplyResources(pnlDown, "pnlDown");
      pnlDown.Name = "pnlDown";
      // 
      // pnlOK
      // 
      pnlOK.Controls.Add(btOK);
      resources.ApplyResources(pnlOK, "pnlOK");
      pnlOK.Name = "pnlOK";
      // 
      // btOK
      // 
      btOK.BackColor = Color.Transparent;
      resources.ApplyResources(btOK, "btOK");
      btOK.Name = "btOK";
      btOK.UseVisualStyleBackColor = true;
      btOK.Click += btOKClick;
      // 
      // pnlCancel
      // 
      pnlCancel.Controls.Add(btCancel);
      resources.ApplyResources(pnlCancel, "pnlCancel");
      pnlCancel.Name = "pnlCancel";
      // 
      // lblDown
      // 
      resources.ApplyResources(lblDown, "lblDown");
      lblDown.Name = "lblDown";
      // 
      // pnlClient
      // 
      pnlClient.BackColor = Color.Transparent;
      resources.ApplyResources(pnlClient, "pnlClient");
      pnlClient.Name = "pnlClient";
      // 
      // btCancel
      // 
      btCancel.BackColor = Color.Transparent;
      btCancel.DialogResult = DialogResult.Cancel;
      resources.ApplyResources(btCancel, "btCancel");
      btCancel.Name = "btCancel";
      btCancel.UseVisualStyleBackColor = true;
      // 
      // OKCancelDialog
      // 
      resources.ApplyResources(this, "$this");
      Controls.Add(pnlClient);
      Controls.Add(pnlDown);
      Name = "OKCancelDialog";
      pnlDown.ResumeLayout(false);
      pnlOK.ResumeLayout(false);
      pnlCancel.ResumeLayout(false);
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
