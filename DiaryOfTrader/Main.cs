using DiaryOfTrader.EditDialogs;

namespace DiaryOfTrader
{
  public partial class Main : BaseForm
  {
    public Main()
    {
      InitializeComponent();
    }

    private void btMain_Click(object sender, EventArgs e)
    {
      new RibbonMain().ShowDialog();
    }

    private void btTool_Click(object sender, EventArgs e)
    {
      new ToolbarForm1().ShowDialog();
    }
  }
}
