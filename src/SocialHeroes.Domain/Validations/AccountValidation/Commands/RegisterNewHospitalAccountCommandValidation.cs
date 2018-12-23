using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation.Commands
{
    public class RegisterNewHospitalAccountCommandValidation : HospitalAccountValidation<RegisterNewHospitalAccountCommand>
    {
        public RegisterNewHospitalAccountCommandValidation()
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
        }
    }
}
