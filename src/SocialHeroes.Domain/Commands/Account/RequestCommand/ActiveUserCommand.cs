using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Account.RequestCommand
{
    public class ActiveUserCommand : Command
    {
        public string Email { get; set; }
    }
}
