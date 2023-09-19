using Exchange.Core;

namespace DiaryOfTrader.EditDialogs
{
  public partial class OKCancelDialog : BaseForm
  {
    public OKCancelDialog()
    {
      InitializeComponent();
    }

    private void DoHelpRequested(object sender, HelpEventArgs hlpevent)
    {
      hlpevent.Handled = HelpFileHelper.ShowHelp(GetHelpTopic());
    }

    protected virtual string GetHelpTopic()
    {
      return string.Empty;
    }

    protected virtual bool OnCloseQuery()
    {
      return true;
    }

    protected virtual void OnOkClick()
    {
    }

    private void DoOkClick(object sender, EventArgs e)
    {
      if (OnCloseQuery())
      {
        OnOkClick();
        DialogResult = DialogResult.OK;
      }
      else
      {
        DialogResult = DialogResult.None; 
      }
    }
  }
}
