using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class HairNotification : IEntity
    {
        public HairNotification(Guid id, 
                                Guid notificationId, 
                                Guid hairId, 
                                int amountHair)
        {
            Id = id;
            NotificationId = notificationId;
            HairId = hairId;
            AmountHair = amountHair;
            Actived = true;
        }

        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public Guid HairId { get; private set; }
        public int AmountHair { get; private set; }
        public bool Actived { get; private set; }

        public Notification Notification { get; private set; }
        public Hair Hair { get; private set; }

        public ICollection<DonatorUserHairNotification> DonatorUserHairNotifications { get; private set; }
    }
}
