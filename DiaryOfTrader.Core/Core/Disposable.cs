using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DiaryOfTrader.Core.Core
{
  [Serializable]
  public abstract class Disposable : MarshalByRefObject, IDisposable
  {
    #region public const
    public const string Empty = "";
    #endregion

    protected bool Disposed { get; private set; }   
    private readonly object syncRoot = new object();

    protected virtual object GetSyncRoot()
    {
      return syncRoot;
    }

    [JsonIgnore, Browsable(false)]
    public object SyncRoot
    {
      get { return GetSyncRoot(); }
    }

    protected virtual void Free()
    {
    }

    #region IDisposable Support

    ~Disposable()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (!Disposed)
        {
          lock (SyncRoot)
          {
            if (!Disposed)
            {
              Free();
              Disposed = true;
            }
          }
        }
      }
    }
    #endregion
  }
}
