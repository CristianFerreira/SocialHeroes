using SocialHeroes.Domain.Core.Events;

namespace SocialHeroes.Domain.Events.AccountEvent
{
    public class ActiveUserAccountEvent : Event
    {
        public ActiveUserAccountEvent(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
