using System.Collections.Specialized;
using System.Reflection;
using DiaryOfTrader.Core.DynamicCode;
using Exchange.Core.DynamicCode;

namespace DiaryOfTrader.Core.Core
{
  [AttributeUsage(AttributeTargets.Field)]
  public sealed class NotPersistentAttribute : Attribute
  {
  }

  [Serializable]
  public abstract class Persistent : Disposable
  {
    #region private field
    [NotPersistent]
    [NonSerialized]
    private static readonly Dictionary<Type, List<DynamicInfo>> persistentFields =   new Dictionary<Type, List<DynamicInfo>>();
    [NotPersistent]
    //[NonSerialized]
    private readonly Stack<byte[]> stateStack = new Stack<byte[]>();

    private const BindingFlags bindingFlags =
      BindingFlags.NonPublic |
      BindingFlags.Instance |
      BindingFlags.Public;

    #endregion
    #region private static

    private static string Key(string typeName, string memberName)
    {
      return typeName + "." + memberName;
    }

    private static List<DynamicInfo> GetPersistentField(Type type)
    {
      List<DynamicInfo> result;
      if (!persistentFields.TryGetValue(type, out result))
      {
        lock (persistentFields)
        {
          if (!persistentFields.TryGetValue(type, out result))
          {
            result = new List<DynamicInfo>();
            var fields = type.GetFields(bindingFlags);
            foreach (var field in fields)
            {
              if (field.DeclaringType == type)
              {
                if (!Attribute.IsDefined(field, typeof (NotPersistentAttribute)))
                  result.Add(new DynamicInfo(field));
              }
            }
            persistentFields.Add(type, result);
          }
        }
      }
      return result;
    }

    #endregion

    protected virtual void SaveState()
    {
      var state = new HybridDictionary();
      try
      {
        var currentType = GetType();
        do
        {
          var currentTypeName = currentType.FullName;
          foreach (var info in GetPersistentField(currentType))
          {
            var key = Key(currentTypeName, info.Info.Name);
            var value = info.Get(this);
            if (typeof (Persistent).IsAssignableFrom(info.InfoType))
            {
              if (value == null)
              {
                state.Add(key, null);
              }
              else
              {
                ((Persistent) value).SaveState();
              }
            }
            else
            {
              state.Add(key, value);
            }
          }
          currentType = currentType.BaseType;
        } while (currentType != typeof (Persistent));
        using (var buffer = new MemoryStream())
        {
          var formatter = SerializationFormatterFactory.GetFormatter();
          formatter.Serialize(buffer, state);
          stateStack.Push(buffer.ToArray());
        }
      }
      catch (Exception e)
      {
        throw;
      }
    }

    protected virtual void AcceptChanges()
    {
      try
      {
        stateStack.Pop();
        var currentType = GetType();
        do
        {
          foreach (var info in GetPersistentField(currentType))
          {
            if (typeof(Persistent).IsAssignableFrom(info.InfoType))
            {
              var value = info.Get(this);
              if (value != null)
              {
                ((Persistent)value).AcceptChanges();
              }
            }
          }
          currentType = currentType.BaseType;
        } while (currentType != typeof(Persistent));
      }
      catch (Exception e)
      {
        //LogManager.Log.Error("AcceptChanges()", e);
        throw;
      }
    }

    protected virtual void UndoChanges()
    {
      try
      {
        HybridDictionary state;
        using (var buffer = new MemoryStream(stateStack.Pop()))
        {
          buffer.Position = 0;
          var formatter = SerializationFormatterFactory.GetFormatter();
          state = (HybridDictionary)formatter.Deserialize(buffer);
        }

        var currentType = GetType();
        do
        {
          var currentTypeName = currentType.FullName;
          foreach (var info in GetPersistentField(currentType))
          {
            var value = info.Get(this);
            var key = Key(currentTypeName, info.Info.Name);
            if (typeof(Persistent).IsAssignableFrom(info.InfoType))
            {
              if (state.Contains(key))
              {
                info.Set(this, null);
              }
              else
              {
                if (value != null)
                {
                  ((Persistent)value).UndoChanges();
                }
              }
            }
            else
            {
              info.Set(this, state[key]);
            }
          }
          currentType = currentType.BaseType;
        } while (currentType != typeof(Persistent));
      }
      catch (Exception e)
      {
        //LogManager.Log.Error("UndoChanges()", e);
        throw;
      }
    }

    protected override void Free()
    {
      base.Free();
      var currentType = GetType();
      do
      {
        foreach (var info in GetPersistentField(currentType))
        {
          if (typeof(Persistent).IsAssignableFrom(info.InfoType))
          {
            var value = info.Get(this);
            if (value != null)
            {
              ((Persistent)value).Dispose();
            }
          }
        }
        currentType = currentType.BaseType;
      } while (currentType != typeof(Persistent));
      stateStack.Clear();
    }
  }
}
