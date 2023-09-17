namespace Exchange.Core.DynamicCode
{
  internal class DynamicCacheKey: IComparable
  {
    private static Type[] EmptyArray = new Type[]{};
    public Type Self { get; private set; }
    public string Method { get; private set; }
    public Type[] Params { get; private set; }
    private readonly int hashCode;

    public DynamicCacheKey(Type self, string method, Type[] param)
    {
      Self = self;
      Method = method;
      Params = param ?? EmptyArray;
      hashCode = self.AssemblyQualifiedName.GetHashCode();
      hashCode = hashCode ^ method.GetHashCode();
      foreach (var item in Params)
        hashCode = hashCode ^ item.AssemblyQualifiedName.GetHashCode();
    }
    public override int GetHashCode()
    {
      return hashCode;
    }

    public int CompareTo(object obj)
    {
      var result = -1;
      var cacheKey = obj as DynamicCacheKey;
      if (cacheKey != null)
      {
        //result = Self.FullName.CompareTo(cacheKey.Self.FullName);
        result = Self.AssemblyQualifiedName.CompareTo(cacheKey.Self.AssemblyQualifiedName);
        if (result == 0)
        {
          result = Method.CompareTo(cacheKey.Method);
          if (result == 0)
          {
            result = Params.Length.CompareTo(cacheKey.Params.Length);
            if (result == 0)
            {
              for (var i = 0; i < Params.Length; i++)
              {
                result = Params[i].AssemblyQualifiedName.CompareTo(cacheKey.Params[i].AssemblyQualifiedName);
                if (result != 0)
                  break;
              }
            }
          }
        }
      }
      return result;
    }

    public override bool Equals(object obj)
    {
      return CompareTo(obj) == 0;
    }
  }
}
