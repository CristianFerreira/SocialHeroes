using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class NotificationTypeRepository : Repository<NotificationType>, INotificationTypeRepository
    {
        public NotificationTypeRepository(SocialHeroesContext context) : base(context)
        {
        }

        public NotificationType GetByName(string name)
        => DbSet.AsNoTracking().FirstOrDefault(n => n.Name.ToUpper() == name.ToUpper());
    }
}
