using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class BloodNotificationCommand : ISocialNetworkCommand
    {
        public Guid BloodId { get; set; }
        public int Amount { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnLinkedin { get; set; }
        public bool ShareOnTwitter { get; set; }
    }
}
