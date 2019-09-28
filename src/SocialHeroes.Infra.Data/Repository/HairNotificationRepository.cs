using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class HairNotificationRepository : Repository<HairNotification>, IHairNotificationRepository
    {
        public HairNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }

        public VwHairNotificationsRequestedEnableOnPage GetEnableOnPageByNotificationId(Guid notificationId)
        => Db.VwHairNotificationsRequestedEnableOnPage.AsNoTracking().ToList().FirstOrDefault(x => x.NotificationId.Equals(notificationId));


        public ICollection<VwInfoHairNotificationsRequestedEnableOnPage> GetAllInfoEnableOnPage()
        => Db.VwInfoHairNotificationsRequestedEnableOnPage.AsNoTracking().OrderByDescending(x => x.DateNotification).ToList();
    }
}
