using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserType(EUserType userType);
        User GetByEmail(string email);
    }
}
