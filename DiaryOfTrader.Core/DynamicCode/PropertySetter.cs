using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using DiaryOfTrader.Core.Interfaces;
using DiaryOfTrader.Core.Utils;

namespace DiaryOfTrader.Core.DynamicCode
{
  internal class ConvertableAttributeSetter : IAttributeSetter
  {

    public virtual void From(object sender, DynamicInfo core, string value)
    {
      var propertyValue = Convert.ChangeType(value, core.InfoType);//, CultureInfo.InvariantCulture);
      core.Set(sender, propertyValue);
    }

    public virtual string To(DynamicInfo core, object value)
    {
      return value.ToString();
    }
  }

  internal class StringAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      var propertyValue =
          Attribute.GetCustomAttribute(core.Info, typeof(PasswordPropertyTextAttribute)) != null
            ? Crypt.DecryptPassword(value) : value;
      core.Set(sender, propertyValue);
    }
    public override string To(DynamicInfo core, object value)
    {
      var result = value.ToString();
      return
          Attribute.GetCustomAttribute(core.Info, typeof(PasswordPropertyTextAttribute)) != null
            ? Crypt.EncryptPassword(result) : result;
    }
  }

  internal class GuidAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      core.Set(sender, new Guid(value));
    }
  }

  internal class EnumAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      var tc = TypeDescriptor.GetConverter(core.InfoType);
      var propertyValue = !(tc.GetType() == typeof(EnumConverter))
                               ? tc.ConvertFrom(value)
                               : Enum.Parse(core.InfoType, value);
      core.Set(sender, propertyValue);
    }
    public override string To(DynamicInfo core, object value)
    {
      return base.To(core, (int)value);
    }
  }

  internal class TimeSpanAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      if (!TimeSpan.TryParse(value, out var propertyValue))
      {
        propertyValue = TimeSpan.MinValue;
      }
      core.Set(sender, propertyValue);
    }
  }
  internal class VersionAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      var propertyValue = new Version(value);
      core.Set(sender, propertyValue);
    }
  }
  internal class DateTimeAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      if (!DateTime.TryParse(value, out var propertyValue))
      {
        if (!DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out propertyValue))
        {
          propertyValue = DateTime.MinValue;
        }
      }
      core.Set(sender, propertyValue);
    }
  }
  internal class BooleanAttributeSetter : ConvertableAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      if (int.TryParse(value, out var intValue))
      {
        var propertyValue = intValue != 0;
        core.Set(sender, propertyValue);
      }
      else
      {
        base.From(sender, core, value);
      }
    }
  }

  internal class PointAttributeSetter : ConvertableAttributeSetter
  {
    private static readonly Regex regexPointSize = new Regex(@"{\w+=(?<first>\d*)\s?,\s?\w+=(?<second>\d*)}");
    protected static bool Math(out int first, out int second, string value)
    {
      var m = regexPointSize.Match(value);
      var result = m.Success;
      if (result)
      {
        first = int.Parse(m.Result("${first}"));
        second = int.Parse(m.Result("${second}"));
      }
      else
      {
        first = -1;
        second = -1;
      }
      return result;
    }
    public override void From(object sender, DynamicInfo core, string value)
    {
      if (Math(out var first, out var second, value))
      {
        var propertyValue = new Point(first, second);
        core.Set(sender, propertyValue);
      }
    }
  }
  internal class SizeAttributeSetter : PointAttributeSetter
  {
    public override void From(object sender, DynamicInfo core, string value)
    {
      if (Math(out var first, out var second, value))
      {
        var propertyValue = new Size(first, second);
        core.Set(sender, propertyValue);
      }
    }
  }

  internal class PropertySetter : IPropertySetter
  {
    private static readonly ConvertableAttributeSetter shared = new ConvertableAttributeSetter();
    private static readonly EnumAttributeSetter enumAttributeSetter = new EnumAttributeSetter();

    private readonly Dictionary<Type, IAttributeSetter> setDictionary;
    private static PropertySetter Handle;
    protected PropertySetter()
    {
      setDictionary = new Dictionary<Type, IAttributeSetter>()
                     {
                       {typeof (string), new StringAttributeSetter()},
                       {typeof (TimeSpan), new TimeSpanAttributeSetter()},
                       {typeof (DateTime), new DateTimeAttributeSetter()},
                       {typeof (Version), new VersionAttributeSetter()},
                       {typeof (Point), new PointAttributeSetter()},
                       {typeof (Size), new SizeAttributeSetter()},
                       {typeof (bool), new BooleanAttributeSetter()},
                       {typeof (Guid), new GuidAttributeSetter()},
                       {typeof (object), shared},
                     };
    }

    protected Dictionary<Type, IAttributeSetter> Dictionary
    {
      get { return setDictionary; }
    }

    public static IPropertySetter Instance
    {
      get
      {
        if (ReferenceEquals(Handle, null))
        {
          Handle = new PropertySetter();
        }
        return Handle;
      }
    }
    private IAttributeSetter GetSetter(Type type)
    {
      if (!setDictionary.TryGetValue(type, out var result))
      {
        result = type.IsEnum ? enumAttributeSetter : shared;
      }
      return result;
    }

    private void Get(object sender, DynamicInfo core, string value)
    {
      GetSetter(core.InfoType).From(sender, core, value);
    }

    public void Get(object sender, DynamicInfo core, object? value)
    {
      var stringValue = value == null ? string.Empty : value.ToString();
      Get(sender, core, stringValue);
    }
    public void Get(object sender, DynamicInfo core, XmlNode? node)
    {
      if (node != null)
      {
        Get(sender, core, node.Value);
      }
    }

    public void Set(object sender, DynamicInfo core, XmlNode? node)
    {
      if (node != null)
      {
        var value = core.Get(sender);
        node.Value = value == null ? string.Empty : GetSetter(core.InfoType).To(core, value);
      }
    }

  }


}
