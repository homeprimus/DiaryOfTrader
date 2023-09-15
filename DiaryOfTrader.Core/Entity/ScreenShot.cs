namespace DiaryOfTrader.Core.Entity
{
  [Serializable]
  public class ScreenShot : EntityPicture
  {
    #region fields
    private string _path;
    #endregion

    public string Path
    {
      get { return _path; }
      set
      {
        if (_path != value)
        {
          _path = value;
          OnPropertyChanged();
        }
      }
    }
  }
}
