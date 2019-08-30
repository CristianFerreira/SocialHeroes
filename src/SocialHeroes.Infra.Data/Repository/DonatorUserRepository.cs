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

        public ICollection<DonatorUserBloodToNotifyQuery> GetToBloodNotification(Guid bloodId, int amount)
             => (from d in Db.DonatorUsers
                 join b in Db.Bloods on d.BloodId equals b.Id
                 join u in Db.Users on d.UserId equals u.Id
                 join un in Db.UserNotificationTypes on u.Id equals un.UserId
                 join n in Db.NotificationTypes on un.NotificationTypeId equals n.Id
                 where d.ActivedBloodNotification == true
                       && (d.LastBloodNotification < DateTime.Now.AddDays(-7) || d.LastBloodNotification == null)
                       && d.BloodId == bloodId
                 group d.Id by new { d, u, b } into mygroup
                 select new DonatorUserBloodToNotifyQuery
                 {
                     Name = mygroup.Key.d.Name,
                     Email = mygroup.Key.u.Email,
                     DonatorUserId = mygroup.Key.d.Id,
                     UserId = mygroup.Key.u.Id,
                     Type = mygroup.Key.b.Type
                 })
                .Take(amount)
                .ToList();


        public ICollection<DonatorUserToNotifyQuery> GetToBreastMilkNotification(int amount)
        => (from d in Db.DonatorUsers
            join u in Db.Users on d.UserId equals u.Id
            join un in Db.UserNotificationTypes on u.Id equals un.UserId
            join n in Db.NotificationTypes on un.NotificationTypeId equals n.Id
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
            .Take(amount)
            .ToList();

        public ICollection<DonatorUserHairToNotifyQuery> GetToHairNotification(Guid hairId, int amount) 
        => (from d in Db.DonatorUsers
            join h in Db.Hairs on d.HairId equals h.Id
            join u in Db.Users on d.UserId equals u.Id
            join un in Db.UserNotificationTypes on u.Id equals un.UserId
            join n in Db.NotificationTypes on un.NotificationTypeId equals n.Id
            where d.ActivedHairNotification == true
                  && (d.LastHairNotification < DateTime.Now.AddDays(-7) || d.LastHairNotification == null)
                  && d.HairId == hairId
            group d.Id by new { d, h, u } into mygroup
            select new DonatorUserHairToNotifyQuery
            {
                Name = mygroup.Key.d.Name,
                Email = mygroup.Key.u.Email,
                DonatorUserId = mygroup.Key.d.Id,
                UserId = mygroup.Key.u.Id,
                Color = mygroup.Key.h.Color,
                Type = mygroup.Key.h.Type
            })
            .Take(amount)
            .ToList();
    }
}
