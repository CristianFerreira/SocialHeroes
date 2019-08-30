using SocialHeroes.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Models
{
    public class BloodNotification : IEntity, ISocialNetwork
    {
        public BloodNotification(Guid id, 
                                 Guid notificationId, 
                                 Guid bloodId, 
                                 int amountBlood,
                                 bool shareOnFacebook,
                                 bool shareOnLinkedin,
                                 bool shareOnTwitter)
        {
            Id = id;
            NotificationId = notificationId;
            BloodId = bloodId;
            AmountBlood = amountBlood;
            Actived = true;
            ShareOnFacebook = shareOnFacebook;
            ShareOnLinkedin = shareOnLinkedin;
            ShareOnTwitter = shareOnTwitter;
        }

        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public Guid BloodId { get; private set; }
        public int AmountBlood { get; private set; }
        public bool Actived { get; private set; }
        public bool ShareOnFacebook { get; private set; }
        public bool ShareOnLinkedin { get; private set; }
        public bool ShareOnTwitter{ get; private set; }

        public Notification Notification { get; private set; }
        public Blood Blood { get; private set; }

        public ICollection<DonatorUserBloodNotification> DonatorUserBloodNotifications { get; private set; }
    }
}
