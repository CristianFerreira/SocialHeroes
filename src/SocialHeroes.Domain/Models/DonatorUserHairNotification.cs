using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserHairNotification : IEntity
    {
        public DonatorUserHairNotification(Guid id, 
                                           Guid donatorUserId, 
                                           Guid hairNotificationId)
        {
            Id = id;
            DonatorUserId = donatorUserId;
            HairNotificationId = hairNotificationId;
        }

        public Guid Id {get; private set; }
        public Guid DonatorUserId { get; private set; }
        public Guid HairNotificationId { get; private set; }
        public bool Appear { get; private set; }
        public DateTime? DateAppeared { get; private set; }

        public DonatorUser DonatorUser { get; private set; }
        public HairNotification HairNotification { get; private set; }
    }
}
