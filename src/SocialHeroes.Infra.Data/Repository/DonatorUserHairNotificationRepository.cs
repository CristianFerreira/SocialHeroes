using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserHairNotificationRepository : Repository<DonatorUserHairNotification>,
                                                         IDonatorUserHairNotificationRepository
    {
        public DonatorUserHairNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }

        public ICollection<VwDonatorUserHairNotificationRequested> GetRequestsByDonatorUserId(Guid donatorUserId)
        => Db.VwDonatorUserHairNotificationRequested.AsNoTracking().Where(x => x.DonatorUserId.Equals(donatorUserId)).OrderBy(x=>x.DateNotification).ToList();
    }
}
