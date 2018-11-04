namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class GetTokenAccountCommand : AccountCommand
    {
        public GetTokenAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
