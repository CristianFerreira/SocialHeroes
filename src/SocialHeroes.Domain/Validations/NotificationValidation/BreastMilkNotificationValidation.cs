using FluentValidation;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class BreastMilkNotificationValidation : AbstractValidator<BreastMilkNotificationCommand>
    {
        public BreastMilkNotificationValidation()
        {
            RuleFor(h => h.Amount)
                   .NotEmpty().WithMessage("A quantidade de leite materno é obrigatório!")
                   .Must(IsValidAmount).WithMessage("A quantidade máxima de solicitação de leite materno é 50!");

        }

        private bool IsValidAmount(int amount)
            => amount <= 50;
    }
}
