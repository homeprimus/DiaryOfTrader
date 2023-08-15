
using System.Collections;
using System.Diagnostics;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Entity.Economic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiaryOfTrader.WebApi.Api
{
  public class EconomicCalendarApi: IApi
  {
    public void Register(WebApplication application)
    {
      application.MapGet("/calendar", [AllowAnonymous]
        async (
          IEconomicCalendarRepository repocitory,
          [FromQuery] DateTime? startDate,
          [FromQuery] DateTime? endDate,
          [FromQuery] EconomicPeriod period,
          [FromQuery] Importance importance,
          HttpContext context) =>
        {
          IEnumerable<EventCalendar> eventCalendar = null;
          //var startDate = context.Request.Query["startdate"];
          //var endDate = context.Request.Query["enddate"];
          try
          {
            //var period = (EconomicPeriod)Enum.Parse(typeof(EconomicPeriod), context.Request.Query["period"], true);
            //var importance = (Importance)Enum.Parse(typeof(Importance), context.Request.Query["importance"], true);
            if (startDate != null && endDate != null)
            {
              eventCalendar = await repocitory.GetAsync(startDate??DateTime.MinValue, endDate?? DateTime.MinValue, period, importance);
            }
            else
            {
              eventCalendar = await repocitory.GetAsync(period, importance);
            }
          }
          catch (Exception e)
          {
            Debug.WriteLine(e);
            Results.NotFound(Array.Empty<IEnumerable<EventCalendar>>());
          }
          return Results.Ok(eventCalendar);
        }
      )
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent)
        .WithName($"Economic calendar")
        .WithTags("Info");
        ;
    }
  }
}
