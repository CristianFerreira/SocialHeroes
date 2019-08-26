using SocialHeroes.Domain.Commands.Account.RequestCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class RegisterNewDonatorUserCommandValidation : DonatorUserValidation<RegisterNewDonatorUserCommand>
    {
        public RegisterNewDonatorUserCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateGenre();
            ValidatePassword();
            ValidatePasswordEqualsConfirmPassword();
        }
    }
}
