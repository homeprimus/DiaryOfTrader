namespace DiaryOfTrader.Core
{
  internal interface IBindingCombo : IBindableComponent
  {
    string DisplayMember { get; set; }
    string ValueMember { get; set; }
    object SelectedValue { get; set; }
    object DataSource { get; set; }
  }
}
