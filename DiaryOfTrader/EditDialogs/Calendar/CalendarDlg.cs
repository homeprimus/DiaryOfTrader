
using System.ComponentModel;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.EditDialogs.Calendar
{
  public partial class CalendarDlg : OKCancelDialog
  {

    public CalendarDlg()
    {
      InitializeComponent();
    }

    [DefaultValue(null)]
    public DiaryOfTraderCtx? Contex { get; set; }

  }
}
