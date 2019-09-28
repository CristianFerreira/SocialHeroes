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
    public class InstitutionUserRepository : Repository<InstitutionUser>, IInstitutionUserRepository
    {
        public InstitutionUserRepository(SocialHeroesContext context) : base(context)
        {
        }

        public InstitutionUser GetByUserId(Guid userId)
        => DbSet.AsNoTracking().FirstOrDefault(x => x.UserId == userId);
        
        public InstitutionUser Get(Guid id)
        =>  DbSet.AsNoTracking().Include(x => x.User).ThenInclude(x => x.Address).FirstOrDefault(x => x.Id == id);

        public ICollection<VwNotificationsFromInstitutions> GetAllNotificationsByInstitutionUserId(Guid id)
        => Db.VwNotificationsFromInstitutions.AsNoTracking().Where(x => x.InstitutionUserId.Equals(id)).OrderByDescending(x => x.DateNotification).ToList();
        
    }
}
