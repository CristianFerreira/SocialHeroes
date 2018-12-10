using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BloodNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public Guid BloodId { get; set; }
        public int AmountBlood { get; set; }
    }
}
