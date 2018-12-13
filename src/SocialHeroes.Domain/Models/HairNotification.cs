using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class HairNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public Guid HairId { get; set; }
        public int AmountHair { get; set; }
        public bool Actived { get; set; }
    }
}
