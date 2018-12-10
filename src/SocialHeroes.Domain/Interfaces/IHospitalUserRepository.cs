using SocialHeroes.Domain.Models;
using System;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IHospitalUserRepository : IRepository<HospitalUser>
    {
        HospitalUser GetByUserId(Guid userId);
    }
}
