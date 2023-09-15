using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using DiaryOfTrader.Core.Interfaces;
using DiaryOfTrader.Core.Utils;

namespace DiaryOfTrader.Core.Core
{
  public interface IPersistent
  {
    bool IsChanged { get; }
    void BeginEdit();
    void EndEdit();
    void CancelEdit();
  }

  [Serializable]
  [NotMapped]
  public abstract class Element :
    Persistent, 
    IEditableUI, 
    IPersistent,
    //IEditableObject, 
    INotifyPropertyChanged, 
    IDataErrorInfo, 
    ICloneable,
    ISupportInitialize//ICustomTypeDescriptor
  {
    #region private field
    private bool isEditing;
    private bool isNew = true;
    private bool isDeleted;
    private bool isChanged;
    private int isInitialize;
    private int updateCount;
    
    [NotPersistent] private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

    [NonSerialized, NotPersistent] private Element parent;
    [NonSerialized, NotPersistent] private PropertyChangedEventHandler? propertyChangedHandler;
    [NotPersistent, NonSerialized] private EventHandler? deleteHandler;

    public event PropertyChangedEventHandler? PropertyChanged
    {
      add
      {
        lock (SyncRoot)
          propertyChangedHandler = (PropertyChangedEventHandler)
                                   Delegate.Combine(propertyChangedHandler, value)!;
      }
      remove
      {
        lock (SyncRoot)
          propertyChangedHandler = (PropertyChangedEventHandler)
                          Delegate.Remove(propertyChangedHandler, value)!;
      }
    }
    public event EventHandler OnDelete
    {
      add
      {
        lock (SyncRoot)
          deleteHandler = (EventHandler)Delegate.Combine(deleteHandler, value);
      }
      remove
      {
        lock (SyncRoot)
          deleteHandler = (EventHandler)Delegate.Remove(deleteHandler, value)!;
      }
    }

    #endregion

    protected Element()
    {
      OnAfterConstruction();
    }

    [JsonIgnore]
    public Element Parent
    {
      get { return parent; }
      set
      {
        if (!ReferenceEquals(parent, value))
        {
          if (!ReferenceEquals(parent, null))
          {
            parent.DeleteChild(this);
          }
          parent = value;
          if (!ReferenceEquals(parent, null))
          {
            parent.AppendChild(this);
            OnChangeParent(parent);
          }
        }
      }
    }
    protected virtual void OnDeleteChild(Element child)
    {
    }
    protected virtual bool OnAppendChild(Element child)
    {
      return true;
    }
    protected virtual void OnFreeChild(Element child)
    {
    }

    protected virtual void OnChildPropertyChanged(object sender, string? propertyName)
    {
      OnEmptyPropertyChanged();
    }
    private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!IsInitialize && !ReferenceEquals(sender, null))
      {
        IsChanged = true;
        OnChildPropertyChanged(sender, e.PropertyName);
      }
    }

    #region IChild Members
    protected virtual void OnChangeParent(Element owner)
    {
    }
    #endregion

    #region IParent Members
    private bool IsValidChild(Element child)
    {
      return !ReferenceEquals(child, null) && !ReferenceEquals(child, this);
    }
    protected void DeleteChild(Element child)
    {
      lock (SyncRoot)
      {
        if (IsValidChild(child))
        {
          child.PropertyChanged -= ChildPropertyChanged;
          OnDeleteChild(child);
          IsChanged = true;
          //OnPropertyChanged(changeChild);
        }
      }
    }
    protected void AppendChild(Element child)
    {
      lock (SyncRoot)
      {
        if (IsValidChild(child) && OnAppendChild(child))
        {
          child.PropertyChanged += ChildPropertyChanged;
          IsChanged = true;
          //OnPropertyChanged(changeChild);
        }
      }
    }
    protected void FreeChild(Element child)
    {
      lock (SyncRoot)
      {
        if (IsValidChild(child))
        {
          child.PropertyChanged -= ChildPropertyChanged;
          OnFreeChild(child);
        }
      }
    }
    #endregion

    protected static void ClearEventHandler(Delegate? eventHandler)
    {
      if (eventHandler != null)
        foreach (var d in eventHandler.GetInvocationList())
          eventHandler = Delegate.RemoveAll(eventHandler, d);
    }

    protected override void Free()
    {
      ClearEventHandler(propertyChangedHandler);
      ClearEventHandler(deleteHandler);
      if (!ReferenceEquals(parent, null))
      {
        parent.FreeChild(this);
      }
      parent = null;
      base.Free();
    }

    [Browsable(false)]
    protected bool IsInitialize
    {
      get { return isInitialize != 0; }
    }

    [JsonIgnore, NotMapped, Browsable(false)]
    public bool IsNew
    {
      get { return isNew; }
      internal set { isNew = value; }
    }

    [JsonIgnore, NotMapped, Browsable(false)]
    public bool IsDeleted
    {
      get { return isDeleted; }
      internal set { isDeleted = value; }
    }

    [JsonIgnore, NotMapped, Browsable(false)]
    public virtual bool IsChanged
    {
      get { return isChanged; }
      internal set
      {
        isChanged = value;
        if (!ReferenceEquals(parent, null) && value)
        {
          parent.IsChanged = true;
        }
      }
    }

    [JsonIgnore, NotMapped, Browsable(false)]
    public bool Validate
    {
      get { return GetValidate(); }
    }

    [JsonIgnore, NotMapped]
    public string ClassDescription => ReflectionUtils.ClassDescription(GetType());

    public virtual void DefaultValues()
    {
    }

    #region IDataErrorInfo Members
    private static string GetColumnName(string columnName)
    {
      return columnName.Trim().ToLower();
    }

    protected void ClearError()
    {
      errors.Clear();
    }

    protected void SetError(string columnName, string errorMessage)
    {
      var column = GetColumnName(columnName);
      if (String.IsNullOrEmpty(errorMessage))
        errors.Remove(column);
      else
        errors[column] = errorMessage;
    }
    protected string GetError(string columnName)
    {
      var column = GetColumnName(columnName);
      return (errors.ContainsKey(column) ? errors[column] : string.Empty);
    }

    protected void PropertyError(string msg)
    {
      var propertyName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
      SetError(propertyName, msg);
    }

    protected void PropertyError()
    {
      var propertyName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
      SetError(propertyName, string.Empty);
    }


    protected virtual string ErrorMessage()
    {
      return String.Empty;
    }
    string IDataErrorInfo.this[string columnName]
    { get { return GetError(columnName); } }

    string IDataErrorInfo.Error
    { get { return ErrorMessage(); } }

    #endregion
    #region INotifyPropertyChanged
    protected void OnEmptyPropertyChanged()
    {
      //OnPropertyChanged(string.Empty);
      OnPropertyChanged("EmptyProperty");
    }
    protected void OnPropertyChanged(string propertyName)
    {
      OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    protected void OnPropertyChanged()
    {
      var methodName = new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod()?.Name;
      if (methodName is { Length: > 3 })
      {
        OnPropertyChanged(new PropertyChangedEventArgs(methodName[4..]));
      }
    }

    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      if (!IsInitialize && updateCount == 0)
      {
        IsChanged = true;

        if (propertyChangedHandler != null)
        {
          if (!SynchronizationElement.IsMainThread && SynchronizationElement.Context != null)
          {
            SynchronizationElement.Context.Post(o => propertyChangedHandler.Invoke(this, e), e);
          }
          else
          {
            propertyChangedHandler.Invoke(this, e);
          }
        }
      }
    }
    #endregion
    #region ICloneable
    object ICloneable.Clone()
    {
      return Clone();
    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal object Clone()
    {
      return ObjectCloner.Clone(this);
    }
    #endregion
    #region IEditableObject
    protected virtual void OnBeginEdit()
    {
      SaveState();
    }
    protected virtual void OnEndEdit()
    {
      AcceptChanges();
    }
    protected virtual void OnCancelEdit()
    {
      UndoChanges();
    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void BeginEdit()
    {
      if (!(isEditing))
      {
        OnBeginEdit();
        isEditing = true;
      }
    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void EndEdit()
    {
      if (isEditing)
      {
        OnEndEdit();
      }
      isEditing = false;
    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void CancelEdit()
    {
      if (isEditing)
      {
        OnCancelEdit();
      }
      isEditing = false;
      //isChanged = false;
    }
    #endregion
    #region ISupportInitialize
    public void BeginInit()
    {
      Interlocked.Increment(ref isInitialize);
    }
    public void EndInit()
    {
      if (Interlocked.CompareExchange(ref isInitialize, isInitialize, 0) > 0)
      {
        Interlocked.Decrement(ref isInitialize);
        if (Interlocked.CompareExchange(ref isInitialize, isInitialize, 0) == 0)
          OnInitializeComplete();
      }
    }
    protected virtual void OnInitializeComplete()
    {
    }
    #endregion

    public void Lock()
    {
      Interlocked.Increment(ref updateCount);
    }
    public void Unlock()
    {
      if (Interlocked.CompareExchange(ref updateCount, updateCount, 0) > 0)
      {
        Interlocked.Decrement(ref updateCount);
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual void Delete()
    {
      if (!isDeleted)
      {
        isDeleted = true;

        deleteHandler?.Invoke(this, EventArgs.Empty);
        parent?.DeleteChild(this);
      }
    }

    protected virtual void OnAfterConstruction() 
    { }

    internal virtual void MarkOld()
    {
      if (!IsDeleted)
      {
        isNew = false;
        isChanged = false;
      }
    }
    internal virtual void MarkNew()
    {
      if (!IsDeleted)
      {
        isNew = true;
        isChanged = false;
      }
    }
    protected virtual bool GetValidate() { return true; }
    public virtual bool CheckValidate(string indent, StringBuilder sb)
    {
      return true;
    }


    public virtual bool ClassAction(object action, params object[] values)
    {
      return true;
    }
    public virtual object GetActionList()
    {
      return null;
    }

    #region Edit GUI

    public virtual bool EditGUI()
    {
      return EditGUI(EditModeUI.AllowEdit);
    }
    public virtual bool EditGUI(EditModeUI editMode)
    {
      var result = false;
      //var editors = ReflectionUtils.UIObject<ClassEditGUIAttribute>(GetType());
      //var editor = editors[0] as IEditUI;
      //if (editor != null)
      //   result = editor.Edit(this, editMode);
      return result;
    }

    #endregion
  }

  [Serializable]
  public class ElementList<T> : List<T>, IEditableUI where T : Element
  {
    private readonly Element parent = null;
    public ElementList(): this(null)
    {
    }
    public ElementList(Element parent)
    {
      this.parent = parent;
    }
    public Element Parent
    {
      get { return parent; }
    }
    public Type ItemType
    {
      get { return typeof (T); }
    }
    public virtual bool EditGUI()
    {
      return EditGUI(EditModeUI.AllowEdit);
    }
    public virtual bool EditGUI(EditModeUI editMode)
    {
      var result = false;
      //var editors = ReflectionUtils.UIObject<ClassEditGUIAttribute>(GetType());
      //var editor = editors[0] as IEditUI;
      //if (editor != null)
      //  result = editor.Edit(this, editMode);
      return result;
    }
  }
}
