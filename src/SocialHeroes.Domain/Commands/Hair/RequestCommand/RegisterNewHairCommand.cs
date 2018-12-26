namespace SocialHeroes.Domain.Commands.Hair.RequestCommand
{
    public class RegisterNewHairCommand : HairCommand
    {
        public RegisterNewHairCommand(string color, string type)
        {
            Color = color;
            Type = type;
        }
    }
}
