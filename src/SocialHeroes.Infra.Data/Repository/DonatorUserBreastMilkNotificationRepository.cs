using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserBreastMilkNotificationRepository : Repository<DonatorUserBreastMilkNotification>,
                                                               IDonatorUserBreastMilkNotificationRepository
    {
        public DonatorUserBreastMilkNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
