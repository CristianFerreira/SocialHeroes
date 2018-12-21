using System;
using SocialHeroes.Domain.Core.Interfaces;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserHairNotification : IEntity
    {
        public Guid Id {get; set;}
        public Guid DonatorUserId { get; set; }
        public Guid HairNotificationId { get; set; }
        public bool Appear { get; set; }
        public DateTime? DateAppeared { get; set; }

        public DonatorUser DonatorUser { get; set; }
        public HairNotification HairNotification { get; set; }
    }
}
