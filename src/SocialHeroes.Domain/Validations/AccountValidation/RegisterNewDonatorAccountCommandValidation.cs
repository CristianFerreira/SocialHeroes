using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class RegisterNewDonatorAccountCommandValidation : DonatorAccountValidation<RegisterNewDonatorAccountCommand>
    {
        public RegisterNewDonatorAccountCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateDateBirth();
            ValidateGenre();
            ValidateLastDonation();
            ValidatePassword();
            ValidatePasswordEqualsConfirmPassword();
        }
    }
}
