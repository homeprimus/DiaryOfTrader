namespace DiaryOfTrader.Core.DynamicCode
{
  internal class DynamicProp : IComparable
  {
    protected int hashCode { get; set; }
    public Attribute Attribute { get; private set; }
    public DynamicInfo Core { get; private set; }

    public DynamicProp(string field, Attribute attribute, Type core, DynamicInfo coreInfo)
    {
      Attribute = attribute;
      Core = coreInfo;
      hashCode = Attribute.GetHashCode() ^ core.FullName.GetHashCode() ^ field.GetHashCode();
    }

    public int CompareTo(object obj)
    {
      var result = 1;
      var self = obj as DynamicProp;
      if (self != null)
        result = ((IComparable) Attribute).CompareTo(self.Attribute);
      return result;
    }
    public override string ToString()
    {
      return Attribute.ToString();
    }
    public override bool Equals(object obj)
    {
      return CompareTo(obj) == 0;
    }
    public override int GetHashCode()
    {
      return hashCode;
    }
  }

  internal class DynamicAssingProp : IComparable
  {
    protected int hashCode { get; set; }
    public IFieldOrder Attribute { get; private set; }
    public DynamicInfo Core { get; private set; }
    public DynamicInfo Inner { get; private set; }

    public DynamicAssingProp(IFieldOrder attribute, Type core, DynamicInfo coreInfo, Type inner, DynamicInfo innerInfo)
    {
      Attribute = attribute;
      Core = coreInfo;
      Inner = innerInfo;
      hashCode = Attribute.GetHashCode() ^ core.FullName.GetHashCode() ^ inner.FullName.GetHashCode();
    }
    public int CompareTo(object obj)
    {
      return Attribute.CompareTo(((DynamicAssingProp)obj).Attribute);
    }
    public override string ToString()
    {
      return Attribute.ToString();
    }
    public override bool Equals(object obj)
    {
      return CompareTo(obj) == 0;
    }
    public override int GetHashCode()
    {
      return hashCode;
    }

  }

}
