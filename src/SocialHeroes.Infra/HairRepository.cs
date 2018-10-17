using Dapper;
using SocialHeroes.Domain.DonatorContext.Models;
using SocialHeroes.Domain.DonatorContext.Queries;
using SocialHeroes.Domain.DonatorContext.Repositories;
using SocialHeroes.Infra.SharedContext.DataContexts;
using System.Collections.Generic;
using System.Data;

namespace SocialHeroes.Infra
{
    public class HairRepository : IHairRepository
    {
        private readonly DataContext _context;

        public HairRepository(DataContext context) => _context = context;

        public IEnumerable<ListHairQueryResult> Get()
        {
            return _context.Connection.Query<ListHairQueryResult>("SELECT * FROM hair");
        }

        public void Save(Hair hair)
        {
            _context.Connection.Execute("spRegisterHair",
           new
           {
               Id = hair.Id,
               Color = hair.Color
           }, commandType: CommandType.StoredProcedure);
        }
    }
}
