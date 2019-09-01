using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.Views;
using SocialHeroes.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class BloodNotificationRepository : Repository<BloodNotification>, IBloodNotificationRepository
    {
        public BloodNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }

        public ICollection<VwInfoBloodNotificationsRequestedEnableOnPage> GetAllInfoEnableOnPage()
        => Db.VwInfoBloodNotificationsRequestedEnableOnPage.AsNoTracking().ToList();
        
    }
}
