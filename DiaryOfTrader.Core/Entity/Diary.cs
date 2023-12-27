

namespace DiaryOfTrader.Core.Entity
{
  public class Diary : Entity
  {
    #region firlds
    private DateTime _startedDate;
    private DateTime? _finishedDate;
    private TraderExchange _exchange;
    private Symbol _symbol;
    private MarketReview? _review;
    private List<EconomicSchedule>? _events;
    private TraderSession? _session;
    private TimeFrame _entered;
    private string? _deal;
    private string? _emotions;
    private List<ScreenShot>? _screenshot;
    private Wallet _wallet;
    private Trader? _trader;
    private TraderResult _traderResult;
    private decimal _amount;
    #endregion

    public Trader? Trader
    {
      get { return _trader; }
      set
      {
        if(value != _trader)
        {
          _trader = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Дата-время начала сделки
     */
    public DateTime StartedDate
    {
      get { return _startedDate;}
      set
      {
        if (_startedDate != value)
        {
          _startedDate=value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Дата-время окончания сделки
     */
    public DateTime? FinishedDate
    {
      get { return _finishedDate; }
      set
      {
        if (_finishedDate != value)
        {
          _finishedDate = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * На какой бирже торговали
     */

    public TraderExchange? Exchange
    {
      get { return _exchange; }
      set
      {
        if (_exchange != value)
        {
          _exchange = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Чем торговали
     */
    public Symbol Symbol
    {
      get { return _symbol; }
      set
      {
        if (_symbol != value)
        {
          _symbol = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Обхор рынка
     */
    public MarketReview? Review
    {
      get { return _review; }
      set
      {
        if (_review != value)
        {
          _review = value;
          OnPropertyChanged();
        }
      }
    }
    /*
     * Экономические новости
     */
    public List<EconomicSchedule>? Events
    {
      get { return _events; }
      set
      {
        if (_events != value)
        {
          _events = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Торговая сесия
     */
    public TraderSession? Session
    {
      get { return _session; }
      set
      {
        if (_session != value)
        {
          _session = value;
          OnPropertyChanged();
        }
      }
    }

    /*
    * На каом таймфрейме был выполнен вход
    */
    public TimeFrame Entered
    {
      get { return _entered; }
      set
      {
        if (_entered != value)
        {
          _entered = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Сделка, ход и сопровождение
     */
    public string? Deal
    {
      get { return _deal; }
      set
      {
        if (_deal != value)
        {
          _deal = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Чек лист эмиций для начала сделки
     */
    public string? Emotions
    {
      get { return _emotions; }
      set
      {
        if (_emotions != value)
        {
          _emotions = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Скриншоьы сделки
     */
    public List<ScreenShot>? Screenshot
    {
      get { return _screenshot; }
      set
      {
        if (_screenshot != value)
        {
          _screenshot = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Кошелек
     */
    public Wallet Wallet
    {
      get { return _wallet; }
      set
      {
        if (_wallet != value)
        {
          _wallet = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Результат сделки
     */
    public TraderResult TraderResult
    {
      get { return _traderResult; }
      set
      {
        if (_traderResult != value)
        {
          _traderResult = value;
          OnPropertyChanged();
        }
      }
    }

    /*
     * Сумма профита или убытка
     */
    public decimal Amount
    {
      get { return _amount; }
      set
      {
        if (_amount != value)
        {
          _amount = value;
          OnPropertyChanged();
        }
      }
    }

  }

}
