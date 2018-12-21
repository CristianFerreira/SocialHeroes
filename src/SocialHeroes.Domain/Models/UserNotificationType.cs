using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class UserNotificationType : IEntity
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Guid UserId { get; set; }

        public NotificationType NotificationType { get; set; }
        public User User { get; set; }
    }
}
