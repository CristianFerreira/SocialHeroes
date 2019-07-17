using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class BloodRepository : Repository<Blood>, IBloodRepository
    {
        public BloodRepository(SocialHeroesContext context)
            : base(context)
        {

        }
    }
}
