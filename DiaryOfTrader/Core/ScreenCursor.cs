
namespace DiaryOfTrader.Core
{
  public static class ScreenCursor
  {
    private static Stack<Cursor> set = new ();

    public static void Set(Cursor cursor)
    {
      set.Push(Cursor.Current);
      Cursor.Current = cursor;
    }

    public static void Unset()
    {
      if (set.Count > 0)
      {
        Cursor.Current = set.Pop();
      }
    }

    public static void Reset()
    {
      set.Clear();
      Cursor.Current = Cursors.Default;
    }

    public static void WaitCursor()
    {
      Set(Cursors.WaitCursor);
    }
    public static void Hand()
    {
      Set(Cursors.Hand);
    }
    public static void AppStarting()
    {
      Set(Cursors.AppStarting);
    }
    public static void Help()
    {
      Set(Cursors.Help);
    }

  }
}
