
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
