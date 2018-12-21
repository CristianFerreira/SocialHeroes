using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Blood : IEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public ICollection<DonatorUser> DonatorsUsers { get; private set; }
        public ICollection<BloodNotification> BloodNotifications { get; private set; }
    }
}
