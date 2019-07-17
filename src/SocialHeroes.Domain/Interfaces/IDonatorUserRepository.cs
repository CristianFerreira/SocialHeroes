using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserRepository : IRepository<DonatorUser>
    {
        DonatorUser GetByUserId(Guid userId);
        ICollection<DonatorUserBloodToNotifyQuery> GetToBloodNotification(Guid bloodId, int amount);
        ICollection<DonatorUserHairToNotifyQuery> GetToHairNotification(Guid hairId, int amount);
        ICollection<DonatorUserToNotifyQuery> GetToBreastMilkNotification(int amount);
    }
}
