using System.Reflection;
using Exchange.Core.DynamicCode;

namespace DiaryOfTrader.Core.DynamicCode
{
  public static class ProxyLibrary
  {
    #region private field

    private static readonly Dictionary<DynamicCacheKey, DynamicInfo> dynamicInfo =
      new Dictionary<DynamicCacheKey, DynamicInfo>();


    // for PL objects
    private static readonly Dictionary<DynamicCacheKey, IList<DynamicProp>> dynamicProp =
      new Dictionary<DynamicCacheKey, IList<DynamicProp>>();


    private static readonly Dictionary<Type, Dynamic.CtorDelegate> dynamicCtor =
      new Dictionary<Type, Dynamic.CtorDelegate>();


    private static readonly Dictionary<DynamicCacheKey, DynamicCall> dynamicCall =
      new Dictionary<DynamicCacheKey, DynamicCall>();


    private const BindingFlags bindingFlags = BindingFlags.Instance |
                                              BindingFlags.Public |
                                              BindingFlags.NonPublic;

  #endregion
    internal static Dynamic.CtorDelegate CreateInfo(Type type)
    {
      Dynamic.CtorDelegate result;
      if (!dynamicCtor.TryGetValue(type, out result))
      {
        lock (dynamicCtor)
        {
          if (!dynamicCtor.TryGetValue(type, out result))
          {
            result = Dynamic.Constructor(type);
            dynamicCtor.Add(type, result);
          }
        }
      }
      if (result == null)
      {
        throw new NotImplementedException("Dynamic.CtorDelegate CreateInfo");
      }
      return result;
    }


    #region default constructor

    public static T Create<T>(Type type)
    {
      return (T)Create(type);
    }

    public static object Create(Type type)
    {
      return CreateInfo(type).Invoke();
    }

    #endregion

    //

    #region constructor with param

    public static T Create<T>(Type type, params object[] args)
    {
      return (T)Create(type, args);
    }

    public static object Create(Type type, params object[] args)
    {
      try
      {
        return Activator.CreateInstance(type, args);
      }
      catch (TargetInvocationException e)
      {
        throw e.InnerException;
      }
    }

    #endregion

    internal static DynamicInfo PropInfo(Type type, string field)
    {
      var key = new DynamicCacheKey(type, field, null);
      if (!dynamicInfo.TryGetValue(key, out var result))
      {
        lock (dynamicInfo)
        {
          if (!dynamicInfo.TryGetValue(key, out result))
          {
            try
            {
              result = new DynamicInfo(type, field);
            }
            catch (Exception)
            {
              result = DynamicInfo.Empty();
            }
            dynamicInfo.Add(key, result);
          }
        }
      }
      return result;
    }

    public static void Set(object sender, string field, object value)
    {
      var prop = PropInfo(sender.GetType(), field);
      if (prop != null && prop.Set != null) prop.Set(sender, value);
    }

    public static object? Get(object sender, string field)
    {
      var prop = PropInfo(sender.GetType(), field);
      return prop != null && prop.Get != null ? prop.Get(sender) : null;
    }

    public static T? Get<T>(object sender, string field)
    {
      var prop = PropInfo(sender.GetType(), field);
      return prop != null && prop.Get != null ? (T)prop.Get(sender) : default(T);
    }


    internal static DynamicCall CallInfo(Type type, string field, params Type[] args)
    {
      var key = new DynamicCacheKey(type, field, args);
      if (!dynamicCall.TryGetValue(key, out var result))
      {
        lock (dynamicCall)
        {
          if (!dynamicCall.TryGetValue(key, out result))
          {
            result = new DynamicCall(type, field, args);
            dynamicCall.Add(key, result);
          }
        }
      }
      if (result == null)
      {
        throw new NotImplementedException("DynamicCall CallInfo");
      }
      return result;
    }

    public static object Call(object sender, string field, params object[] args)
    {
      return CallInfo(sender.GetType(), field, Dynamic.GetParameterTypes(args)).Call(sender, args);
    }

    internal static IList<DynamicProp> GetPropertyCache<TProp, TObject>()
    {
      return GetPropertyCache<TProp>(typeof(TObject));
    }

    internal static IList<DynamicProp> GetPropertyCache<TProp>(Type objectType)
    {
      return GetPropertyCache(typeof(TProp), objectType);
    }

    private static IList<DynamicProp> GetPropertyCache(Type keyAttributeType, Type self)
    {
      var key = new DynamicCacheKey(self, "DynamicProp", new[] { keyAttributeType });

      if (!dynamicProp.TryGetValue(key, out IList<DynamicProp> result))
      {
        lock (dynamicProp)
        {
          if (!dynamicProp.TryGetValue(key, out result))
          {
            var list = new List<DynamicProp>();
            var properties = self.GetMembers(bindingFlags);
            foreach (var property in properties)
            {
              switch (property.MemberType)
              {
                case MemberTypes.Field:
                case MemberTypes.Property:
                  {
                    var assign = property.GetCustomAttributes(keyAttributeType, true);
                    foreach (Attribute attribute in assign)
                    {
                      if (attribute.GetType() == keyAttributeType)
                      {
                        list.Add(new DynamicProp(property.Name, attribute, self,
                                                 PropInfo(self, property.Name)));
                        break;
                      }
                    }
                  }
                  break;
              }
            }

            list.Sort();
            result = list.ToArray();
            dynamicProp.Add(key, result);
          }
        }
      }
      return result;
    }

  }
}
