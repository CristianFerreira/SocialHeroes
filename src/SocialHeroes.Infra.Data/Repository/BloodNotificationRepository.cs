using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class BloodNotificationRepository : Repository<BloodNotification>, IBloodNotificationRepository
    {
        public BloodNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
