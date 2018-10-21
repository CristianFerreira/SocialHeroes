

using SocialHeroes.Domain.Core.Events;

namespace SocialHeroes.Infra.Data.EventDataBase
{
    public class EventDataBase : IEventDataBase
    {


        public EventDataBase()
        {
            //_eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            //var serializedData = JsonConvert.SerializeObject(theEvent);

            //var storedEvent = new StoredEvent(
            //    theEvent,
            //    serializedData,
            //    _user.Name);

            //_eventStoreRepository.Store(storedEvent);
        }
    }
}
