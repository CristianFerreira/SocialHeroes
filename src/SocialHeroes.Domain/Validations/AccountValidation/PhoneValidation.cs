using FluentValidation;
using SocialHeroes.Domain.Commands.Account;
using System.Text.RegularExpressions;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class PhoneValidation : AbstractValidator<PhoneCommand>
    {
        public PhoneValidation()
        {
            RuleFor(x => x.Number)
                .Must(PhoneNumberIsValid)
                    .WithMessage(x => $"O numero de telefone está inválido: {x.Number}!");
        }

        private bool PhoneNumberIsValid(string number)
        {
            var regex = @"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$";
            return Regex.IsMatch(number, regex);
        }
    }
}
