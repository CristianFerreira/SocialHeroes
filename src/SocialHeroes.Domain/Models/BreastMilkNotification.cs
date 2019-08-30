using System;
using System.Collections.Generic;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class BreastMilkNotification : IEntity, ISocialNetwork
    {
        public BreastMilkNotification(Guid id, 
                                      Guid notificationId, 
                                      int amountBreastMilk,
                                      bool shareOnFacebook,
                                      bool shareOnLinkedin,
                                      bool shareOnTwitter)
        {
            Id = id;
            NotificationId = notificationId;
            AmountBreastMilk = amountBreastMilk;
            Actived = true;
            ShareOnFacebook = shareOnFacebook;
            ShareOnLinkedin = shareOnLinkedin;
            ShareOnTwitter = shareOnTwitter;
        }

        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public int AmountBreastMilk { get; private set; }
        public bool Actived { get; private set; }
        public bool ShareOnFacebook { get; private set; }
        public bool ShareOnLinkedin { get; private set; }
        public bool ShareOnTwitter { get; private set; }

        public Notification Notification { get; private set; }

        public ICollection<DonatorUserBreastMilkNotification> DonatorUserBreastMilkNotifications { get; private set; }
    }
}
