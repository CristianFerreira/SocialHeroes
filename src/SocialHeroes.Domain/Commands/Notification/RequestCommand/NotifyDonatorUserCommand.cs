using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Notification.RequestCommand
{
    public class NotifyDonatorUserCommand : DonatorUserNotificationCommand
    {
        public NotifyDonatorUserCommand(Guid hospitalUserId, 
                                        BreastMilkNotificationCommand breastMilkNotification = null,
                                        ICollection<BloodNotificationCommand> bloodNotifications = null,
                                        ICollection<HairNotificationCommand> hairNotifications = null)
        {
            HospitalUserId = hospitalUserId;

            BreastMilkNotification = breastMilkNotification;
            BloodNotifications = bloodNotifications;
            HairNotifications = hairNotifications;
        }
    }
}
