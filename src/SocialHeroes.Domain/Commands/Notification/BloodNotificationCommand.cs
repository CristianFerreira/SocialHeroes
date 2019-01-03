using System;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class BloodNotificationCommand
    {
        public Guid BloodId { get; set; }
        public int Amount { get; set; }
    }
}
