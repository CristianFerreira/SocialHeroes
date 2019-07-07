using SocialHeroes.Domain.Models;
using System;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IInstitutionUserRepository : IRepository<InstitutionUser>
    {
        InstitutionUser GetByUserId(Guid id);
        InstitutionUser Get(Guid userId);
    }
}
