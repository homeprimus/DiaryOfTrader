using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DiaryOfTrader.Core.Core
{
  public static class SerializationFormatterFactory
  {
#pragma warning disable SYSLIB0011
    public static IFormatter GetFormatter()
    {
      return new BinaryFormatter();
    }
#pragma warning restore SYSLIB0011
  }

  public static class ObjectCloner
  {
    public static object Clone(object obj)
    {
      using (var buffer = new MemoryStream())
      {
        var formatter = SerializationFormatterFactory.GetFormatter();
        formatter.Serialize(buffer, obj);
        buffer.Position = 0;
        var temp = formatter.Deserialize(buffer);
        return temp;
      }
    }
  }

}
