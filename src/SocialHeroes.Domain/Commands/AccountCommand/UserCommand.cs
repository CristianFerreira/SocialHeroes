using SocialHeroes.Domain.Core.Commands;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class UserCommand : Command
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public AddressAccountCommand Address { get; set; }
        public ICollection<UserNotificationTypeCommand> UserNotificationTypes { get; set; }
    }
}
