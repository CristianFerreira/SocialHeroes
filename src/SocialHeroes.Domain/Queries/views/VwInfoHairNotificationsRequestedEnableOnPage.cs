using System;

namespace SocialHeroes.Domain.Queries.views
{
    public class VwInfoHairNotificationsRequestedEnableOnPage
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
