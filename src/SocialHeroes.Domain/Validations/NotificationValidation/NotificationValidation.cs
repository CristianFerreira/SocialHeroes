using FluentValidation;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class NotificationValidation<T> : AbstractValidator<T> where T : NotificationCommand
    {
        protected void ValidateInstitutionId()
            => RuleFor(n => n.InstitutionUserId)
                    .NotEmpty().WithMessage("O Identificador da instituição é obrigatório!");

        
    }
}
