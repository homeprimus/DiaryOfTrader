
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
  public class TraderSession : Entity
  {
    public TraderRegion Region { get; set; }
    //public string City { get; set; } => Name
    public DateTime WinterStarting { get; set; }
    public DateTime WinterFinished { get; set; }
    public DateTime SummerStarting { get; set; }
    public DateTime SummerFinished { get; set; }
  }

}
