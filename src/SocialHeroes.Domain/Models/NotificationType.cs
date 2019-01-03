using SocialHeroes.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class NotificationType : IEntity
    {
        public NotificationType(Guid id, 
                                string name, 
                                string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<UserNotificationType> UserNotificationTypes { get; private set; }
    }
}
