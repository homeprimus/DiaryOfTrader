using DiaryOfTrader.Core.Auth;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderRepositoryApi : RepositoryApi<Trader>, ITraderRepository
  {
    public TraderRepositoryApi(string root) : base(root)
    {
    }

    public Task<Trader> Search(string user, string password)
    {
      throw new NotImplementedException();
    }

    public async Task<ResponseDto> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
      throw new NotImplementedException();
      // return await _client.PostAsJsonAsync<UserForRegistrationDto>($"{_endPoint}", userForRegistrationDto);
    }
  }
}
