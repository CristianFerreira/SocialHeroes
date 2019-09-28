using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class SocialNotificationTypeRepository : Repository<SocialNotificationType>, ISocialNotificationTypeRepository
    {
        public SocialNotificationTypeRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
