
namespace DiaryOfTrader.Core.Core
{
  public class SynchronizationElement
  {
    private static readonly int mainThreadId = Thread.CurrentThread.ManagedThreadId;

    public static SynchronizationContext? Context { get; } = SynchronizationContext.Current;
    public static bool IsMainThread => mainThreadId == Thread.CurrentThread.ManagedThreadId;
    
  }
}
