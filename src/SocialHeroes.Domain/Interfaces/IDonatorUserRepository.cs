using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserRepository : IRepository<DonatorUser>
    {
        DonatorUser GetByUserId(Guid userId);
        ICollection<DonatorUserToNotifyQuery> GetToBloodNotification(Guid bloodId);
        ICollection<DonatorUserToNotifyQuery> GetToHairNotification(Guid hairId);
        ICollection<DonatorUserToNotifyQuery> GetToBreastMilkNotification(int amount);
    }
}
