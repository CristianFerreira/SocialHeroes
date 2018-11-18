using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Queries;
using SocialHeroes.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Repository
{
    public class HairRepository : Repository<Hair>, IHairRepository
    {
        public HairRepository(SocialHeroesContext context)
            : base(context)
        {

        }

        public IList<HairTypeQueryResponse> GetByType()
            => DbSet.AsEnumerable()
               .GroupBy(h => h.Type)
               .Select((h, index) => new HairTypeQueryResponse
               {
                   Type = h.Key,
                   Key = ++index
               })
               .ToList();

        public IList<HairColorQueryResponse> GetColorByType(string type)
            => DbSet.AsNoTracking()
               .Where(h => h.Type == type)
               .Select((h) => new HairColorQueryResponse
               {
                   Id = h.Id,
                   Color = h.Color
               })
               .ToList();
    }
}
