using SocialHeroes.Domain.DonatorContext.Models;
using System.Collections.Generic;

namespace SocialHeroes.Domain.DonatorContext.Repositories
{
    public interface IHairRepository
    {
        void Save(Hair hair);
        IEnumerable<Hair> Get();
    }
}
