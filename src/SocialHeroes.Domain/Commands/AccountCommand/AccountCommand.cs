using SocialHeroes.Domain.Core.Commands;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class AccountCommand : Command
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
