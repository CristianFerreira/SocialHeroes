using SocialHeroes.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class Hair : IEntity
    {
        protected Hair() { }

        public Hair(Guid id, string color, string type)
        {
            Id = id;
            Color = color;
            Type = type;
        }

        public Guid Id { get; private set; }
        public string Color { get; private set; }
        public string Type { get; private set; }

        public ICollection<DonatorUser> DonatorsUsers { get; private set; }
        public ICollection<HairNotification> HairNotifications { get; private set; }
    }
}
