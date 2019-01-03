using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Notification.RequestCommand
{
    public class NotifyDonatorUserCommand : DonatorUserNotificationCommand
    {
        public NotifyDonatorUserCommand(Guid hospitalUserId, 
                                        BreastMilkNotificationCommand breastMilkNotification,
                                        ICollection<BloodNotificationCommand> bloodNotifications,
                                        ICollection<HairNotificationCommand> hairNotifications)
        {
            HospitalUserId = hospitalUserId;

            BreastMilkNotification = breastMilkNotification;
            BloodNotifications = bloodNotifications;
            HairNotifications = hairNotifications;
        }
    }
}
