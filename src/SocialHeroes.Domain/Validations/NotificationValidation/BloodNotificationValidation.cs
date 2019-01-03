using FluentValidation;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class BloodNotificationValidation : AbstractValidator<BloodNotificationCommand>
    {
        public BloodNotificationValidation()
        {
            RuleFor(h => h.Amount)
                .NotEmpty().WithMessage("A quantidade de sangue é obrigatório!")
                .Must(IsValidAmount).WithMessage("A quantidade máxima de solicitação de sangue por tipo é 50!");

        }

        private bool IsValidAmount(int amount)
            => amount <= 50;
    }
}
