using System.Collections;
using System.ComponentModel;
using System.Reflection;
using DiaryOfTrader.Core.Attributes;
using DiaryOfTrader.Core.Core;
using DiaryOfTrader.Core.Properties;

namespace DiaryOfTrader.Core.Utils
{
  public static class ReflectionUtils
  {
    private static readonly Dictionary<string, Assembly> assemblyUI = 
      new Dictionary<string, Assembly>();


    public static string EnumDescription(Type type, object value)
    {
      return EnumDescription(type, typeof(DescriptionAttribute), value);
    }

    private static string EnumDescription(Type type, Type enumType, object value)
    {
      var result = string.Empty;
      var array = value.ToString()?.Split(',');

      if (array != null)
      {
        foreach (var s in array)
        {
          var da = Attribute.GetCustomAttributes(type.GetField(s.Trim()), enumType, false);
          foreach (var attribute in da)
          {
            if (attribute.GetType() == enumType)
            {
              var description = ((DescriptionAttribute)attribute).Description;
              result = result + (string.IsNullOrEmpty(result) ? description : ", " + description);
              break;
            }
          }
        }

        if (string.IsNullOrEmpty(result))
          result = string.Join(", ", array);
      }

      return result;
    }

    public static TypeConverter GetTypeConverter(object self, string field)
    {
      TypeConverter result = null;
      var info = self.GetType().GetMember(field,
                                          BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
      var attr =
        (TypeConverterAttribute) Attribute.GetCustomAttribute(info[0], typeof (TypeConverterAttribute))!;
      if (!string.IsNullOrEmpty(attr.ConverterTypeName))
        result =
          (TypeConverter)
          MakeNew(Type.GetType(attr.ConverterTypeName), new object[] {((PropertyInfo) info[0]).PropertyType});
      return result;
    }

    public static KeyValuePair<string, object>[] EnumDescriptionList(Type enumType, Type attrType)
    {
      return EnumDescriptionList(enumType, attrType, false);
    }
    public static KeyValuePair<string, object>[] EnumDescriptionList(Type enumType, Type attrType, bool skipEmpty)
    {
      var result = new List<KeyValuePair<string, object>>();
      var values = Enum.GetValues(enumType);
      foreach (var o in values)
      {
        var s = string.Empty;
        var fi = enumType.GetField(Enum.GetName(enumType, o));
        var da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, attrType);
        if (da != null)
          s = da.Description;
        else
          if (!skipEmpty)
            s = o.ToString();
        if (!string.IsNullOrEmpty(s))
          result.Add(new KeyValuePair<string, object>(s, o));
      }
      return result.ToArray();
    }


    public static T MakeNew<T>(params object[] args)
    {
      return (T)MakeNew(typeof(T), args);
    }
    public static Object MakeNew(Type type, params object[] args)
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

    public static string PropertyDescription(Type core, string propertyName)
    {
      var result = string.Empty;
      var property = core.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
      var assign = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
      if ((assign.Length > 0) && (assign[0] is DescriptionAttribute))
        result = ((DescriptionAttribute)assign[0]).Description;
      return result;
    }

    public static string ClassDescription(Type core)
    {
      return Resources.ResourceManager.GetString(core.Name) ?? string.Empty;
    }


    private static Assembly GetAssembly(string assembly)
    {
      Assembly result;
      var key = assembly.ToLowerInvariant();
      if (!assemblyUI.TryGetValue(key, out result))
      {
        lock (assemblyUI)
        {
          if (!assemblyUI.TryGetValue(key, out result))
          {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
              try
              {
                if (string.Compare(key, Path.GetFileName(a.Location), true) == 0)
                {
                  result = a;
                  break;
                }
              }
              catch (Exception)
              {
              }
            }

            if (result == null)
            {
              result = Assembly.LoadFile(
                Path.Combine(
                  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                  assembly)
                );
            }
            assemblyUI[key] = result;
          }
        }
      }
      if (result == null)
      {
        throw new Exception(string.Format("Assembly not found: \"{0}\"", assembly));
      }
      return result;
    }

    internal static IList<object> UIObject<T>(Type selfType) where T : ClassEditGUIAttribute
    {
      var result = new List<object>();
      var uiAttribute = typeof (T);
      var editAttr = new List<T>();
      var currentType = selfType;
      while (editAttr.Count == 0 && currentType != typeof (Element))
      {
        foreach (var attr in Attribute.GetCustomAttributes(currentType, uiAttribute, false))
        {
          if (attr.GetType() == uiAttribute)
          {
            editAttr.Add(attr as T);
            //break;
          }
        }
        currentType = currentType.BaseType;
      }

      if (editAttr.Count == 0)
      {
        throw new Exception(string.Format("GUI attribyte not found for this class: \"{0}\"", selfType));
      }

      editAttr.Sort();
      foreach (var gui in editAttr)
      {
        var asm = GetAssembly(gui.Assembly);
        var type = asm.GetType(gui.Control, false, true);
        if (type != null)
        {
          var ci = type.GetConstructor(new Type[] {});
          if (ci != null) 
            result.Add(ci.Invoke(new object[] {}));
        }
        else
        {
          throw new Exception(
            string.Format("Edit Control not found: \"{0}\" in assembly: \"{1}\"",
                          gui.Control,
                          gui.Assembly)
            );
        }
      }
      return result;
    }

    public static void AssignTo(object self, object to)
    {
      var toType = to.GetType();
      var properties = self.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
      foreach (var property in properties)
      {
        if (property.CanRead)
        {
          try
          {
            var pi = toType.GetProperty(property.Name);
            if (pi != null && pi.CanWrite)
            {
              var value = property.GetValue(self, null);
              pi.SetValue(to, value, null);
            }
          }
          catch(Exception e)
          {
            Console.WriteLine(e);
          }
        }
      }
    }

    public static string ReadQuery(Type core, int version)
    {
      var result = string.Empty;
      var attrs = Attribute.GetCustomAttributes(core, typeof(DataReadQueryAttribute)) as DataReadQueryAttribute[];
      if (!ReferenceEquals(attrs, null) && attrs.Length > 0)
      {
          result = attrs[0].Query;
      }
      return result;
    }
  }
}
