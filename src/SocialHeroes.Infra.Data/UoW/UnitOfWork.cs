using Microsoft.EntityFrameworkCore.Storage;
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

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Commit(IDbContextTransaction transaction)
        {
            if (_context.SaveChanges() > 0)
            {
                transaction.Commit();
                return true;
            }
            else
                return false;
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
