using Exchange.Core;

namespace DiaryOfTrader.EditDialogs
{
  public partial class OKCancelDialog : BaseForm
  {
    public OKCancelDialog()
    {
      InitializeComponent();
    }

    //[Browsable(true)]
    //public event CancelEventHandler ButtonOkClicked;

    //protected virtual void OnButtonOKClicked(CancelEventArgs args)
    //{
    //  if (ButtonOkClicked != null)
    //  {
    //    ButtonOkClicked(this, args);
    //  }
    //}

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //var icon = Settings.ApplicationIcon;
      //if (icon != null)
      //  Icon = icon;
    }

    private void OKCancelDialogHelpRequested(object sender, HelpEventArgs hlpevent)
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

    private void btOKClick(object sender, EventArgs e)
    {
      //var args = new CancelEventArgs(false);
      //OnButtonOKClicked(args);
      DialogResult = !OnCloseQuery()
        ? System.Windows.Forms.DialogResult.None
        : System.Windows.Forms.DialogResult.OK;
    }
  }
}
