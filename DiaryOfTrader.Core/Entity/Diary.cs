

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
     * Обхор рынка
     */
    public MarketReview Review { get; set; }
    /*
     * Экономические новости
     */
    public List<EconomicSchedule> Events { get; set; }
    /*
     * Торговая сесия
     */
    public TraderSession? Session { get; }
    /*
    * На каом таймфрейме был выполнен вход
    */
    public TimeFrame Entered { get; set; }
    /*
     * Сделка, ход и сопровождение
     */
    public string? Deal { get; }

    /*
     * Чек лист эмиций для начала сделки
     */
    public string? Emotions { get; set; }
    /*
     * Скриншоьы сделки
     */
    public List<ScreenShot>? Screenshot { get; }
    /*
     * Кошелек
     */
    public Wallet Wallet { get; set; }
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
