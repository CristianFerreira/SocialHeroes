using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Queries;
using System.Collections.Generic;

namespace SocialHeroes.Domain.DonatorContext.Repositories
{
    public interface IHairRepository
    {
        void Save(Hair hair);
        IEnumerable<ListHairQueryResult> Get();
    }
}
