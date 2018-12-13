using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class UserNotificationType : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationTypeId { get; set; }
        public Guid UserId { get; set; }
    }
}
