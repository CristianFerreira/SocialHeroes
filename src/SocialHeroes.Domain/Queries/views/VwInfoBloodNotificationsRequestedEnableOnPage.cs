using System;

namespace SocialHeroes.Domain.Queries.Views
{
    public class VwInfoBloodNotificationsRequestedEnableOnPage
    {
        public Guid NotificationId { get; set; }
        public DateTime DateNotification { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnTwitter { get; set; }
        public bool ShareOnLinkedin { get; set; }
        public string InstitutionName { get; set; }
        public string Type { get; set; }
    }
}
