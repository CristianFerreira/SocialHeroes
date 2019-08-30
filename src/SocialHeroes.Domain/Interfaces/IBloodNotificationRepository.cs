using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.Views;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IBloodNotificationRepository : IRepository<BloodNotification>
    {
        ICollection<VwBloodNotificationsRequestedEnableOnPage> GetAllEnableOnPage();
    }
}
