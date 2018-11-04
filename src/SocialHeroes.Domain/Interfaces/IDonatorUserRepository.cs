using SocialHeroes.Domain.Models;
using System;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserRepository : IRepository<DonatorUser>
    {
        DonatorUser GetByUserId(Guid userId);
    }
}
