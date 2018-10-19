using FluentValidation;
using SocialHeroes.Domain.Commands.HairCommand;

namespace SocialHeroes.Domain.Validations.HairValidation
{
    public class HairValidation<T> : AbstractValidator<T> where T : HairCommand
    {
        protected void ValidateColor()
        {
            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("Por favor insira um valor para a cor de cabelo")
                .Length(2, 20).WithMessage("A cor deve ter entre 2 e 20 caracteres");
        }
    }
}
