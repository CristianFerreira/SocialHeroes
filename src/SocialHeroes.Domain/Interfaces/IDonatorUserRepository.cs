using SocialHeroes.Domain.Models;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserRepository : IRepository<DonatorUser>
    {
        DonatorUser GetAllUser();
    }
}
