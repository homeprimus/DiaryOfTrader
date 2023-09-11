namespace DiaryOfTrader.Core.Auth;

public class ResponseDto
{
  public bool IsSuccessfulRegistration { get; set; }
  public IEnumerable<string>? Errors { get; set; }
}
