using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class UserNotificationType : IEntity
    {
        public UserNotificationType(Guid id, 
                                    Guid notificationTypeId, 
                                    Guid userId)
        {
            Id = id;
            NotificationTypeId = notificationTypeId;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid NotificationTypeId { get; private set; }
        public Guid UserId { get; private set; }

        public NotificationType NotificationType { get; private set; }
        public User User { get; private set; }
    }
}
