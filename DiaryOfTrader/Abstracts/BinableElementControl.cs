using System.ComponentModel;
using DiaryOfTrader.Components;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Interfaces;
using DiaryOfTrader.EditDialogs;
using Exchange.Components;

namespace DiaryOfTrader.Abstracts
{
  public partial class BinableElementControl<T> : CoreControl, ICoreBinableControl<T> where T : Element
  {
    private T element;

    public BinableElementControl()
    {
      InitializeComponent();
      AutoScroll = true;
    }

    #region virtual
    protected virtual void OnInitializeInstance()
    {
    }
    protected virtual void OnPropertyChanged(string property)
    {
    }
    #endregion

    private void DoPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(e.PropertyName ?? string.Empty);
    }

    protected virtual void DoRemovePropertyChanged(object sender, EventArgs e)
    {
      if (!ReferenceEquals(element, null))
      {
        element.PropertyChanged -= DoPropertyChanged;
      }
    }

    [Browsable(false)]
    [DefaultValue(null)]
    public object Self
    {
      get { return Element; }
      set { Element = (T)value; }
    }

    [DefaultValue("")]
    public virtual string Caption
    {
      get { return string.Empty; }
      set {  }
    }

    private delegate void SetInvokeInstance(T value);

    private void SetInstance(T value)
    {
      if (!ReferenceEquals(element, value))
      {
        if (!ReferenceEquals(element, null))
        {
          element.PropertyChanged -= DoPropertyChanged;
        }
        element = value;
        if (!ReferenceEquals(element, null))
        {
          element.PropertyChanged -= DoPropertyChanged;
          element.Lock();
          try
          {
            OnInitializeInstance();
          }
          finally
          {
            element.Unlock();
          }
          element.PropertyChanged += DoPropertyChanged;

          #region link to ILinkToBinableControl

          var form = FindForm() as ILinkToBinableControl;
          if (form != null)
          {
            form.OnCloseEdit += DoRemovePropertyChanged;
          }
          #endregion

        }
      }
    }
    [Browsable(false)]
    [DefaultValue(null)]
    public T Element
    {
      get { return element; }
      set
      {
        if (InvokeRequired)
        {
          var invokeSet = new SetInvokeInstance(SetInstance);
          Invoke(invokeSet, new object[] { value });
        }
        else
        {
          SetInstance(value);
        }
      }
    }

  }
}
