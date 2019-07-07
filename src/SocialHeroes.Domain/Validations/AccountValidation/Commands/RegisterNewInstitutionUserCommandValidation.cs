using SocialHeroes.Domain.Commands.Account.RequestCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class RegisterNewInstitutionUserCommandValidation : InstitutionUserValidation<RegisterNewInstitutionUserCommand>
    {
        public RegisterNewInstitutionUserCommandValidation()
        {
            ValidateSocialReason();
            ValidateFantasyName();
            ValidateCNPJ();
            ValidatePassword();
            ValidatePasswordEqualsConfirmPassword();
            ValidateCity();
            ValidateStreet();
            ValidateAddressNumber();
            ValidateComplement();
            ValidateZipCode();
            ValidateState();
            ValidateCountry();
            ValidateLatitude();
            ValidateLongitude();
            ValidateUserNotificationType();
            ValidatePhone();
        }
    }
}
