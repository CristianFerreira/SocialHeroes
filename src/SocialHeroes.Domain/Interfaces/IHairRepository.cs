using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IHairRepository :IRepository<Hair>
    {
        IList<HairTypeQueryResponse> GetByType();
        IList<HairColorQueryResponse> GetColorByType(string type);
    }
}
