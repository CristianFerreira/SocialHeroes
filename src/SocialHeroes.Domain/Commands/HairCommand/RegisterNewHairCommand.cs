namespace SocialHeroes.Domain.Commands.HairCommand
{
    public class RegisterNewHairCommand : HairCommand
    {
        public RegisterNewHairCommand(string color)
        {
            Color = color;
        }
    }
}
