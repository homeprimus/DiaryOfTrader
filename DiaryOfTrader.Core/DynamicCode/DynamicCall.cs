using System.Reflection;

namespace DiaryOfTrader.Core.DynamicCode
{
  internal class DynamicCall
  {
    public Type Self { get; private set ; }
    public Dynamic.CallDelegate Call{ get; private set;}
    public MethodInfo Info { get; private set;}

    public DynamicCall(Type self, string name, params Type[] args)
    { 
      Self = self;
      Info = Dynamic.FindMethod(Self, name, args);
      Call = Dynamic.Method(Info);
    }

  }
}
