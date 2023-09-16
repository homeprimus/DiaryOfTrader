
using System.Collections;
using System.ComponentModel;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  public class Entity: Element, IComparable, IComparer
  {
    #region fields

    private long _id;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private int _order;
    #endregion

    public Entity()
    {
    }

    public long ID
    {
      get { return _id; }
      set
      {
        if (_id != value)
        {
          _id = value;
          OnPropertyChanged();
        }
      }
    }


    public virtual string Name
    {
      get { return _name;}
      set
      {
        if (_name != value)
        {
          _name = value;
          OnPropertyChanged();
        }
      }
    } 
    public string? Description
    {
      get { return _description; }
      set
      {
        if (_description != value)
        {
          _description = value;
          OnPropertyChanged();
        }
      }
    }

    public virtual int Order
    {
      get { return _order; }
      set
      {
        if (_order != value)
        {
          _order = value;
          OnPropertyChanged();
        }
      }
    }


    public static List<T> GetList<T>() where T : Entity
    {
      using var db = new DiaryOfTraderCtx();
      return db.Set<T>().ToList();
    }

    #region На вылет
    public static void DoBeginEdit<T>(DbSet<T> data, out BindingList<T> orig, out List<T> modify) where T : Entity
    {
      orig = new BindingList<T>(data.OrderBy(e => e.Order).ToList());
      modify = new List<T>(orig);
    }
    public static void DoEndEdit<T>(DbContext context, DbSet<T> data, BindingList<T> orig, List<T> modify, bool update = true) where T : Entity
    {

      orig.Where(e => !modify.Contains(e) && e.Validate).ToList().ForEach(e => data.Add(e));
      modify.Where(e => !orig.Contains(e)).ToList().ForEach(e => data.Remove(e));
      if (update)
        context.SaveChangesAsync();

    }
    public static void DoCancelEdit(DbContext context) 
    {

      foreach (var entry in context.ChangeTracker.Entries())
      {
        switch (entry.State)
        {
          case EntityState.Modified:
            entry.State = EntityState.Unchanged;
            break;
          case EntityState.Added:
            entry.State = EntityState.Detached;
            break;
          case EntityState.Deleted:
            entry.Reload();
            break;
          default: break;
        }
      }
    }
    #endregion
    protected override bool GetValidate()
    {
      return  base.GetValidate() && !string.IsNullOrEmpty(Name);
    }

    public override string ToString()
    {
      return Name;
    }

    public override int GetHashCode()
    {
      return Name.GetHashCode() ^ Order;
    }

    public int Compare(object? x, object? y)
    {
      if (x != null && y != null)
      {
        return string.Compare(((Entity)x).Name, ((Entity)y).Name, StringComparison.InvariantCultureIgnoreCase);
      }

      return 0;
    }

    public override bool Equals(object? obj)
    {
      return CompareTo(obj) == 0;
    }
    public int CompareTo(object? obj)
    {
      var result = 1;
      if (obj is Entity entity)
      {
        result = Order - entity.Order;
        if (result == 0)
        {
          result = string.Compare(Name, entity.Name, StringComparison.InvariantCultureIgnoreCase);
        }
      }
      return result;
    }

  }
}
