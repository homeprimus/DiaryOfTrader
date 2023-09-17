using DiaryOfTrader.Core.Core;
using DiaryOfTrader.EditDialogs;

namespace DiaryOfTrader.Abstracts
{
  public partial class BinableElementDlg<T> : BindingEditDialog where T: Element
  {
    public BinableElementDlg()
    {
      InitializeComponent();
    }

    public T Element
    {
      get { return (T)Instance; }
      set { Instance = value; }
    }

  }
}
