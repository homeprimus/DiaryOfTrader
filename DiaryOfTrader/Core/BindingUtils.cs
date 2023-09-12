using System.Collections;
using DevExpress.XtraEditors.Repository;
using Exchange.Core;

namespace DiaryOfTrader.Core
{
  internal static class BindingUtils
  {
    public const string Text = "Text";
    public const string Checked = "Checked";
    public const string Enabled = "Enabled";
    public const string Validate = "Validate";
    public const string Key = "Key";
    public const string Value = "Value";
    public const string Visible = "Visible";
    public const string Name = "Name";
    public const string SelectedValue = "SelectedValue";
    public const string EditValue = "EditValue";
    public const string Maximum = "Maximum";
    public const string SelectedItem = "SelectedItem";
    public const string SelectedTabPageIndex = "SelectedTabPageIndex";
    public const string MaxLength = "MaxLength";
    

    public static void ComboRefresh(IBindingCombo ctrl, IList list)
    {
      ctrl.DataSource = null;
      ctrl.DataSource = list;
      SafeReadValue(ctrl, SelectedValue);
    }
    public static void BindCombo(IBindingCombo ctrl, object? self, string property, IList list)
    {
      ctrl.DisplayMember = Key;
      ctrl.ValueMember = Value;
      Bind(ctrl, SelectedValue, self, property);
      ctrl.DataSource = list;
    }
    public static void BindRepositoryItemLookUp(RepositoryItemLookUpEdit ctrl, object? self, string property, IList list)
    {
      ctrl.DisplayMember = Key;
      ctrl.ValueMember = Value;
      //Bind(ctrl, SelectedValue, self, property);
      ctrl.DataSource = list;
    }
    public static void BindCheckBox(IBindableComponent ctrl, object? self, string bEnabled, string bChecked)
    {
      Bind(ctrl, Enabled, self, bEnabled);
      Bind(ctrl, Checked, self, bChecked);
    }
    public static void BindRadioBox(IBindableComponent ctrl, object? self, string bEnabled, string bChecked)
    {
      Bind(ctrl, Enabled, self, bEnabled);
      Bind(ctrl, Checked, self, bChecked);
    }
    public static void BindTextBox(IBindableComponent ctrl, object? self, string bEnabled, string text)
    {
      Bind(ctrl, Enabled, self, bEnabled);
      Bind(ctrl, Text, self, text);
    }
    public static void BindValue(IBindableComponent ctrl, object? self, string bEnabled, string value)
    {
      Bind(ctrl, Enabled, self, bEnabled);
      Bind(ctrl, Value, self, value);
    }
    public static void BindEditValue(IBindableComponent ctrl, object? self, string bEnabled, string value)
    {
      Bind(ctrl, Enabled, self, bEnabled);
      Bind(ctrl, EditValue, self, value);
    }

    public static void BindEnabled(IBindableComponent ctrl, object? self, string bEnabled)
    {
      Bind(ctrl, Enabled, self, bEnabled);
    }

    public static void BindVisible(IBindableComponent ctrl, object? self, string bVisible)
    {
      Bind(ctrl, Visible, self, bVisible);
    }

    public static void Bind(IBindableComponent[] ctrls, string binding, object? self, string property)
    {
      foreach (var ctrl in ctrls)
        Bind(ctrl, binding, self, property);
    }
   
    public static void Bind(IBindableComponent ctrl, string binding, object? self, string property)
    {
      if (!ReferenceEquals(ctrl, null))
        ctrl.DataBindings.Add(binding, self, property, true, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static void Refresh(IBindableComponent ctrl)
    {
      foreach (Binding b in ctrl.DataBindings)
        b.ReadValue();
    }
    public static void SafeReadValue(IBindableComponent[] ctrls, string binding)
    {
      foreach (var ctrl in ctrls)
        SafeReadValue(ctrl, binding);
    }
    public static void SafeReadValue(IBindableComponent ctrl, string binding)
    {
      if (!ReferenceEquals(ctrl, null))
      {
        var b = ctrl.DataBindings[binding];
        if (!ReferenceEquals(b, null))
          b.ReadValue();
      }
    }
    public static void SafeWriteValue(IBindableComponent ctrl, string binding)
    {
      if (!ReferenceEquals(ctrl, null))
      {
        var b = ctrl.DataBindings[binding];
        if (!ReferenceEquals(b, null))
          b.WriteValue();
      }
    }
    public static void SafeWriteValueOnPropertyChanged(IBindableComponent ctrl, string binding)
    {
      var b = ctrl.DataBindings[binding];
      if ((b != null) && (b.DataSourceUpdateMode == DataSourceUpdateMode.OnPropertyChanged))
        b.WriteValue();
    }
    public static void ClearBinding(Control sender)
    {
      foreach (Control ctrl in sender.Controls)
      {
        ctrl.DataBindings.Clear();
        ClearBinding(ctrl);
      }
    }
  }
}
