using DiaryOfTrader.Components;

namespace DiaryOfTrader.EditDialogs
{
  public class BaseForm : CoreForm
  {

    public BaseForm()
    {
      //this.Icon = Settings.DefaultFormIcon;
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // BaseForm
      // 
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Name = "BaseForm";
      this.ResumeLayout(false);

    }

  }
}
