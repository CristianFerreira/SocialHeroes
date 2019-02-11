using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
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

        public ICollection<DonatorUserToNotifyQuery> GetToBloodNotification(Guid bloodId) { return null; }
        //=> DbSet.AsNoTracking()
        //        .Where(x => x.BloodId == bloodId && x.ActivedBloodNotification == true)
        //        .Include(x => x.Blood)
        //        .Include(x => x.User)
        //        .ToList();

        public ICollection<DonatorUserToNotifyQuery> GetToBreastMilkNotification(int amount)
        => (from d in Db.DonatorUsers
            join u in Db.Users on d.UserId equals u.Id
            join un in Db.UserNotificationType on u.Id equals un.UserId
            join n in Db.NotificationType on un.NotificationTypeId equals n.Id
            where d.ActivedBreastMilkNotification == true
                  && (d.LastBreastMilkNotification < DateTime.Now.AddDays(-7) || d.LastBreastMilkNotification == null)
            group d.Id by new { d, u } into mygroup
            select new DonatorUserToNotifyQuery
            {
                Name = mygroup.Key.d.Name,
                Email = mygroup.Key.u.Email,
                DonatorUserId = mygroup.Key.d.Id,
                UserId = mygroup.Key.u.Id
            })
            .ToList();

        public ICollection<DonatorUserToNotifyQuery> GetToHairNotification(Guid hairId) { return null; }
        //=> DbSet.AsNoTracking()
        //        .Where(x => x.HairId == hairId && x.ActivedHairNotification == true)
        //        .Include(x => x.Hair)
        //        .Include(x => x.User)
        //        .ToList();
    }
}
