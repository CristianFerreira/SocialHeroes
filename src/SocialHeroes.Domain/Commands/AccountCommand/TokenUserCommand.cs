namespace SocialHeroes.Domain.Commands.AccountCommand
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
