using SocialHeroes.Domain.Validations.HairValidation;

namespace SocialHeroes.Domain.Commands.HairCommand
{
    public class RegisterNewHairCommand : HairCommand
    {
        //public RegisterNewHairCommand(string color)
        //{
        //    Color = color;
        //}

        public string Color { get; set; }

        public override bool IsValid()
        {
            return new RegisterNewHairCommandValidation().Validate(this).IsValid;
        }
    }
}
