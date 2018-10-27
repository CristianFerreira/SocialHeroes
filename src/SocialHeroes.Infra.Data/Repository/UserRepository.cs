using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Enums;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SocialHeroesContext context) : base(context) {}

        public User GetByUserType(EUserType userType) 
            => DbSet.AsNoTracking().FirstOrDefault(u => u.UserType == userType);
        
    }
}
