

using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Models;
using System;

namespace SocialHeroes.Infra.Data.EventDataBase
{
    public class EventDataBase : IEventDataBase
    {
        private readonly IMirrorRepository<Hair> _mirrorRepository;

        public EventDataBase(IMirrorRepository<Hair> mirrorRepository)
        {
            _mirrorRepository = mirrorRepository;
            //_user = user;
        }

        public void Save<T>(T obj) where T : Event
        {

            _mirrorRepository.Add(new Hair(new Guid(), "Testeee"));
            //var serializedData = JsonConvert.SerializeObject(theEvent);

            //var storedEvent = new StoredEvent(
            //    theEvent,
            //    serializedData,
            //    _user.Name);

            //_eventStoreRepository.Store(storedEvent);
        }
    }
}
