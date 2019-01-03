using FluentValidation;
using SocialHeroes.Domain.Commands.Notification;

namespace SocialHeroes.Domain.Validations.NotificationValidation
{
    public class NotificationValidation<T> : AbstractValidator<T> where T : NotificationCommand
    {
        protected void ValidateHospitalId()
            => RuleFor(n => n.HospitalUserId)
                    .NotEmpty().WithMessage("O Identificador do hospital é obrigatório!");

        
    }
}
