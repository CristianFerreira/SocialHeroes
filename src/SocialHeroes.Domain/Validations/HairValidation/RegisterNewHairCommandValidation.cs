using SocialHeroes.Domain.Commands.Hair.RequestCommand;

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
