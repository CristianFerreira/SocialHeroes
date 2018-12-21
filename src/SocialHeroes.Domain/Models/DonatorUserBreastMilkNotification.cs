using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserBreastMilkNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid DonatorUserId { get; set; }
        public Guid BreastMilkNotificationId { get; set; }
        public bool Appear { get; set; }
        public DateTime? DateAppeared { get; set; }

        public DonatorUser DonatorUser { get; set; }
        public BreastMilkNotification BreastMilkNotification { get; set; }
    }
}
