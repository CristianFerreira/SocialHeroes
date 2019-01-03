using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserBloodNotificationRepository : Repository<DonatorUserBloodNotification>, IDonatorUserBloodNotificationRepository
    {
        public DonatorUserBloodNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
