using DiaryOfTrader.Components;

namespace DiaryOfTrader.EditControls
{
  public partial class GridCntrl : CoreControl
  {
    public GridCntrl()
    {
      InitializeComponent();
      gridNavigator.View = gridView;
    }

    public object DataSource
    {
      get { return grid.DataSource; }
      set { grid.DataSource= value; }
    }
  }
}
