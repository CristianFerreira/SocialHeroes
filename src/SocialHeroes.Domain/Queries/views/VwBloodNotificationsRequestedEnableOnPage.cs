using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHeroes.Domain.Queries.Views
{
    public class VwBloodNotificationsRequestedEnableOnPage
    {
        public Guid NotificationId { get; set; }
        public DateTime DateNotification { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnTwitter { get; set; }
        public bool ShareOnLinkedin { get; set; }
        public string InstitutionName { get; set; }
        public string BloodType { get; set; }
    }
}
