using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BreastMilkNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public int AmountBreastMilk { get; set; }
        public bool Actived { get; set; }

        public Notification Notification { get; set; }

        public ICollection<DonatorUserBreastMilkNotification> DonatorUserBreastMilkNotifications { get; private set; }
    }
}
