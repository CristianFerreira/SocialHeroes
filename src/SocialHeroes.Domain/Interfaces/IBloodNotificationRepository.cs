using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using SocialHeroes.Domain.Queries.Views;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IBloodNotificationRepository : IRepository<BloodNotification>
    {
        ICollection<VwInfoBloodNotificationsRequestedEnableOnPage> GetAllInfoEnableOnPage();
        VwBloodNotificationsRequestedEnableOnPage GetEnableOnPageByNotificationId(Guid notificationId);
    }
}
