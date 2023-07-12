
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Utils;

namespace DiaryOfTrader.Core.Entity
{
  public class Entity: Element, IComparable
  {
    public Entity()
    {
      Order = 0;
    }
    public long ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }


    public string ClassDescription
    {
      get
      {
        return ReflectionUtils.ClassDescription(GetType());
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
