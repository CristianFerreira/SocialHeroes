using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class DonatorUserNotificationCommand : NotificationCommand
    {
        public BreastMilkNotificationCommand BreastMilkNotification { get; set; }
        public ICollection<BloodNotificationCommand> BloodNotifications { get; set; }
        public ICollection<HairNotificationCommand> HairNotifications { get; set; }
        
    }
}
