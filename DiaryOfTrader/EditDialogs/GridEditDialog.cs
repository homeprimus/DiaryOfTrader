
using System.ComponentModel;
using System.IO;

namespace DiaryOfTrader.EditDialogs
{
  public partial class GridEditDialog : OKCancelDialog
  {
    public GridEditDialog()
    {
      InitializeComponent();
    }

    [DefaultValue(null)]
    public object DataSource
    {
      get { return grid.DataSource; }
      set
      {
        grid.DataSource = value;
      }
    }

    protected string GridLayoutStore
    {
      get { return Path.Combine(SettingFolder, GetType().Name + ".GridLayout.xml"); }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      if (File.Exists(GridLayoutStore))
      {
        grid.gridView.RestoreLayoutFromXml(GridLayoutStore);
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      grid.gridView.SaveLayoutToXml(GridLayoutStore);
    }
  }
}
