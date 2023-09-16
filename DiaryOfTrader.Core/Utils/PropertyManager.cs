using System.Collections;
using System.Reflection;

namespace DiaryOfTrader.Core.Utils
{
  internal class PropertyValue
  {
    #region private
    private readonly PropertyInfo property = null;
    private readonly object value = null;
    #endregion
    public PropertyValue(PropertyInfo property, object value)
    {
      this.property = property;
      this.value = value;
    }
    public PropertyInfo Property
    {
      get { return property; }
    }
    public object Value
    {
      get { return value; }
    }
  }

  internal static class PropertyManager
  {
    #region private
    private static Hashtable hashType = null;
    private static Hashtable HashType
    {
      get
      {
        if (hashType == null)
        {
          lock (typeof(PropertyManager))
          {
            if (hashType == null)
              hashType = new Hashtable();
          }
        }
        return hashType;
      }
    }
    #endregion

    private static string KeyValue(Type keyAttributeType, Type objectType)
    {
      return keyAttributeType.Name + "!" + objectType.Name;
    }

    public static PropertyValue[] GetPropertyMapField(Type fieldAttributeType, Type objectType)
    {
      PropertyValue[] result;
      var cache = HashType;
      lock (cache)
      {
        var key = KeyValue(fieldAttributeType, objectType);
        if (cache.ContainsKey(key))
        {
          result = (PropertyValue[])cache[key];
        }
        else
        {
          var list = new List<PropertyValue>();
          var properties = objectType.GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
          foreach (var property in properties)
          {
            var assign = property.GetCustomAttributes(fieldAttributeType, true);
            foreach (var o in assign)
              if (o.GetType() == fieldAttributeType)
              {
                var pv = new PropertyValue(property, o);
                var map = o as MapFieldAttribute;
                if (map != null)
                {
                  var classes = map.Mapped.Split('.');
                  if (property.PropertyType.IsClass)
                  {
                    //property.PropertyType.GetProperty(classes[i])
                  }
                }
                list.Add(pv);
                break;
              }
          }
          result = list.ToArray();
          cache.Add(key, result);
        }
      }
      return result;
    }
    public static PropertyValue[] GetPropertyMapField<T>(Type fieldAttributeType)
    {
      return GetPropertyMapField(fieldAttributeType, typeof(T));
    }
    public static PropertyValue[] GetPropertyCache<T>(Type keyAttributeType)
    {
      return GetPropertyCache(keyAttributeType, typeof (T));
    }
    public static PropertyValue[] GetPropertyCache(Type keyAttributeType, Type objectType)
    {
      PropertyValue[] result;
      Hashtable cache = HashType;
      lock (cache)
      {
        string key = KeyValue(keyAttributeType, objectType);
        if (cache.ContainsKey(key))
        {
          result = (PropertyValue[])cache[key];
        }
        else
        {
          var list = new List<PropertyValue>();
          var properties = objectType.GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
          foreach (var property in properties)
          {
            var assign = property.GetCustomAttributes(keyAttributeType, true);
            foreach (var o in assign)
              if (o.GetType() == keyAttributeType)
              {
                list.Add(new PropertyValue(property, o));
                break;
              }
          }
          result = list.ToArray();
          cache.Add(key, result);
        }
      }
      return result;
    }
    public static void SetValue(object self, PropertyInfo propertyInfo, object value)
    {
      if (value != null)
      {
        var pType = propertyInfo.PropertyType;
        var vType = value.GetType();
        if (!pType.Equals(vType))
        {
          if (pType.Equals(typeof (Guid)))
          {
            value = new Guid(value.ToString());
          }
          else if (pType.IsEnum && vType.Equals(typeof (string)))
          {
            value = Enum.Parse(pType, value.ToString());
          }
          else if (pType.Equals(typeof(TimeSpan)))
          {
            var s = value.ToString();
            if (s.Length < 8)
            {
              s = s.PadLeft(6, '0').Insert(4, ":").Insert(2, ":");
            }
            value = TimeSpan.Parse(s);
          }
          else
          {
            value = Convert.ChangeType(value, pType);
          }
        }
      }
      propertyInfo.SetValue(self, value, null);
    }

  }
}
