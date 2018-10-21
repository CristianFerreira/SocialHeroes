using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class HairRepository : Repository<Hair>, IHairRepository
    {
        public HairRepository(SocialHeroesContext context)
            : base(context)
        {

        }    
    }
}
