using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Notification : IEntity
    {
        public Notification(Guid id, 
                            Guid hospitalUserId)
        {
            Id = id;
            HospitalUserId = hospitalUserId;
            DateNotification = DateTime.Now;
            BloodNotifications = new List<BloodNotification>();
            HairNotifications = new List<HairNotification>();
        }

        public Guid Id { get; private set; }
        public Guid HospitalUserId { get; private set; }
        public DateTime DateNotification { get; private set; }

        public HospitalUser HospitalUser { get; private set; }

        public ICollection<BloodNotification> BloodNotifications { get; private set; }
        public ICollection<HairNotification> HairNotifications { get; private set; }
        public BreastMilkNotification BreastMilkNotification { get; private set; }

        public void SetBreastMilkNotification(BreastMilkNotification breastMilkNotification)
            => BreastMilkNotification = breastMilkNotification;
    }
}
