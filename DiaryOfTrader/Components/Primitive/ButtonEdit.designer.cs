using Button = DiaryOfTrader.Components.Button;
using TextBox = DiaryOfTrader.Components.TextBox;

namespace Exchange.Components.Primitive
{
  partial class ButtonEdit
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
      this.txtEdit = new TextBox();
      this.btnEdit = new Button();
      this.SuspendLayout();
      // 
      // txtEdit
      // 
      this.txtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEdit.Location = new System.Drawing.Point(0, 1);
      this.txtEdit.Name = "txtEdit";
      this.txtEdit.Size = new System.Drawing.Size(149, 20);
      this.txtEdit.TabIndex = 0;
      this.txtEdit.TextChanged += new System.EventHandler(this.OnTextChanged);
      // 
      // btnEdit
      // 
      this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEdit.Location = new System.Drawing.Point(155, 0);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(57, 22);
      this.btnEdit.TabIndex = 1;
      this.btnEdit.Text = "...";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.OnButtonClick);
      // 
      // ButtonEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.txtEdit);
      this.MinimumSize = new System.Drawing.Size(0, 22);
      this.Name = "ButtonEdit";
      this.Size = new System.Drawing.Size(212, 22);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected TextBox txtEdit;
    protected Button btnEdit;



  }
}
