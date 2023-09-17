
namespace DiaryOfTrader.Core.Entity
{
  /*
   *Регион Город Открытие Закрытие
Токио 2:00 10:00
Гонконг 3:00 11:00

Франкфурт 8:00 16:00
Лондон 9:00 17:00

Нью-Йорк 15:00 23:00
Чикаго 16:00 24:00

Веллингтон 22:00 06:00
Сидней 22:00 06:00

https://alfaforex.ru/faq/internet-treyding/vremya-raboty-rynka-forex-raspisanie-torgovykh-sessiy/
   */
  [Serializable]
  public class TraderSession : Entity
  {
    #region fields
    private DateTime _winterStarting;
    private DateTime _winterFinished;
    private DateTime _summerStarting;
    private DateTime _summerFinished;
    #endregion
    [JsonIgnore]
    public TraderRegion Region { get; set; }

    public DateTime WinterStarting
    {
      get { return _winterStarting;}
      set
      {
        if (_winterStarting != value)
        {
          _winterStarting = value;
          OnPropertyChanged();
        }
      }
    }
    public DateTime WinterFinished
    {
    get { return _winterFinished; }
    set
    {
      if (_winterFinished != value)
      {

        _winterFinished = value;
        OnPropertyChanged();
      }
    }
    }
    public DateTime SummerStarting
    {
      get { return _summerStarting;}
      set
      {
        if (_summerStarting != value)
        {
          _summerStarting = value;
          OnPropertyChanged();
        }
      }
    }
    public DateTime SummerFinished
    {
      get { return _summerFinished;}
      set
      {
        if (_summerFinished != value)
        {
          _summerFinished = value;
          OnPropertyChanged();
        }
      }
    }
  }

}
