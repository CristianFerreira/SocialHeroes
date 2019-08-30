using Newtonsoft.Json;
using SocialHeroes.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class SocialNotificationType : IEntity
    {
        public SocialNotificationType(Guid id,
                                      string name,
                                      string code,
                                      string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

        [JsonIgnore]
        public ICollection<UserSocialNotificationType> UserSocialNotificationTypes { get; private set; }
    }
}
