using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class Notification : IEntity
    {
        public Guid Id { get; set; }
        public Guid HospitalUserId { get; set; }
        public DateTime DateNotification { get; set; }

        public HospitalUser HospitalUser { get; set; }

        public ICollection<BloodNotification> BloodNotifications { get; private set; }
        public ICollection<HairNotification> HairNotifications { get; private set; }
        public ICollection<BreastMilkNotification> BreastMilkNotifications { get; private set; }
    }
}
