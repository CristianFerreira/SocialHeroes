using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class UserNotificationTypeRepository : Repository<UserNotificationType>, IUserNotificationTypeRepository
    {
        public UserNotificationTypeRepository(SocialHeroesContext context) : base(context)
        {
        }
    }
}
