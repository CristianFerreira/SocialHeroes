using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BloodNotification : IEntity
    {
        public BloodNotification(Guid id, 
                                 Guid notificationId, 
                                 Guid bloodId, 
                                 int amountBlood)
        {
            Id = id;
            NotificationId = notificationId;
            BloodId = bloodId;
            AmountBlood = amountBlood;
        }

        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public Guid BloodId { get; private set; }
        public int AmountBlood { get; private set; }
        public bool Actived { get; private set; }


        public Notification Notification { get; private set; }
        public Blood Blood { get; private set; }

        public ICollection<DonatorUserBloodNotification> DonatorUserBloodNotifications { get; private set; }
    }
}
