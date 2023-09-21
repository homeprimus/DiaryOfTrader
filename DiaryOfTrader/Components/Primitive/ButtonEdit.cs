using System.ComponentModel;
using DiaryOfTrader.Components;
using DiaryOfTrader.Core;

namespace Exchange.Components.Primitive
{
  public partial class ButtonEdit : CoreControl
  {
    #region Events

    public new event EventHandler TextChanged;
    public event EventHandler ButtonClick;

    #endregion

    public ButtonEdit()
    {
      InitializeComponent();
    }

    #region Public Properties

    [Browsable(true)]
    [DefaultValue("")]
    [Bindable(true)]
    public new string Text
    {
      get { return txtEdit.Text; }
      set
      {
        value = value ?? string.Empty;
        var s = txtEdit.Text;
        if (string.Compare(value, s, StringComparison.CurrentCulture) != 0)
        {
          txtEdit.Text = value;
          BindingUtils.SafeWriteValueOnPropertyChanged(txtEdit, BindingUtils.Text);
          OnTextChanged(this, EventArgs.Empty);
        }
      }
    }

    [Browsable(true)]
    [DefaultValue(false)]
    [Bindable(true)]
    public bool TextReadOnly
    {
      get { return txtEdit.ReadOnly; }
      set { txtEdit.ReadOnly = value; }
    }

    [Browsable(true)]
    [DefaultValue(true)]
    [Bindable(true)]
    public bool TextEnabled
    {
      get { return txtEdit.Enabled; }
      set { txtEdit.Enabled = value; }
    }

    [DefaultValue(true)]
    [Browsable(true)]
    public bool ButtonEnabled
    {
      get { return btnEdit.Enabled; }
      set { btnEdit.Enabled = value; }
    }

    #endregion

    #region Event Handlers

    protected virtual void OnTextChanged(object sender, EventArgs e)
    {
      if (TextChanged != null)
        TextChanged(this, EventArgs.Empty);
    }

    protected virtual void OnButtonClick(object sender, EventArgs e)
    {
      if (ButtonClick != null)
        ButtonClick(this, EventArgs.Empty);
    }

    #endregion
  }
}
