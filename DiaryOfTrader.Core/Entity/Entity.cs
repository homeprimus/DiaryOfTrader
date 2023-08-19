
using System.ComponentModel;
using System.Text.Json.Serialization;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader.Core.Entity
{
  public class Entity: Element, IComparable
  {

    public Entity()
    {
      Order = 0;
    }

    public long ID { get; set; }
    public virtual string Name { get; set; }
    public string? Description { get; set; }
    public virtual int Order { get; set; }

    [JsonIgnore]
    public string ClassDescription
    {
      get
      {
        return ReflectionUtils.ClassDescription(GetType());
      }
    }

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

    protected override bool GetValidate()
    {
      return  base.GetValidate() && !string.IsNullOrEmpty(Name);
    }

    public override string ToString()
    {
      return Name;
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
