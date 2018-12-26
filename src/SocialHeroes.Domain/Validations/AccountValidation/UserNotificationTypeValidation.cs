using FluentValidation;
using SocialHeroes.Domain.Commands.Account;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class UserNotificationTypeValidation : AbstractValidator<UserNotificationTypeCommand>
    {
        public UserNotificationTypeValidation()
        {
            RuleFor(x => x.NotificationTypeId)
                                .NotNull()
                                    .NotEmpty()
                                      .WithMessage("Por favor informe pelo menos um tipo de notificação!");
        }
    }
}
