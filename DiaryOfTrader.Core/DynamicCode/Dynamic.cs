using System.Reflection;
using System.Reflection.Emit;

namespace DiaryOfTrader.Core.DynamicCode
{
  internal static class Dynamic
  {
    #region Delegates

    public delegate object CallDelegate(object sender, object[] args);

    public delegate object CtorDelegate();

    public delegate object CtorDelegateParam(params object[] @params);

    public delegate object GetDelegate(object sender);

    public delegate void SetDelegate(object sender, object arg);

    #endregion

    #region private misc

    private static void EmitCastToReference(ILGenerator il, Type type)
    {
      il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
    }

    private static DynamicMethod CreateGetDynamicMethod(Type type)
    {
      return new DynamicMethod("___get", typeof (object),
                               new[] {typeof (object)}, type, true);
    }

    private static DynamicMethod CreateSetDynamicMethod(Type type)
    {
      return new DynamicMethod("___set", typeof (void),
                               new[] {typeof (object), typeof (object)}, type, true);
    }

    #endregion

    #region Constructor

    public static CtorDelegateParam Constructor(Type type, params Type[] Params)
    {
      var constructor = type.GetConstructor(ctorFlags, null, Params, null);
      var dynamicMethod = new DynamicMethod("___ctor", constructor.DeclaringType, Params, type);
      var il = dynamicMethod.GetILGenerator();
      var paramCount = constructor.GetParameters().Length;
      il.Emit(OpCodes.Ldarg_0);
      for (var i = 0; i < paramCount; i++)
      {
        il.Emit(OpCodes.Ldarg_S, i + 1);
      }
      //il.Emit(OpCodes.Nop);
      il.Emit(OpCodes.Newobj, constructor);
      il.Emit(OpCodes.Ret);
      return (CtorDelegateParam) dynamicMethod.CreateDelegate(typeof (CtorDelegateParam));
    }

    public static CtorDelegate Constructor(Type type)
    {
      if (type == null)
        throw new ArgumentNullException("type");
      var constructor = type.GetConstructor(ctorFlags, null, new Type[0], null);
      return Constructor(constructor);
    }

    public static CtorDelegate Constructor(ConstructorInfo constructor)
    {
      if (constructor == null)
        throw new ArgumentNullException("constructor");
      var dm = new DynamicMethod("___ctor", constructor.DeclaringType, Type.EmptyTypes, typeof (Dynamic), true);
      var il = dm.GetILGenerator();
      il.Emit(OpCodes.Nop);
      il.Emit(OpCodes.Newobj, constructor);
      il.Emit(OpCodes.Ret);
      return (CtorDelegate) dm.CreateDelegate(typeof (CtorDelegate));
    }

    #endregion

    #region Method

    #region Get Method

    public static MethodInfo GetMethod(Type type, string method, params object[] args)
    {
      return FindMethod(type, method, GetParameterTypes(args));
    }

    public static MethodInfo FindMethod(Type type, string method, Type[] types)
    {
      MethodInfo result = null;
      var currentType = type;
      if (type != null && !string.IsNullOrEmpty(method))
      {
        do
        {
          result = currentType.GetMethod(method, oneLevelFlags, null, types, null);
          if (result != null) break;
          currentType = currentType.BaseType;
        } while (currentType != null);

        if (result == null)
        {
          var paramLength = types == null ? 0 : types.Length;
          result = FindMethod(type, method, paramLength);
          if (result == null)
          {
            try
            {
              result = type.GetMethod(method, allLevelFlags);
            }
            catch (AmbiguousMatchException)
            {
              var methods = type.GetMethods();
              foreach (var m in methods)
              {
                if (m.Name == method && m.GetParameters().Length == paramLength)
                {
                  result = m;
                  break;
                }
              }
              if (result == null)
                throw;
            }
          }
        }
      }
      return result;
    }

    public static MethodInfo FindMethod(Type objectType, string method, int parameterCount)
    {
      MethodInfo result = null;
      try
      {
        var currentType = objectType;
        do
        {
          var info = currentType.GetMethod(method, oneLevelFlags);
          if (info != null)
          {
            var infoParams = info.GetParameters();
            var pCount = infoParams.Length;
            if (pCount > 0 &&
                ((pCount == 1 && infoParams[0].ParameterType.IsArray) ||
                 (infoParams[pCount - 1].GetCustomAttributes(typeof (ParamArrayAttribute), true).Length > 0)))
            {
              if (parameterCount >= pCount - 1)
              {
                result = info;
                break;
              }
            }
            else if (pCount == parameterCount)
            {
              result = info;
              break;
            }
          }
          currentType = currentType.BaseType;
        } while (currentType != null);
      }
      catch
      {
      }
      return result;
    }

    public static Type[] GetParameterTypes(object[] parameters)
    {
      var result = new List<Type>();
      if (parameters == null)
      {
        result.Add(typeof (object));
      }
      else
      {
        foreach (var item in parameters)
        {
          result.Add(item == null ? typeof (object) : item.GetType());
        }
      }
      return result.ToArray();
    }

    #endregion

    public static CallDelegate Method(object sender, string method, Type[] types)
    {
      return Method(sender.GetType(), method, types);
    }

    public static CallDelegate Method(Type type, string method, Type[] types)
    {
      return Method(FindMethod(type, method, types));
    }

    public static CallDelegate Method(MethodInfo method)
    {
      var pi = method.GetParameters();
      var dm = new DynamicMethod("___dm" + method.Name, typeof (object),
                                 new[] {typeof (object), typeof (object[])},
                                 typeof (Dynamic), true);

      var il = dm.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);
      for (var index = 0; index < pi.Length; index++)
      {
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldc_I4, index);

        var parameterType = pi[index].ParameterType;
        if (parameterType.IsByRef)
        {
          parameterType = parameterType.GetElementType();
          if (parameterType.IsValueType)
          {
            il.Emit(OpCodes.Ldelem_Ref);
            il.Emit(OpCodes.Unbox, parameterType);
          }
          else
          {
            il.Emit(OpCodes.Ldelema, parameterType);
          }
        }
        else
        {
          il.Emit(OpCodes.Ldelem_Ref);

          if (parameterType.IsValueType)
          {
            il.Emit(OpCodes.Unbox, parameterType);
            il.Emit(OpCodes.Ldobj, parameterType);
          }
        }
      }
      if ((method.IsAbstract || method.IsVirtual)
          && !method.IsFinal && !method.DeclaringType.IsSealed)
      {
        il.Emit(OpCodes.Callvirt, method);
      }
      else
      {
        il.Emit(OpCodes.Call, method);
      }

      if (method.ReturnType == typeof (void))
      {
        il.Emit(OpCodes.Ldnull);
      }
      else if (method.ReturnType.IsValueType)
      {
        il.Emit(OpCodes.Box, method.ReturnType);
      }
      il.Emit(OpCodes.Ret);

      return (CallDelegate) dm.CreateDelegate(typeof (CallDelegate));
    }

    #endregion

    #region Get

    public static GetDelegate Get(Type type, string member)
    {
      var mi = type.GetMember(member, allLevelFlags);
      if (mi.Length > 0)
      {
        foreach (var info in mi)
        {
          if (info.Name == member)
            return Get(info);
        }
      }
      return null;
    }

    public static GetDelegate Get(MemberInfo memberInfo)
    {
      switch (memberInfo.MemberType)
      {
        case MemberTypes.Field:
          return FieldGet((FieldInfo) memberInfo);
        case MemberTypes.Property:
          return PropertyGet((PropertyInfo) memberInfo);
      }
      return null;
    }

    public static GetDelegate PropertyGet(Type type, string property)
    {
      return PropertyGet(type.GetProperty(property, allLevelFlags));
    }

    public static GetDelegate PropertyGet(PropertyInfo property)
    {
      if (property == null)
        throw new ArgumentNullException("property");

      if (!property.CanRead) return null;
      var getMethod = property.GetGetMethod() ?? property.GetGetMethod(true);
      if (ReferenceEquals(getMethod, null)) return null;

      var dm = CreateGetDynamicMethod(property.DeclaringType);

      var il = dm.GetILGenerator();
      if (!getMethod.IsStatic)
      {
        il.Emit(OpCodes.Ldarg_0);
        il.EmitCall(OpCodes.Callvirt, getMethod, null);
      }
      else
      {
        il.EmitCall(OpCodes.Call, getMethod, null);
      }
      if (property.PropertyType.IsValueType)
        il.Emit(OpCodes.Box, property.PropertyType);
      il.Emit(OpCodes.Ret);

      return (GetDelegate) dm.CreateDelegate(typeof (GetDelegate));
    }

    public static GetDelegate FieldGet(Type type, string field)
    {
      return FieldGet(type.GetField(field, allLevelFlags));
    }

    public static GetDelegate FieldGet(FieldInfo field)
    {
      if (field == null)
        throw new ArgumentNullException("field");

      var dm = CreateGetDynamicMethod(field.DeclaringType);
      var il = dm.GetILGenerator();
      if (!field.IsStatic)
      {
        il.Emit(OpCodes.Ldarg_0);
        EmitCastToReference(il, field.DeclaringType); 
        il.Emit(OpCodes.Ldfld, field);
      }
      else
      {
        il.Emit(OpCodes.Ldsfld, field);
      }
      if (field.FieldType.IsValueType)
        il.Emit(OpCodes.Box, field.FieldType);
      il.Emit(OpCodes.Ret);
      return (GetDelegate) dm.CreateDelegate(typeof (GetDelegate));
    }

    #endregion

    #region Set

    public static SetDelegate Set(Type type, string member)
    {
      var mi = type.GetMember(member, allLevelFlags);
      return mi.Length > 0 ? Set(mi[0]) : null;
    }

    public static SetDelegate Set(MemberInfo memberInfo)
    {
      switch (memberInfo.MemberType)
      {
        case MemberTypes.Field:
          return FieldSet((FieldInfo) memberInfo);
        case MemberTypes.Property:
          return PropertySet((PropertyInfo) memberInfo);
      }
      return null;
    }

    public static SetDelegate PropertySet(Type type, string property)
    {
      return PropertySet(type.GetProperty(property, allLevelFlags));
    }

    public static SetDelegate PropertySet(PropertyInfo property)
    {
      if (property == null)
        throw new ArgumentNullException("property");

      if (!property.CanWrite) return null;
      var setMethod = property.GetSetMethod() ?? property.GetSetMethod(true);
      if (ReferenceEquals(setMethod, null)) return null;

      var dm = CreateSetDynamicMethod(property.DeclaringType);
      var il = dm.GetILGenerator();
      if (!setMethod.IsStatic)
      {
        il.Emit(OpCodes.Ldarg_0);
      }
      il.Emit(OpCodes.Ldarg_1);
      EmitCastToReference(il, property.PropertyType);
      if (!setMethod.IsStatic && !property.DeclaringType.IsValueType)
      {
        il.EmitCall(OpCodes.Callvirt, setMethod, null);
      }
      else
      {
        il.EmitCall(OpCodes.Call, setMethod, null);
      }
      il.Emit(OpCodes.Ret);
      return (SetDelegate) dm.CreateDelegate(typeof (SetDelegate));
    }

    public static SetDelegate FieldSet(Type type, string field)
    {
      return FieldSet(type.GetField(field, allLevelFlags));
    }

    public static SetDelegate FieldSet(FieldInfo field)
    {
      if (field == null)
        throw new ArgumentNullException("field");
      var dm = CreateSetDynamicMethod(field.DeclaringType);
      var il = dm.GetILGenerator();
      if (!field.IsStatic)
      {
        il.Emit(OpCodes.Ldarg_0);
      }
      il.Emit(OpCodes.Ldarg_1);
      EmitCastToReference(il, field.FieldType);
      il.Emit(!field.IsStatic ? OpCodes.Stfld : OpCodes.Stsfld, field);
      il.Emit(OpCodes.Ret);
      return (SetDelegate) dm.CreateDelegate(typeof (SetDelegate));
    }

    #endregion

    private const BindingFlags allLevelFlags =
      BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private const BindingFlags oneLevelFlags =
      BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private const BindingFlags ctorFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
  }
}