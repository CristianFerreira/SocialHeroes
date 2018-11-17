using SocialHeroes.Domain.Commands.AccountCommand;

namespace SocialHeroes.Domain.Validations.AccountValidation
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
        }
    }
}
