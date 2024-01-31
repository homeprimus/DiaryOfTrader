using System.Data.Common;

namespace DiaryOfTrader.Core.Data
{
  public class DatabaseManagerOptions
  {
    public Dictionary<string, DbConnectionStringBuilder> Options { get; set; }
  }
}
