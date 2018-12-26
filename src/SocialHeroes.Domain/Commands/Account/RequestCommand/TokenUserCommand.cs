namespace SocialHeroes.Domain.Commands.Account.RequestCommand
{
    public class TokenUserCommand : UserCommand
    {
        public TokenUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
