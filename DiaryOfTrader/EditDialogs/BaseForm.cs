using System.IO;
using DiaryOfTrader.Components;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Properties;

namespace DiaryOfTrader.EditDialogs
{
  public class BaseForm : CoreForm
  {

    public BaseForm()
    {
      //this.Icon = Settings.DefaultFormIcon;
    }

    public string SettingFolder
    {
      get
      {
        var folder = Path.Combine(DiaryOfTraderCtx.RootFolder, "Setting");
        if (!Directory.Exists(folder))
        {
          Directory.CreateDirectory(folder);
        }
        return folder;
      }
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

      MinimumSize = new Size(Width, Height);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Icon = Resources.Main;
    }

  }
}
