using DiaryOfTrader.Core.Auth;
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRepositoryDb : RepositoryDb<Trader>, ITraderRepository
  {
    public TraderRepositoryDb(DbContext data) : base(data)
    {
    }
    public async Task<Trader> Search(string user, string password)
    {
      return await Entity.Where(e => e.Name == user && e.Password == password).FirstOrDefaultAsync();
    }

    public async Task<ResponseDto> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
      if (Entity.Any(x => x.Email == userForRegistrationDto.Email))
      {
        return new ResponseDto
        {
          IsSuccessfulRegistration = false,
          Errors = new List<string> {"User already exists"}
        };
      }
      await Entity.AddAsync(new Trader
      {
        Email = userForRegistrationDto.Email,
        Password = userForRegistrationDto.Password
      });
      await Data.SaveChangesAsync();
      return new ResponseDto(){IsSuccessfulRegistration = true};
    }
  }
}
