using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using SocialHeroes.Domain.Queries.Views;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class BloodNotificationRepository : Repository<BloodNotification>, IBloodNotificationRepository
    {
        public BloodNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }

        public VwBloodNotificationsRequestedEnableOnPage GetEnableOnPageByNotificationId(Guid notificationId)
        => Db.VwBloodNotificationsRequestedEnableOnPage.AsNoTracking().ToList().FirstOrDefault(x=>x.NotificationId.Equals(notificationId));
        

        public ICollection<VwInfoBloodNotificationsRequestedEnableOnPage> GetAllInfoEnableOnPage()
        => Db.VwInfoBloodNotificationsRequestedEnableOnPage.AsNoTracking().OrderBy(x=>x.DateNotification).ToList();
        
    }
}
