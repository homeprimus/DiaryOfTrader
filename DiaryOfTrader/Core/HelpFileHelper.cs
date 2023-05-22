using System.IO;

namespace Exchange.Core
{

  internal class HelpFileHelper
  {
    private static string helpFile = string.Empty;

    private static readonly Dictionary<Type, string> helpDictionary =
      new Dictionary<Type, string>();

    private static bool HelpFileExists(string path, out string resultHelpFile)
    {
      resultHelpFile = string.Empty;
      var lpchHelp = Path.Combine(path, "");
      var result = File.Exists(lpchHelp);
      if (result)
      {
        resultHelpFile = lpchHelp;
      }
      return result;
    }

    private static string GetHelpFile()
    {
      lock (helpFile)
      {
        if (string.IsNullOrEmpty(helpFile))
        {
          try
          {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            while 
              (
              !string.IsNullOrEmpty(path) && 
              !(
              HelpFileExists(path, out helpFile) ||
              HelpFileExists(Path.Combine(path, "Help"), out helpFile))
              )
            {
              path = Path.GetDirectoryName(path) ?? string.Empty;
            }
          }
          catch (Exception exception)
          {
            helpFile = string.Empty;
          }
        }
      }
      return helpFile;
    }
    internal static bool ShowHelp(string helpTopic)
    {
      var result = false;
      var lpchHelpFile = GetHelpFile();
      if (!string.IsNullOrEmpty(helpTopic) && !string.IsNullOrEmpty(lpchHelpFile))
      {
        try
        {

          Help.ShowHelp(Form.ActiveForm, lpchHelpFile, HelpNavigator.TopicId, helpTopic);
          result = true;
        }
        catch (Exception exception)
        {
        }
      }
      return result;
    }
    internal static string GetHelpTopic(object forHelp)
    {
      if (!helpDictionary.TryGetValue(forHelp.GetType(), out var result))
        result = string.Empty;
      return result;
    }
  }
}
