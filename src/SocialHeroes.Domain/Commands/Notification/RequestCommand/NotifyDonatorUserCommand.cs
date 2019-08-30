using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.Notification.RequestCommand
{
    public class NotifyDonatorUserCommand : DonatorUserNotificationCommand
    {
        public NotifyDonatorUserCommand(Guid institutionUserId,
                                        bool enableRequestOnPage,
                                        BreastMilkNotificationCommand breastMilkNotification,
                                        ICollection<BloodNotificationCommand> bloodNotifications,
                                        ICollection<HairNotificationCommand> hairNotifications)
        {
            InstitutionUserId = institutionUserId;
            EnableRequestOnPage = enableRequestOnPage;
            BreastMilkNotification = breastMilkNotification;
            BloodNotifications = bloodNotifications;
            HairNotifications = hairNotifications;
        }
    }
}
