using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Events;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Context;

namespace SocialHeroes.Infra.Data.MirrorRepository
{
    public class MirrorRepository<TEntity> : IMirrorRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase Db;
        private IMongoCollection<TEntity> Collection { get; set; }

        public MirrorRepository(SocialHeroesMirrorContext context)
        {
            Db = context.Db;
            
        }

        public void Add(TEntity obj)
        {
            var hair = new Hair(Guid.NewGuid(), "aaee");

            var x = Db.GetCollection<Hair>("hair");

 

            x.InsertOneAsync(hair);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
