using System.Xml;
using DiaryOfTrader.Core.DynamicCode;

namespace DiaryOfTrader.Core.Interfaces
{
  internal interface IAttributeSetter
  {
    void From(object sender, DynamicInfo core, string value);
    string To(DynamicInfo core, object value);
  }

  internal interface IPropertySetter
  {
    void Get(object sender, DynamicInfo core, XmlNode? node);
    void Get(object sender, DynamicInfo core, object? value);
    void Set(object sender, DynamicInfo core, XmlNode? node);
  }

}
