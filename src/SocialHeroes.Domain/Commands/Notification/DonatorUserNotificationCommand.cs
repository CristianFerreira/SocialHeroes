using SocialHeroes.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class DonatorUserNotificationCommand : Command
    {
        public Guid HospitalUserId { get; set; }

        public BreastMilkNotificationCommand BreastMilkNotification { get; set; }
        public ICollection<BloodNotificationCommand> BloodNotifications { get; set; }
        public ICollection<HairNotificationCommand> HairNotifications { get; set; }
        
    }
}
