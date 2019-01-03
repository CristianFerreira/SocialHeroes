using FluentValidation;
using FluentValidation.Results;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class DonatorUserNotificationValidation<T> : NotificationValidation<T>
                                                        where T : DonatorUserNotificationCommand
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            return (!AnyNotificationNotNull(context))
                ? new ValidationResult(new[] { new ValidationFailure("Notifications", "Pelo menos uma solicitação de notificação é obrigátorio!") })
                : base.Validate(context);
        }

        private bool AnyNotificationNotNull(ValidationContext<T> context)
            => (context.InstanceToValidate.BloodNotifications != null && context.InstanceToValidate.BloodNotifications.Count > 0)
               || (context.InstanceToValidate.HairNotifications != null && context.InstanceToValidate.HairNotifications.Count > 0)
               || (context.InstanceToValidate.BreastMilkNotification != null);

        public void ValidateBreastMilkNotification()
            => When(x => x != null, () =>
            {
                RuleFor(b => b.BreastMilkNotification)
                   .SetValidator(new BreastMilkNotificationValidation());
            });



        public void ValidateHairNotification()
            => When(x => x != null, () =>
            {
                RuleForEach(h => h.HairNotifications)
                    .SetValidator(new HairNotificationValidation());
            });


        public void ValidateBloodNotification()
            => When(x => x != null, () =>
               {
                   RuleForEach(b => b.BloodNotifications)
                       .SetValidator(new BloodNotificationValidation());
               });




    }
}
