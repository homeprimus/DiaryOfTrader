
using System.ComponentModel;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.EditDialogs;

namespace DiaryOfTrader.Abstracts
{
  public partial class BinableGridEditDlg<T> : GridEditDialog where T : Element
  {
    public BinableGridEditDlg()
    {
      InitializeComponent();
    }

  }
}
