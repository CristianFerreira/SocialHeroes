using System;

namespace SocialHeroes.Domain.Queries.views
{
    public class VwBloodNotificationsRequestedEnableOnPage
    {
        public Guid NotificationId { get; set; }
        public DateTime DateNotification { get; set; }
        public bool ShareOnFacebook { get; set; }
        public bool ShareOnTwitter { get; set; }
        public bool ShareOnLinkedin { get; set; }
        public string InstitutionName { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ZipCode { get; set; }
    }
}
