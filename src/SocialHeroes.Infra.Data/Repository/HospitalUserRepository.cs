using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.Repository
{
    public class HospitalUserRepository : Repository<HospitalUser>, IHospitalUserRepository
    {
        public HospitalUserRepository(SocialHeroesContext context) : base(context)
        {
        }

        public HospitalUser GetByUserId(Guid userId)
        => DbSet.AsNoTracking().FirstOrDefault(x => x.UserId == userId);
    }
}
