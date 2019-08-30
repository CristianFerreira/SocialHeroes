using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
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

        public ICollection<NotificationType> GetByUserId(Guid userId)
           => (from nt in Db.NotificationTypes
               join untft in Db.UserNotificationTypes on nt.Id equals untft.NotificationTypeId
               where untft.UserId == userId
               select new NotificationType (nt.Id, nt.Name,nt.Description)
               ).ToList();
    }
}
