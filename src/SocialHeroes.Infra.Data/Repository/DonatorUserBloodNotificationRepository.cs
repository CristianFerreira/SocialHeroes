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
    public class DonatorUserBloodNotificationRepository : Repository<DonatorUserBloodNotification>, IDonatorUserBloodNotificationRepository
    {
        public DonatorUserBloodNotificationRepository(SocialHeroesContext context) : base(context)
        {
        }

        public ICollection<VwDonatorUserBloodNotificationRequested> GetRequestsByDonatorUserId(Guid donatorUserId)
        => Db.VwDonatorUserBloodNotificationRequested.AsNoTracking().Where(x=>x.DonatorUserId.Equals(donatorUserId)).OrderBy(x => x.DateNotification).ToList();
    }
}
