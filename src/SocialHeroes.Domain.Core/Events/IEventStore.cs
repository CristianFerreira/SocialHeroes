namespace SocialHeroes.Domain.Core.Events
{
    public interface IEventDataBase
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
