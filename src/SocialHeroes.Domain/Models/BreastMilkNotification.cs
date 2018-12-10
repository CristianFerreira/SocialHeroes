using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BreastMilkNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public int AmountBreastMilk { get; set; }

    }
}
