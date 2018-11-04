using FluentValidation;
using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class AccountValidation<T> : AbstractValidator<T> where T : AccountCommand
    {
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira um valor para o e-mail")
                .EmailAddress().WithMessage("Por favor informe um e-mail valido!")
                .MaximumLength(256).WithMessage("O E-mail deve ter no máximo 256 caracteres");
        }

        protected void ValidatePasswordEqualsConfirmPassword()
        {
            RuleFor(c => c.Password)
                .Equal(c => c.ConfirmPassword).WithMessage("A senha e a confirmação de senha devem ter o mesmo valor");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor insira um valor para a senha")
                .Length(6, 12).WithMessage("A senha deve ter entre 6 e 12 caracteres");
        }
    }
}
