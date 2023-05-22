using System.ComponentModel;
using System.Xml.Serialization;

namespace DiaryOfTrader.Core.Attributes
{
  
  public interface IOrder : IComparable
  {
    int Order { get; }
  }
  public interface IFieldOrder : IOrder
  {
    string Field { get; }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  public class OrderAttribute : Attribute, IOrder
  {
    public OrderAttribute() : this(int.MaxValue) { }
    public OrderAttribute(int order)
    {
      Order = order;
    }
    [DefaultValue(int.MaxValue)]
    public int Order
    {
      get;
    }
    #region IComparable
    public virtual int CompareTo(object? obj)
    {
      var result = 1;
      if (obj is IOrder fa)
      {
        result = Order.CompareTo(fa.Order);
      }
      return result;
    }
    #endregion
    #region override
    public override bool Equals(object? obj)
    {
      return CompareTo(obj) == 0;
    }
    public override int GetHashCode()
    {
      return Order.GetHashCode();
    }
    public override string ToString()
    {
      return Order.ToString();
    }
    #endregion
    #region operators
    public static bool operator ==(OrderAttribute src, OrderAttribute dst)
    {
      return
        !ReferenceEquals(src, null)
          ? src.CompareTo(dst) == 0
          : ReferenceEquals(dst, null) ? true : false;
    }
    public static bool operator !=(OrderAttribute src, OrderAttribute dst)
    {
      return !(src == dst);
    }
    public static bool operator <(OrderAttribute src, OrderAttribute dst)
    {
      return
        !ReferenceEquals(src, null)
          ? src.CompareTo(dst) < 0
          : false;

    }
    public static bool operator >(OrderAttribute src, OrderAttribute dst)
    {
      return
        !ReferenceEquals(src, null)
          ? src.CompareTo(dst) > 0
          : false;
    }
    #endregion
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  public class FieldOrderAttribute : OrderAttribute, IFieldOrder
  {
    public FieldOrderAttribute() : this(int.MaxValue, string.Empty) { }
    public FieldOrderAttribute(int order) : this(order, string.Empty) { }
    public FieldOrderAttribute(string field) : this(int.MaxValue, field) { }
    public FieldOrderAttribute(int order, string field):base(order)
    {
      Field = field ?? string.Empty;
    }
    #region IFieldOrderAttribute
    [DefaultValue("")]
    public string Field
    {
      get; internal set;
    }

    #endregion
    #region IComparable
    public override int CompareTo(object obj)
    {
      var result = base.CompareTo(obj);
      if (result == 0)
        result = string.Compare(Field, ((IFieldOrder)obj).Field, false);
      return result;
    }
    #endregion
    #region override
    public override bool Equals(object obj)
    {
      return CompareTo(obj) == 0;
    }
    public override int GetHashCode()
    {
      return Field.GetHashCode() ^ Order.GetHashCode();
    }
    public override string ToString()
    {
      return Field;
    }
    #endregion
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class DataReadQueryAttribute : OrderAttribute
  {
    public DataReadQueryAttribute(string query)
    {
      Query = query;
    }
    [DefaultValue("")]
    public string Query { get; set; }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class DataFieldAttribute : FieldOrderAttribute
  {
    public DataFieldAttribute(string field) : this(int.MaxValue, field) { }
    public DataFieldAttribute(int order, string field)
      : base(order, field)
    {
    }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class OrderXmlAttributeAttribute : XmlAttributeAttribute, IOrder
  {
    private readonly int order = int.MaxValue;
    public OrderXmlAttributeAttribute()
    {
    }
    public OrderXmlAttributeAttribute(string attributeName)
      : this(int.MaxValue, attributeName, null)
    {
    }
    public OrderXmlAttributeAttribute(Type type)
      : this(int.MaxValue, string.Empty, type)
    {
    }
    public OrderXmlAttributeAttribute(string attributeName, Type type)
      : this(int.MaxValue, attributeName, type)
    {
    }
    public OrderXmlAttributeAttribute(int order)
      : this(order, string.Empty, null)
    {
    }
    public OrderXmlAttributeAttribute(int order, string attributeName)
      : this(order, attributeName, null)
    {
    }
    public OrderXmlAttributeAttribute(int order, string attributeName, Type type)
      : base(attributeName, type)
    {
      this.order = order;
    }

    public int Order
    {
      get { return order; }
    }

    public int CompareTo(object? obj)
    {
      var result = 1;
      var or = obj as OrderXmlAttributeAttribute;
      if (!ReferenceEquals(or, null))
      {
        result = Order.CompareTo(or.Order);
        if (result == 0)
          result = string.Compare(AttributeName, or.AttributeName, false);
      }
      return result;
    }
    public override bool Equals(object? obj)
    {
      return CompareTo(obj) == 0;
    }
    public override int GetHashCode()
    {
      return base.GetHashCode() ^ order.GetHashCode();
    }
  }

  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class MapFieldAttribute : FieldOrderAttribute
  {
    private readonly string mappedAttribute = string.Empty;
    public MapFieldAttribute() : this(string.Empty, string.Empty, 0) { }
    public MapFieldAttribute(string fieldAttribute) : this(fieldAttribute, string.Empty, 0) { }
    public MapFieldAttribute(string fieldAttribute, int order) : this(fieldAttribute, string.Empty, order) { }
    public MapFieldAttribute(string fieldAttribute, string mappedAttribute) : this(fieldAttribute, mappedAttribute, 0) { }
    public MapFieldAttribute(string fieldAttribute, string mappedAttribute, int order)
      : base(order, fieldAttribute)
    {
      this.mappedAttribute = mappedAttribute ?? string.Empty;
    }
    [DefaultValue("")]
    public string Mapped { get { return mappedAttribute; } }
  }

  [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
  public sealed class GetFieldAttribute : MapFieldAttribute
  {
    public GetFieldAttribute() : this(string.Empty, string.Empty, 0) { }
    public GetFieldAttribute(string fieldAttribute) : this(fieldAttribute, string.Empty, 0) { }
    public GetFieldAttribute(string fieldAttribute, int order) : this(fieldAttribute, string.Empty, order) { }
    public GetFieldAttribute(string fieldAttribute, string mappedAttribute) : this(fieldAttribute, mappedAttribute, 0) { }
    public GetFieldAttribute(string fieldAttribute, string mappedAttribute, int order): 
      base(fieldAttribute, mappedAttribute, order)
    {
    }
  }


  [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
  public sealed class SetFieldAttribute : MapFieldAttribute
  {
    public SetFieldAttribute() : this(string.Empty, string.Empty, 0) { }
    public SetFieldAttribute(string fieldAttribute) : this(fieldAttribute, string.Empty, 0) { }
    public SetFieldAttribute(string fieldAttribute, int order) : this(fieldAttribute, string.Empty, order) { }
    public SetFieldAttribute(string fieldAttribute, string mappedAttribute) : this(fieldAttribute, mappedAttribute, 0) { }
    public SetFieldAttribute(string fieldAttribute, string mappedAttribute, int order): 
      base(fieldAttribute, mappedAttribute, order)
    {
    }
  }



  [AttributeUsage(AttributeTargets.Class, Inherited = false)]
  public class ClassEditGUIAttribute : FieldOrderAttribute
  {
    public ClassEditGUIAttribute(string assembly, string control) : this(int.MaxValue, assembly, control) { }
    public ClassEditGUIAttribute(int order, string assembly, string control): base(order, control)
    {
      Assembly = assembly;
    }

    public string Assembly { get; private set; }
    public string Control
    {
      get { return Field; }
      set { Field = value; }
    }
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class ClassEditControlAttribute : ClassEditGUIAttribute
  {
    public ClassEditControlAttribute(string assembly, string control) : this(int.MaxValue, assembly, control){}
    public ClassEditControlAttribute(int order, string assembly, string control): base(order, assembly, control){}
  }

  [AttributeUsage(AttributeTargets.Class)]
  public class ClassWokerGUIAttribute : ClassEditGUIAttribute
  {
    public ClassWokerGUIAttribute(string assembly, string gui) : base(assembly, gui)
    {
    }
  }
}
