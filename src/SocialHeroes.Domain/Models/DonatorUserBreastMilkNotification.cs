using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserBreastMilkNotification : IEntity
    {
        public DonatorUserBreastMilkNotification(Guid id, 
                                                 Guid donatorUserId, 
                                                 Guid breastMilkNotificationId)
        {
            Id = id;
            DonatorUserId = donatorUserId;
            BreastMilkNotificationId = breastMilkNotificationId;
        }

        public Guid Id { get; private set; }
        public Guid DonatorUserId { get; private set; }
        public Guid BreastMilkNotificationId { get; private set; }
        public bool Appear { get; private set; }
        public DateTime? DateAppeared { get; private set; }

        public DonatorUser DonatorUser { get; private set; }
        public BreastMilkNotification BreastMilkNotification { get; private set; }
    }
}
