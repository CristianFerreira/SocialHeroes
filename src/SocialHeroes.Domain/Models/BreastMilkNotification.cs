using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BreastMilkNotification : IEntity
    {
        public BreastMilkNotification(Guid id, 
                                     Guid notificationId, 
                                     int amountBreastMilk)
        {
            Id = id;
            NotificationId = notificationId;
            AmountBreastMilk = amountBreastMilk;
            Actived = true;
        }

        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public int AmountBreastMilk { get; private set; }
        public bool Actived { get; private set; }

        public Notification Notification { get; private set; }

        public ICollection<DonatorUserBreastMilkNotification> DonatorUserBreastMilkNotifications { get; private set; }
    }
}
