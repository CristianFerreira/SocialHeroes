using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Account
{
    public class NotificationTypeCommand : Command
    {
        public Guid Id { get; set; }
    }
}
