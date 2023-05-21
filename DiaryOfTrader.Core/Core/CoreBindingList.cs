using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace DiaryOfTrader.Core.Core
{
  public class CoreBindingListException : Exception
  {
    public CoreBindingListException(string message) : base(message) { }
  }

  public delegate bool FilterProvider(object item, object filter);

  internal static class DefaultFilter
  {
    public static bool Filter(object item, object filter)
    {
      bool result = false;
      if (item != null && filter != null)
        result = item.ToString().Contains(filter.ToString());
      return result;
    }
  }

  public class CoreBindingList<T> :
    IList<T>,
    IBindingListView,
    IBindingList,
    ICancelAddNew,
    IRaiseItemChangedEvents,
    ITypedList,
    ISupportInitializeNotification,
    IListSource,
    ISupportInitialize,
    IDisposable
  {

    protected class BindingListItem : IComparable<BindingListItem>
    {
      #region private fields
      private readonly object key;
      private int index;
      private readonly int raw;
      private readonly ListSortDescriptionCollection refSort;
      
      #endregion

      public BindingListItem(object key, ListSortDescriptionCollection refSort, int index, int raw)
      {
        this.key = key;
        this.refSort = refSort;
        this.index = index;
        this.raw = raw;
      }

      public object Key
      {
        get { return key; }
      }
      public int Index
      {
        get { return index; }
        set { index = value; }
      }
      public int Filter
      {
        get { return raw; }
      }

      #region override

      public override string ToString()
      {
        return Key.ToString();
      }

      #endregion

      #region IComparable<CoreBindingList<T>.BindingListItem> Members

      public int CompareTo(BindingListItem other)
      {
        int result = 0;
        object target = other.Key;
        foreach (ListSortDescription sort in refSort)
        {
          PropertyDescriptor pd = sort.PropertyDescriptor;
          object x = pd.GetValue(key);
          object y = pd.GetValue(target);
          if (x == null)
          {
            result = y == null ? 0 : -1;
          }
          else if (y == null)
          {
            result = 1;
          }
          else if (x is IComparable)
          {
            result = (x as IComparable).CompareTo(y);
          }
          else
          {
            result = x.ToString().CompareTo(y.ToString());
          }
          if (result != 0)
          {
            result = sort.SortDirection == ListSortDirection.Ascending ? result : -result;
            break;
          }
        }
        return result;
      }

      #endregion
    }

    protected class BindingListEnumerator: IEnumerator<T>
    {
      private readonly IList<T> refList;
      private readonly IList<BindingListItem> refItems;
      private int index = -1;

      public BindingListEnumerator(IList<T> refList, IList<BindingListItem> refItems)
      {
        this.refList = refList;
        this.refItems = refItems;
      }

      #region IEnumerator<T> Members

      T IEnumerator<T>.Current
      {
        get { return refItems != null ? refList[refItems[index].Index] : refList[index]; }
      }
      #endregion

      #region IDisposable Members

      public void Dispose()
      {
      }

      #endregion

      #region IEnumerator Members

      public bool MoveNext()
      {
        bool result = index < refItems.Count - 1;
        if (result) index++;
        return result;
      }

      public void Reset()
      {
        index = -1;
      }

      public object Current
      {
        get { return ((IEnumerator<T>)this).Current; }
      }

      #endregion
    }

    #region private fields
    private const string csReadOnlyCollection = "ReadOnlyCollection";
    private const string csWrongValueTypeArgument = "csWrongValueTypeArgument";
    private const string csFixedSizeCollection = "csFixedSizeCollection";

    private bool isReadOnly = false;
    private bool isFixedSize = false;
    private bool disposed = false;
    private readonly List<T> list = new List<T>();
    private int isInitialized = 0;
    private bool raisesItemChangedEvents = true;
    //private PropertyDescriptor sortProperty;
    //private bool isSorted = false;
    //private ListSortDirection sortDirection = ListSortDirection.Ascending;
    private readonly object syncRoot = new object();

    private string filterExpression = string.Empty;
    private FilterProvider filterProvider;
    private PropertyDescriptor filterProperty;

    private bool isFiltered;
    private List<BindingListItem> items;
    private object filter;

    private ListSortDescriptionCollection sortDescriptions;

    #endregion

    private void DoSort()
    {
      
      if (!IsFiltered)
      {
        int i = 0;
        items = new List<BindingListItem>();
        foreach (T item in InnerList)
        {
          items.Add(new BindingListItem(item, sortDescriptions, i, i));
          i++;
        }
      }
      items.Sort();
      OnListChanged(ListChangedType.Reset, 0);
    }

    private void UndoSort()
    {
      sortDescriptions = null;
      if (IsFiltered)
      {
        List<BindingListItem> tmp = new List<BindingListItem>(items);
        foreach (BindingListItem item in tmp)
        {
          items[item.Filter] = item;
        }
      }
      else
      {
        items = null;
        OnListChanged(ListChangedType.Reset, 0);
      }
    }

    private void DoFilter()
    {
      int index = 0;
      int raw = 0;
      items = new List<BindingListItem>();

      if (filterProvider == null)
        filterProvider = DefaultFilter.Filter;

      if (filterProperty == null)
      {
        foreach (T obj in InnerList)
        {
          if (filterProvider.Invoke(obj, filter))
          {
            items.Add(new BindingListItem(obj, sortDescriptions, index, raw));
            raw++;
          }
          index++;
        }
      }
      else
      {
        foreach (T obj in InnerList)
        {
          if (filterProvider.Invoke(filterProperty.GetValue(obj), filter))
          {
            items.Add(new BindingListItem(obj, sortDescriptions, index, raw));
            raw++;
          }
          index++;
        }
      }
      if (IsSorted)
        DoSort();
      else
        OnListChanged(ListChangedType.Reset, 0);
    }
    private void UnDoFilter()
    {
      filterProperty = null;
      filter = null;
      isFiltered = false;
      if (IsSorted)
      {
        DoSort();
      }
      else
      {
        items = null;
        OnListChanged(ListChangedType.Reset, 0);
      }
    }

    private void HookPropertyChanged(T item)
    {
      INotifyPropertyChanged changed = item as INotifyPropertyChanged;
      if (changed != null)
      {
        changed.PropertyChanged += DoPropertyChanged;
      }
    }
    private void UnhookPropertyChanged(T item)
    {
      INotifyPropertyChanged changed = item as INotifyPropertyChanged;
      if (changed != null)
      {
        changed.PropertyChanged -= DoPropertyChanged;
      }
    }
    private void DoPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      OnListChanged(ListChangedType.ItemChanged, IndexOf(sender));
    }

    private static void VerifyValueType(object value)
    {
      if (!(value is T) && ((value != null) || typeof(T).IsValueType))
        throw new CoreBindingListException(csWrongValueTypeArgument);
    }

    protected void CheckReadOnly()
    {
      if (IsReadOnly)
        throw new CoreBindingListException(csReadOnlyCollection);
    }
    protected void CheckFixedSize()
    {
      if (IsFixedSize)
        throw new CoreBindingListException(csFixedSizeCollection);
    }
    protected void CheckIndexOfBound(int index)
    {
      if (index < 0 || index >= InnerList.Count)
        throw new ArgumentOutOfRangeException();
    }

    protected int RealIndex(int index)
    {
      if (items != null)
        return items[index].Index;
      return index;
    }

    protected virtual void SetItem(int index, T item)
    {
      CheckReadOnly();
      CheckIndexOfBound(index);
      lock (syncRoot)
      {
        int realIndex = RealIndex(index);
        if (RaisesItemChangedEvents)
        {
          UnhookPropertyChanged(InnerList[realIndex]);
        }
        InnerList[realIndex] = item;
        if (RaisesItemChangedEvents)
        {
          HookPropertyChanged(item);
        }
      }
      OnListChanged(ListChangedType.ItemChanged, index);
    }
    protected virtual T GetItem(int index)
    {
      CheckIndexOfBound(index);
      lock (syncRoot)
      {
        return InnerList[RealIndex(index)];
      }
    }
    protected virtual void InsertItem(int index, T item)
    {
      if (index == Count)
       CheckFixedSize();
      else
        CheckReadOnly();
      lock (syncRoot)
      {
        //EndNew(addNewPos);
        InnerList.Insert(RealIndex(index), item);
        if (RaisesItemChangedEvents)
        {
          HookPropertyChanged(item);
        }
      }
      OnListChanged(ListChangedType.ItemAdded, index);
    }
    protected virtual void RemoveItem(int index)
    {
      CheckFixedSize();
      CheckIndexOfBound(index);
      lock (syncRoot)
      {
        //if ((addNewPos < 0) || (addNewPos != index))
        //{
        //  throw new NotSupportedException();
        //}
        //EndNew(this.addNewPos);
        int realIndex = RealIndex(index);
        if (RaisesItemChangedEvents)
        {
          UnhookPropertyChanged(InnerList[realIndex]);
        }
        InnerList.RemoveAt(realIndex);
      }
      OnListChanged(ListChangedType.ItemDeleted, index);
    }

    #region filter
    public FilterProvider FilterProvider
    {
      get { return filterProvider; }
      set { filterProvider = value; }
    }
    public PropertyDescriptor FilterProperty
    {
      get { return filterProperty; }
    }
    public bool IsFiltered
    {
      get { return isFiltered; }
    }
    #endregion


    public IList<T> InnerList
    {
      get { return list; }
    }
    protected static Type ElementType
    {
      get { return typeof(T); }
    }
    protected virtual T CreateInstance()
    {
      CheckFixedSize();
      return (T)Activator.CreateInstance(ElementType);
    }

    #region IList<T> Members

    public int IndexOf(T item)
    {
      return RealIndex(InnerList.IndexOf(item));
    }

    public void Insert(int index, T item)
    {
      InsertItem(index, item);
    }

    #region ICollection<T> Members

    public void Add(T item)
    {
      InsertItem(Count, item);
    }

    #region IEnumerable<T> Members

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    #endregion

    #region IBindingListView Members

    public void ApplyFilter()
    {
      if (filterProperty == null || filter == null)
        throw new ArgumentNullException("");
      DoFilter();
    }

    public void ApplyFilter(string propertyName, object filter)
    {
      this.filterProperty = null;
      this.filter = filter;

      if (!String.IsNullOrEmpty(propertyName))
      {
        Type itemType = typeof(T);
        foreach (PropertyDescriptor prop in
          TypeDescriptor.GetProperties(itemType))
        {
          if (prop.Name == propertyName)
          {
            filterProperty = prop;
            break;
          }
        }
      }

      ApplyFilter(filterProperty, filter);

    }

    public void ApplyFilter(PropertyDescriptor property, object filter)
    {
      this.filterProperty = property;
      this.filter = filter;
      DoFilter();
    }

    public void RemoveFilter()
    {
      UnDoFilter();
      Filter = string.Empty;
    }

    public string Filter
    {
      get { return filterExpression; }
      set
      {
        if (string.Compare(filterExpression, value) != 0)
        {
          filterExpression = value;
        }
      }
    }

    public void ApplySort(ListSortDescriptionCollection sorts)
    {
      if (sorts != null)
      {
        List<ListSortDescription> listSortDescriptions = new List<ListSortDescription>(sorts.Count);
        foreach (ListSortDescription sort in sorts)
        {
          listSortDescriptions.Add(new ListSortDescription(sort.PropertyDescriptor, sort.SortDirection));
        }
        sortDescriptions = new ListSortDescriptionCollection(listSortDescriptions.ToArray());
        DoSort();
      }
      else
      {
        UndoSort();
      }
    }

    public ListSortDescriptionCollection SortDescriptions
    {
      get { return sortDescriptions; }
    }

    public bool SupportsAdvancedSorting
    {
      get { return true; }
    }

    public bool SupportsFiltering
    {
      get { return false; }
    }

    #endregion

    #region IBindingList Members

    public event ListChangedEventHandler ListChanged;
    protected void OnListChanged(ListChangedType listChangedType, int newIndex)
    {
      if (ListChanged != null)
        ListChanged(this, new ListChangedEventArgs(listChangedType, newIndex));
    }

    public object AddNew()
    {
      T result = CreateInstance();
      Add(result);
      return result;
    }

    public void AddIndex(PropertyDescriptor property)
    {
    }

    public void ApplySort(string propertyName, ListSortDirection direction)
    {
      PropertyDescriptor sortProperty = null;

      if (!String.IsNullOrEmpty(propertyName))
      {
        Type itemType = typeof(T);
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(itemType))
        {
          if (prop.Name == propertyName)
          {
            sortProperty = prop;
            break;
          }
        }
      }
      ApplySort(sortProperty, direction);
    }

    public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
    {
      if (property != null)
      {
        sortDescriptions =
          new ListSortDescriptionCollection(new ListSortDescription[] {new ListSortDescription(property, direction)});

        DoSort();
      }
      else
      {
        UndoSort();
      }
    }

    public int Find(string propertyName, object key)
    {
      PropertyDescriptor findProperty = null;

      if (!String.IsNullOrEmpty(propertyName))
      {
        Type itemType = typeof(T);
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(itemType))
        {
          if (prop.Name == propertyName)
          {
            findProperty = prop;
            break;
          }
        }
      }

      return Find(findProperty, key);
    }

    public int Find(PropertyDescriptor property, object key)
    {
      return -1;
    }

    public void RemoveIndex(PropertyDescriptor property)
    {
    }

    public void RemoveSort()
    {
      UndoSort();
      sortDescriptions = null;
    }

    public bool AllowNew
    {
      get { return !IsFixedSize; }
    }

    public bool AllowEdit
    {
      get { return !IsReadOnly; }
    }

    public bool AllowRemove
    {
      get { return !IsFixedSize; }
    }

    public bool SupportsChangeNotification
    {
      get { return true; }
    }

    public bool SupportsSearching
    {
      get { return false; }
    }

    public bool SupportsSorting
    {
      get { return true; }
    }

    public bool IsSorted
    {
      get { return sortDescriptions != null; }
    }

    public PropertyDescriptor SortProperty
    {
      get
      {
        return
          ((sortDescriptions == null) || (sortDescriptions.Count == 0))
          ? null : sortDescriptions[0].PropertyDescriptor;
      }
    }

    public ListSortDirection SortDirection
    {
      get
      {
        return
          ((sortDescriptions == null) || (sortDescriptions.Count == 0))
            ? ListSortDirection.Ascending
            : sortDescriptions[0].SortDirection;
      }
    }

    #endregion

    #region IList Members

    public int Add(object value)
    {
      InsertItem(Count, (T)value);
      return RealIndex(Count - 1);
    }

    public bool Contains(object value)
    {
      return Contains((T)value);
    }

    public void Clear()
    {
      ((ICollection<T>)this).Clear();
    }

    void ICollection<T>.Clear()
    {
      CheckFixedSize();
      foreach (T item in InnerList)
        UnhookPropertyChanged(item);
      InnerList.Clear();
      OnListChanged(ListChangedType.Reset, 0);
    }

    public bool Contains(T item)
    {
      return InnerList.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      InnerList.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
      RemoveItem(IndexOf(item));
      return true;
    }

    int ICollection<T>.Count
    {
      get { return InnerList.Count; }
    }

    public int IndexOf(object value)
    {
      return IndexOf((T)value);
    }

    public void Insert(int index, object value)
    {
      InsertItem(index, (T)value);
    }

    public void Remove(object value)
    {
      RemoveItem(IndexOf((T)value));
    }

    public void RemoveAt(int index)
    {
      RemoveItem(index);
    }

    void IList<T>.RemoveAt(int index)
    {
      CheckFixedSize();
      CheckIndexOfBound(index);
      if (IsSorted)
      {
        //initiatedLocally = true;
        int removeIndex = RealIndex(index);

        //if (InnerList.Count != sortIndex.Count)
        {
          // delete the corresponding value in the sort index
          //if (sortDirection == ListSortDirection.Ascending)
          //  ;//sortIndex.RemoveAt(index);
          //else
            ;
          //sortIndex.RemoveAt(sortIndex.Count - 1 - index);

          // now fix up all index pointers in the sort index
          //foreach (ListItem item in sortIndex)
          //  if (item.BaseIndex > baseIndex)
          //    item.BaseIndex -= 1;
        }

        //initiatedLocally = false;
      }
      RemoveItem(index);
    }

    T IList<T>.this[int index]
    {
      get { return GetItem(index); }
      set { SetItem(index, value); }
    }

    #endregion

    public object this[int index]
    {
      get { return GetItem(index); }
      set { SetItem(index, (T)value); }
    }

    public bool IsReadOnly
    {
      get { return isReadOnly; }
      protected set { isReadOnly = value; }
    }

    public bool IsFixedSize
    {
      get { return isFixedSize; }
      protected set { isFixedSize = value; }
    }

    #endregion

    #region ICollection Members

    public void CopyTo(Array array, int index)
    {
      T[] tmp = new T[array.Length];
      CopyTo(tmp, index);
      Array.Copy(tmp, 0, array, index, array.Length);
    }

    public int Count
    {
      get { return ((ICollection<T>)this).Count; }
    }

    bool ICollection<T>.IsReadOnly
    {
      get { return IsReadOnly; }
    }

    #endregion

    public object SyncRoot
    {
      get { return syncRoot; }
    }

    public bool IsSynchronized
    {
      get { return false; }
    }

    #endregion

    #region ICancelAddNew Members

    public void CancelNew(int itemIndex)
    {
      InnerList.RemoveAt(itemIndex);
    }

    public void EndNew(int itemIndex)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IRaiseItemChangedEvents Members

    bool IRaiseItemChangedEvents.RaisesItemChangedEvents
    {
      get { return RaisesItemChangedEvents; }
    }

    public virtual bool RaisesItemChangedEvents
    {
      get { return raisesItemChangedEvents; }
      protected set { raisesItemChangedEvents = value; }
    }

    #endregion

    #region ITypedList Members

    public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
    {
      if (listAccessors == null || listAccessors.Length == 0)
      {
        return GetTypeProperties(typeof(T));
      }
      else
      {
        string memberName = listAccessors[0].Name;
        PropertyInfo pinfo = typeof(T).GetProperty(memberName);
        if (pinfo != null)
        {
          Type type = pinfo.PropertyType;
          if (typeof(IList).IsAssignableFrom(type) && type.IsGenericType)
          {
            Type paramType = type.GetGenericArguments()[0];
            return GetTypeProperties(paramType);
          }
          return GetTypeProperties(type);
        }
        return null;
      }
    }

    public string GetListName(PropertyDescriptor[] listAccessors)
    {
      return string.Format("InnerList of {0}", typeof(T).Name);
    }

    protected virtual PropertyDescriptorCollection GetTypeProperties(Type type)
    {
      TypeDescriptionProvider provider = TypeDescriptor.GetProvider(type);
      return provider.GetTypeDescriptor(type).GetProperties();
    }

    #endregion

    #region ISupportInitializeNotification Members

    public event EventHandler Initialized;
    protected void OnInitialized()
    {
      if (Initialized != null)
        Initialized(this, EventArgs.Empty);
    }

    public bool IsInitialized
    {
      get { return isInitialized == 0; }
    }

    #region IListSource Members

    public IList GetList()
    {
      return this;
    }

    public bool ContainsListCollection
    {
      get { return true; }
    }

    #endregion

    #endregion

    #region ISupportInitialize Members

    void ISupportInitialize.BeginInit()
    {
      BeginInit();
    }

    void ISupportInitialize.EndInit()
    {
      EndInit();
    }

    public virtual void BeginInit()
    {
      isInitialized++;
    }

    public virtual  void EndInit()
    {
      if (isInitialized > 0)
      {
        isInitialized--;
        if (isInitialized == 0)
        {
          OnInitialized();
        }
      }
    }

    #endregion

    #region IDisposable Members

    ~CoreBindingList()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          Free();
        }
      }
      disposed = true;
    }
    protected virtual void Free()
    {
      Clear();
    }
    #endregion

    #region ToArray

    public T[] ToArray()
    {
      lock (syncRoot)
      {
        List<T> result = new List<T>();
        foreach (T item in this)
          result.Add(item);
        return result.ToArray();
      }
    }

    #endregion

  }
}
