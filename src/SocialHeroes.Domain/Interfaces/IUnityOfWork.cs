using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        bool Commit(IDbContextTransaction transaction);
        void Rollback(IDbContextTransaction transaction);
        IDbContextTransaction BeginTransaction(); 
    }
}
