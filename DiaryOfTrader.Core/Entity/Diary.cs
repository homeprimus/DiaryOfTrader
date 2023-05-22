
namespace DiaryOfTrader.Core.Entity
{
  public class Diary: Entity
  {
    /*
     * Дата сделки
     */
    public DateTime Date { get; set; }
    /*
     * На какой бирже торговали
     */
    public Exchange? Exchange { get; set; }
    /*
     * Чем торговали
     */
    public Sumbol Sumbol { get; set; }
    /*
     * На каом таймфрейме был выполнен вход
     */
    public TimeFrame Entered { get; set; }
    /*
     * Месячного ТФ
     */
    public string? Trend { get; set; }
    /*
     * Дневной ТФ
     */
    public string Monthly { get; set; }

    public string Daily { get; set; }
    /*
     * Торговая сесия
     */
    public TradeSession? Session { get; }
    /*
     * Сделка, ход и сопровождение
     */
    public string? Deal { get; }
    /*
     * Эмиции
     */
    public string? Emotions { get; set; }
    /*
     * Скриншоьы сделки
     */
    public List<ScreenShot>? Screenshot { get; }
    /*
     * Результат сделки
     */
    public Result Result { get; set; }
    /*
     * Сумма профита или убытка
     */
    public decimal Amount { get; set; }
  }

}
