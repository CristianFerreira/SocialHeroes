using SocialHeroes.Domain.Commands.Notification.RequestCommand;

namespace SocialHeroes.Domain.Validations.NotificationValidation.Commands
{
    public class NotifyDonatorUserCommandValidation : DonatorUserNotificationValidation<NotifyDonatorUserCommand>
    {
        public NotifyDonatorUserCommandValidation()
        {
            ValidateHospitalId();
            ValidateBloodNotification();
            ValidateBreastMilkNotification();
            ValidateHairNotification();
        }
    }
}
