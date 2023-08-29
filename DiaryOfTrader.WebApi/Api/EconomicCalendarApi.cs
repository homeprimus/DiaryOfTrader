
using DiaryOfTrader.Core.Entity.Economic;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiaryOfTrader.WebApi.Api
{
  public class EconomicCalendarApi : IApi
  {
    public void Register(WebApplication application)
    {
      application.MapGet("/calendar", Getcalendar)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Economic calendar")
        .WithTags("Info");
      ;
    }

    [AllowAnonymous]
    private async Task<IResult> Getcalendar(
      IEconomicCalendarRepository repository,
      [FromQuery] DateTime? startDate,
      [FromQuery] DateTime? endDate,
      [FromQuery] EconomicPeriod period,
      [FromQuery] Importance importance,
      HttpContext context)
    {
      IEnumerable<EventCalendar> eventCalendar = null;
      if (startDate != null && endDate != null)
      {
        eventCalendar = await repository.GetAsync(startDate ?? DateTime.MinValue, endDate ?? DateTime.MinValue, period,
          importance);
      }
      else
      {
        eventCalendar = await repository.GetAsync(period, importance);
      }

      return Results.Ok(eventCalendar);
    }
  }
}
