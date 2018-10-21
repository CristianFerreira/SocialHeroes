using MediatR;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Validations.HairValidation;

namespace SocialHeroes.Domain.Commands.HairCommand
{
    public class RegisterNewHairCommand : HairCommand
    {
        public RegisterNewHairCommand(string color)
        {
            Color = color;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewHairCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
