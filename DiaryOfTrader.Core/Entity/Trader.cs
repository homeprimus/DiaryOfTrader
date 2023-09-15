
namespace DiaryOfTrader.Core.Entity 
{
  [Serializable]
  public class Trader: Entity
  {
    #region
    private string _password;
    private string _email;
    #endregion
    public string Password
    {
      get { return _password; }
      set
      {
        if (_password != value)
        {
          _password = value;
          OnPropertyChanged();
        }
      }
    }
    public string Email
    {
      get { return _email; }
      set
      {
        if (_email != value)
        {
          _email = value;
          OnPropertyChanged();
        }
      }
    }
  }
}
