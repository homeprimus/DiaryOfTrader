// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using DiaryOfTrader.Core;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Interfaces;
using MessageBox = DiaryOfTrader.Core.MessageBox;

namespace DiaryOfTrader.EditDialogs
{

  public interface ILinkToBinableControl
  {
    event EventHandler OnCloseEdit;
  }

  public partial class BindingEditDialog : OKCancelDialog
  {
    private Element? instance;
    private EditModeUI editMode = EditModeUI.AllowEdit;
    private EventHandler? closeEditHandler;

    public BindingEditDialog()
    {
      InitializeComponent();
    }

    public event EventHandler OnCloseEdit
    {
      add
      {
        closeEditHandler = (EventHandler)Delegate.Combine(closeEditHandler, value);
      }
      remove
      {
        closeEditHandler = (EventHandler)Delegate.Remove(closeEditHandler, value)!;
      }
    }

    [DefaultValue(null)]
    public object? Instance
    {
      get { return instance; }
      protected set { instance = (Element)value!; }
    }

    [DefaultValue(EditModeUI.AllowEdit)]
    public EditModeUI EditMode
    {
      get { return editMode; }
      set
      {
        if (editMode != value)
        {
          OnChangeEditMode(value);
        }
      }
    }
    protected virtual void OnChangeEditMode(EditModeUI mode)
    {
      editMode = mode;
      foreach (Control ctrl in Controls)
      {
        ctrl.Enabled = mode == EditModeUI.AllowEdit;
      }
      if (mode == EditModeUI.ReadOnly)
      {
        btCancel.Enabled = true;
        btOK.Enabled = false;
      }
    }
    protected virtual void OnBeforeInitializeInstance()
    {
    }
    protected virtual void OnInitializeInstance()
    {
      MinimumSize = new Size(Width, Height);
      BindingUtils.Bind(btOK as IBindableComponent, BindingUtils.Enabled, instance, BindingUtils.Validate);
    }
    protected virtual void OnAfterInitializeInstance()
    {
    }
    private void DoPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      BindingUtils.SafeReadValue(btOK as IBindableComponent, BindingUtils.Enabled);
      var propertyName = e.PropertyName ?? string.Empty;
      if (!PreProcessPropertyChanged(propertyName))
        InstancePropertyChanged(propertyName);
    }

    protected virtual bool PreProcessPropertyChanged(string name)
    {
      return false;
    }
    protected virtual void InstancePropertyChanged(string name)
    {
    }

    public bool Edit(EditModeUI mode = EditModeUI.AllowEdit)
    {
      return Edit(instance, mode);
    }
    public virtual bool Edit(object? sender, EditModeUI mode)
    {
      var result = false;
      if (!ReferenceEquals(this.instance, null))
      {
        instance.PropertyChanged -= DoPropertyChanged;
        instance.CancelEdit();
      }
      this.instance = sender as Element;
      if (!ReferenceEquals(instance, null))
      {
        try
        {
          #region initialize

          OnBeforeInitializeInstance();
          instance.Lock();
          try
          {
            OnInitializeInstance();
            OnChangeEditMode(mode);
          }
          finally
          {
            instance.Unlock();
          }
          OnAfterInitializeInstance();

          #endregion

          #region editing

          instance.PropertyChanged += DoPropertyChanged;
          try
          {
            instance.BeginEdit();
            result = ShowDialog() == DialogResult.OK;
            if (result)
            {
              instance.EndEdit();
            }
            else
            {
              instance.CancelEdit();
            }
          }
          catch (Exception)
          {
            instance.CancelEdit();
            throw;
          }
          finally
          {
            instance.PropertyChanged -= DoPropertyChanged;
            closeEditHandler?.Invoke(this.instance, EventArgs.Empty);
          }

          #endregion

        }
        catch (Exception exception)
        {
          MessageBox.ShowError(this, exception.Message);
        }
      }
      return result;
    }

  }
}
