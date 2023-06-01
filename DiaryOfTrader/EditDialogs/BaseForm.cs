using DiaryOfTrader.Components;
using DiaryOfTrader.Properties;

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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
      SuspendLayout();
      // 
      // BaseForm
      // 
      Appearance.Options.UseFont = true;
      resources.ApplyResources(this, "$this");
      Name = "BaseForm";
      ResumeLayout(false);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Icon = Resources.Main;
    }

  }
}
