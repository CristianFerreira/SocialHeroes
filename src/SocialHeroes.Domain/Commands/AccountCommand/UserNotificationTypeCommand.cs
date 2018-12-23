using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.AccountCommand
{
    public class UserNotificationTypeCommand : Command
    {
        public Guid NotificationTypeId { get; set; }
    }
}
