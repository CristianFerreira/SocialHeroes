using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class BreastMilkNotificationCommand : ISocialNetworkCommand
    {
        public int Amount { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnLinkedin { get; set; }
        public bool ShareOnTwitter { get; set; }
    }
}
