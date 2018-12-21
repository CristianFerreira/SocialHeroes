using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BloodNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public Guid BloodId { get; set; }
        public int AmountBlood { get; set; }
        public bool Actived { get; set; }

        //public DonatorUserBloodNotification DonatorUserBloodNotification { get; set; }
        public Notification Notification { get; set; }
        public Blood Blood { get; set; }

        public ICollection<DonatorUserBloodNotification> DonatorUserBloodNotifications { get; private set; }
    }
}
