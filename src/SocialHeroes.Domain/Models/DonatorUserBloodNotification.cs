using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserBloodNotification : IEntity
    {
        public DonatorUserBloodNotification(Guid id, 
                                            Guid donatorUserId, 
                                            Guid bloodNotificationId)
        {
            Id = id;
            DonatorUserId = donatorUserId;
            BloodNotificationId = bloodNotificationId;
        }

        public Guid Id { get; private set; }
        public Guid DonatorUserId { get; private set; }
        public Guid BloodNotificationId { get; private set; }
        public bool Appear { get; set; }
        public DateTime? DateAppeared { get; private set; }

        public BloodNotification BloodNotification { get; private set; }
        public DonatorUser DonatorUser { get; private set; }
    }
}
