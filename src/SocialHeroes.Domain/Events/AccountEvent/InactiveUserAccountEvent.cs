using SocialHeroes.Domain.Core.Events;

namespace SocialHeroes.Domain.Events.AccountEvent
{
    public class InactiveUserAccountEvent :Event
    {
        public InactiveUserAccountEvent(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
