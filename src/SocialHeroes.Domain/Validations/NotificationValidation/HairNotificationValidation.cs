using FluentValidation;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class HairNotificationValidation : AbstractValidator<HairNotificationCommand>
    {
        public HairNotificationValidation()
        {
            RuleFor(h => h.Amount)
                .NotEmpty().WithMessage("A quantidade de cabelo é obrigatório!")
                .Must(IsValidAmount).WithMessage("A quantidade máxima de solicitação de cabelo é 100!");

        }

        private bool IsValidAmount(int amount)
            => amount <= 100;
    }
}
