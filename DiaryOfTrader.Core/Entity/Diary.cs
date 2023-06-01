
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
    public TraderExchange? Exchange { get; set; }
    /*
     * Чем торговали
     */
    public Symbol Symbol { get; set; }
    /*
     * На каом таймфрейме был выполнен вход
     */
    public TimeFrame Entered { get; set; }
    /*
     * Месячного ТФ
     */
    public Trend? Trend { get; set; }
    /*
     * Дневной ТФ
     */
    public string Monthly { get; set; }

    public string Daily { get; set; }
    /*
     * Торговая сесия
     */
    public TraderSession? Session { get; }
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
    public TraderResult TraderResult { get; set; }
    /*
     * Сумма профита или убытка
     */
    public decimal Amount { get; set; }
  }

}
