using System;

namespace SocialHeroes.Domain.Queries.views
{
    public class VwDonatorUserBloodNotificationRequested
    {
        public Guid NotificationId { get; set; }
        public Guid DonatorUserId { get; set; }
        public DateTime DateNotification { get; set; }
        public string InstitutionName { get; set; }
    }
}
