using SocialHeroes.Domain.Core.Interfaces;
using System;

namespace SocialHeroes.Domain.Models
{
    public class DonatorUserBloodNotification : IEntity
    {
        public Guid Id { get; set; }
        public Guid DonatorUserId { get; set; }
        public Guid BloodNotificationId { get; set; }
        public bool Appear { get; set; }
        public DateTime? DateAppeared { get; set; }
    }
}
