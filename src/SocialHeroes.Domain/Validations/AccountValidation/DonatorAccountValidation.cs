using FluentValidation;
using SocialHeroes.Domain.Commands.AccountCommand;
using System;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class DonatorAccountValidation<T> : AccountValidation<T> where T : DonatorAccountCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor informe o nome.");
        }

        protected void ValidateGenre()
        {
            RuleFor(c => c.Genre)
                .NotEmpty().WithMessage("Por favor informe o gênero.");
        }

        protected void ValidateDateBirth()
        {
            RuleFor(c => c.DateBirth)
                .NotEmpty().WithMessage("Por favor informe a data de nascimento.")
                .Must(HaveMinimumAge).WithMessage("O doador deve ter 18 anos ou mais.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento é maior do que a data atual.");
        }

        protected void ValidateLastDonation()
        {
            RuleFor(c => c.LastDonation)              
                .GreaterThan(DateTime.Now).WithMessage("A data da ultima doação é maior do que a data atual.");
        }

        private static bool HaveMinimumAge(DateTime birthDate)
            => birthDate <= DateTime.Now.AddYears(-18);
        
    }
}
