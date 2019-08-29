using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class UserSocialNotificationType : IEntity
    {
        public UserSocialNotificationType(Guid id,
                                          Guid socialNotificationTypeId,
                                          Guid userId)
        {
            Id = id;
            SocialNotificationTypeId = socialNotificationTypeId;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid SocialNotificationTypeId { get; private set; }
        public Guid UserId { get; private set; }
        public SocialNotificationType SocialNotificationType { get; private set; }
        public User User { get; private set; }
    }
}
