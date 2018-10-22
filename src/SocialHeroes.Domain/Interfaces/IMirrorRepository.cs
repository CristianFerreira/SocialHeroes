using System;
using System.Linq;

namespace SocialHeroes.Domain.Interfaces
{
    public interface IMirrorRepository<T>
    {
        void Add(T obj);
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
