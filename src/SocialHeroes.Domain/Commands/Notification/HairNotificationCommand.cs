using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class HairNotificationCommand : ISocialNetworkCommand
    {
        public Guid HairId { get; set; }
        public int Amount { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnInstagram { get; set; }
        public bool ShareOnTwitter { get; set; }
        public bool ShareOnWhatsapp { get; set; }

    }
}
