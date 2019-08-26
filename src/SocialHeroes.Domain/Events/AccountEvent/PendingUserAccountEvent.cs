using SocialHeroes.Domain.Core.Events;

namespace SocialHeroes.Domain.Events.AccountEvent
{
    public class PendingUserAccountEvent : Event
    {
        public PendingUserAccountEvent(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
