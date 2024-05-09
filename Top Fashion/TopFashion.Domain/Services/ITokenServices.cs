using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Domain.Services
{
    public interface ITokenServices
    {
        string CreateToken(AppUser appUser);
    }
}
