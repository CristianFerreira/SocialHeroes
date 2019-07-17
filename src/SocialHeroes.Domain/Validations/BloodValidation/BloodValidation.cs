using FluentValidation;
using SocialHeroes.Domain.Commands.Blood;
using System;

namespace SocialHeroes.Domain.Validations.HairValidation
{
    public class BloodValidation<T> : AbstractValidator<T> where T : BloodCommand
    {
        protected void ValidateType()
        {
            RuleFor(b => b.Type)
                .NotEmpty().WithMessage("Por favor insira um valor para o tipo de sangue")
                .Length(2, 3).WithMessage("O tipo de sangue deve ter entre 2 e 3 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
