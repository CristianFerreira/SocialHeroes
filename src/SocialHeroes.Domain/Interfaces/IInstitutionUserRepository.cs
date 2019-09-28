using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries.views;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IInstitutionUserRepository : IRepository<InstitutionUser>
    {
        InstitutionUser GetByUserId(Guid id);
        InstitutionUser Get(Guid userId);
        ICollection<VwNotificationsFromInstitutions> GetAllNotificationsByInstitutionUserId(Guid id);
    }
}
