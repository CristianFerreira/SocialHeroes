using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserRepository : IRepository<DonatorUser>
    {
        DonatorUser GetByUserId(Guid userId);
        ICollection<DonatorUser> GetToBloodNotification(Guid bloodId);
        ICollection<DonatorUser> GetToHairNotification(Guid hairId);
        ICollection<DonatorUser> GetToBreastMilkNotification();
    }
}
