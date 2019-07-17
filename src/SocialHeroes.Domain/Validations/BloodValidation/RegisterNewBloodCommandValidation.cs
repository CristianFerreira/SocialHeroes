using SocialHeroes.Domain.Commands.Blood.RequestCommand;
using SocialHeroes.Domain.Validations.HairValidation;

namespace SocialHeroes.Domain.Validations.BloodValidation
{
    public class RegisterNewBloodCommandValidation : BloodValidation<RegisterNewBloodCommand>
    {
        public RegisterNewBloodCommandValidation()
        {
            ValidateType();
        }
    }
}
