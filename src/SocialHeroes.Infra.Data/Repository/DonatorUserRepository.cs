using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserRepository : Repository<DonatorUser>, IDonatorUserRepository
    {
        public DonatorUserRepository(SocialHeroesContext context) : base(context)
        {
        }

        public DonatorUser GetByUserId(Guid userId)
            => DbSet.AsNoTracking().FirstOrDefault(x => x.UserId == userId);

        public ICollection<DonatorUser> GetToBloodNotification(Guid bloodId)
            => DbSet.AsNoTracking()
                    .Where(x => x.BloodId == bloodId && x.ActivedBloodNotification == true)
                    .Include(x => x.Blood)
                    .Include(x => x.User)
                    .ToList();

        public ICollection<DonatorUser> GetToBreastMilkNotification()
            => DbSet.AsNoTracking()
                    .Where(x => x.ActivedBreastMilkNotification == true)
                    .Include(x => x.User)
                    .ToList();

        public ICollection<DonatorUser> GetToHairNotification(Guid hairId)
            => DbSet.AsNoTracking()
                    .Where(x => x.HairId == hairId && x.ActivedHairNotification == true)
                    .Include(x => x.Hair)
                    .Include(x => x.User)
                    .ToList();
    }
}
