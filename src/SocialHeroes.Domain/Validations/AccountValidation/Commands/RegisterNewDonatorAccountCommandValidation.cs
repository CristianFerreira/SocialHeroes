using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
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
