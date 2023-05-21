using System.Reflection;

namespace DiaryOfTrader.Core.DynamicCode
{
  internal class DynamicInfo
  {
    private const BindingFlags AllLevelFlags = 
      BindingFlags.FlattenHierarchy | 
      BindingFlags.Instance | 
      BindingFlags.Public | 
      BindingFlags.NonPublic;
    public MemberInfo Info { get; private set;}
    public Dynamic.GetDelegate Get { get; private set; }
    public Dynamic.SetDelegate Set { get; private set; }

    private void InitInfo(MemberInfo memberInfo)
    {
      Info = memberInfo;
      if (!ReferenceEquals(memberInfo, null))
      {
        Get = Dynamic.Get(Info);
        Set = Dynamic.Set(Info);
      }
    }
    private DynamicInfo()
    {
    }

    public static DynamicInfo Empty()
    {
      return new DynamicInfo();
    }

    public DynamicInfo(MemberInfo fieldInfo)
    {
      InitInfo(fieldInfo);
    }
    public DynamicInfo(Type type, string name)
    {
      var mi = type.GetMember(name, AllLevelFlags);
      if (mi.Length > 0)
      {
        foreach (var info in mi)
          if (info.Name == name)
          {
            InitInfo(info);
            break;
          }
      }
    }
    public Type InfoType
    {
      get
      {
        Type result = null;
        if (Info != null)
        {
          result = Info.MemberType == MemberTypes.Property ?
            ((PropertyInfo)Info).PropertyType :
            ((FieldInfo)Info).FieldType;
        }
        return result;
      }
    }
  }
}
