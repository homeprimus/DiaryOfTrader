using System.Runtime.InteropServices;
using System.Text;

namespace DiaryOfTrader.Core.Utils
{
  public class IniFileHelper
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    static extern uint GetPrivateProfileString(
    string lpAppName,
    string lpKeyName,
    string lpDefault,
    StringBuilder lpReturnedString,
    uint nSize,
    string lpFileName);

    private readonly string ffile = string.Empty;

    public IniFileHelper(string file)
    {
      ffile = file;
    }

    public string FileName{ get { return ffile; }}
    public string ReadString(string section, string indent, string dafault)
    {
      var sb = new StringBuilder(2047);
      GetPrivateProfileString(section, indent, dafault, sb, (uint)sb.Capacity, ffile);
      return sb.ToString();
    }

    public bool ReadBool(string section, string indent, bool dafault)
    {
      var result = ReadString(section, indent, dafault.ToString()).ToLowerInvariant();
      if (!string.IsNullOrEmpty(result))
      {
        return dafault;
      }
      if (result.Equals(false.ToString().ToLowerInvariant()))
      {
        return false;
      }

      if (!long.TryParse(result, out var value))
      {
        value = 0;
      }
      return value > 0;
    }

    public int ReadInt(string section, string indent, int dafault)
    {
      var result = ReadString(section, indent, dafault.ToString());
      if (!int.TryParse(result, out var value))
      {
        value = 0;
      }
      return value;
    }
  }
}
