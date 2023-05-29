
using System.ComponentModel;

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
  }
}
