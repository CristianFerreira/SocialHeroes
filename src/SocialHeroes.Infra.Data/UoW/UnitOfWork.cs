using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialHeroesContext _context;

        public UnitOfWork(SocialHeroesContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
