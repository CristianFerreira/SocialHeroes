using System;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class HairNotificationCommand
    {
        public Guid HairId { get; set; }
        public int Amount { get; set; }
    }
}
