using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IHairNotificationRepository : IRepository<HairNotification>
    {
        ICollection<VwInfoHairNotificationsRequestedEnableOnPage> GetAllInfoEnableOnPage();
        VwHairNotificationsRequestedEnableOnPage GetEnableOnPageByNotificationId(Guid notificationId);
    }
}
