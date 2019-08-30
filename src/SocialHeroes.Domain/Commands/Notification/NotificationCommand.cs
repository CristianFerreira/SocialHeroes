using SocialHeroes.Domain.Core.Commands;
using System;

namespace SocialHeroes.Domain.Commands.Notification
{
    public class NotificationCommand : Command
    {
        public Guid InstitutionUserId { get; set; }
        public bool EnableRequestOnPage { get; set; }
    }
}
