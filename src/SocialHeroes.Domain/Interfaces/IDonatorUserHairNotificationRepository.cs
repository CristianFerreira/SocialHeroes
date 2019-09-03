using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IDonatorUserHairNotificationRepository : IRepository<DonatorUserHairNotification>
    {
        ICollection<VwDonatorUserHairNotificationRequested> GetRequestsByDonatorUserId(Guid donatorUserId);
    }
}
