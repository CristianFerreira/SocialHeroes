using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;
using System;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class DonatorUserRepository : Repository<DonatorUser>, IDonatorUserRepository
    {
        public DonatorUserRepository(SocialHeroesContext context) : base(context)
        {
        }

        public DonatorUser GetAllUser()
        {
            var teste = Db.DonatorUsers.Include(x => x.User).FirstOrDefault(x => x.Id == Guid.Parse("9FF22F99-7809-4095-83A2-6E53D2E368DD"));
            return teste;
        }
    }
}
