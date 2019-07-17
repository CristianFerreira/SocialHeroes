namespace SocialHeroes.Domain.Commands.Blood.RequestCommand
{
    public class RegisterNewBloodCommand : BloodCommand
    {
        public RegisterNewBloodCommand(string type)
        {
            Type = type;
        }
    }
}
