namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class TokenAccountCommand : AccountCommand
    {
        public TokenAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
