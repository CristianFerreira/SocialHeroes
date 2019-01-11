using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserRepository : Repository<DonatorUser>, IDonatorUserRepository
    {
        public DonatorUserRepository(SocialHeroesContext context) : base(context)
        {
        }

        public DonatorUser GetByUserId(Guid userId)
            => DbSet.AsNoTracking().FirstOrDefault(x => x.UserId == userId);

        public ICollection<DonatorUser> GetToBloodNotification(Guid bloodId)
            => DbSet.AsNoTracking()
                    .Where(x => x.BloodId == bloodId && x.ActivedBloodNotification == true)
                    .Include(x => x.Blood)
                    .Include(x => x.User)
                    .ToList();

        public ICollection<DonatorUser> GetToBreastMilkNotification(int amount)
            => DbSet.AsNoTracking()
                    .Where(x => x.ActivedBreastMilkNotification == true
                           && x.User.UserNotificationTypes.Select(n => n.NotificationType.Name).Equals("Leite materno"))
                    .Include(x => x.User)
                    .ThenInclude(x => x.UserNotificationTypes)
                    .ThenInclude(x => x.Select(n => n.NotificationType))
                    .Take(amount)
                    .ToList();

    //    (ICollection<DonatorUser>) (from d in Db.DonatorUsers
    //            join u in Db.Users on d.UserId equals u.Id
    //            join un in Db.UserNotificationType on u.Id equals un.UserId
    //            join n in Db.NotificationType on un.NotificationTypeId equals n.Id
    //            select new { d, d.User = u
    //}).ToList();

    public ICollection<DonatorUser> GetToHairNotification(Guid hairId)
            => DbSet.AsNoTracking()
                    .Where(x => x.HairId == hairId && x.ActivedHairNotification == true)
                    .Include(x => x.Hair)
                    .Include(x => x.User)
                    .ToList();
    }
}
