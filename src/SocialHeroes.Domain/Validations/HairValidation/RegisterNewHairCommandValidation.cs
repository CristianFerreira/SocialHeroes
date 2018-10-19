using SocialHeroes.Domain.Commands.HairCommand;

namespace SocialHeroes.Domain.Validations.HairValidation
{
    public class RegisterNewHairCommandValidation : HairValidation<RegisterNewHairCommand>
    {
        public RegisterNewHairCommandValidation()
        {
            ValidateColor();
        }
    }
}
