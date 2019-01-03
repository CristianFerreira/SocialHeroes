using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class HairNotificationRepository : Repository<HairNotification>, IHairNotificationRepository
    {
        public HairNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
