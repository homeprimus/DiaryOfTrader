using DiaryOfTrader.Core.Entity;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository.Interfaces;

public interface ITimeFrameHttpRepository
{
  Task<List<TimeFrame>?> GetTimeFrame();
  Task<TimeFrame?> GetTimeFrame(long id);
  Task CreateTimeFrame(TimeFrame timeFrame);
  Task UpdateTimeFrame(TimeFrame timeFrame);
  Task DeleteTimeFrame(long id);
}
