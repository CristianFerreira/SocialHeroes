using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Blood : IEntity
    {
        protected Blood() { }

        public Blood(Guid id, string type)
        {
            Id = id;
            Type = type;
        }

        public Guid Id { get; private set; }
        public string Type { get; private set; }

        [IgnoreDataMember]
        public ICollection<DonatorUser> DonatorsUsers { get; private set; }
        [IgnoreDataMember]
        public ICollection<BloodNotification> BloodNotifications { get; private set; }
    }
}
