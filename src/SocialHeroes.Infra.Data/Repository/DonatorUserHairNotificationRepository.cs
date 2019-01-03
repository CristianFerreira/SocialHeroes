using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserHairNotificationRepository : Repository<DonatorUserHairNotification>,
                                                         IDonatorUserHairNotificationRepository
    {
        public DonatorUserHairNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
