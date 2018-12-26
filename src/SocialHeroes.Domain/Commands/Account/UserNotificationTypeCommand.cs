using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Account
{
    public class UserNotificationTypeCommand : Command
    {
        public Guid NotificationTypeId { get; set; }
    }
}
