
namespace DiaryOfTrader.Core.Interfaces
{
  public enum EditModeUI
  {
    ReadOnly,
    AllowEdit
  }

  public interface IEditUI
  {
    object? Instance { get; }
    EditModeUI EditMode { get; set; }
    bool Edit(object instance, EditModeUI mode);
  }

  public interface IEditableUI
  {
    bool EditGUI(EditModeUI editMode);
  }

  public interface ICoreBinableControl
  {
    object Self { get; set; }
    string Caption { get; }
  }
  public interface ICoreBinableControl<T> : ICoreBinableControl
  {
    T Element { get; set; }
  }

}