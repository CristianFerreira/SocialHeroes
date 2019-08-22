using FluentValidation;
using SocialHeroes.Domain.Commands.Account.RequestCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class ActiveUserCommandValidation : AbstractValidator<ActiveUserCommand>
    {
        public ActiveUserCommandValidation()
        {
            ValidateEmail();
        }

        private void ValidateEmail()
        => RuleFor(c => c.Email)
           .NotEmpty().WithMessage("Por favor, informe o email");
    }
}
