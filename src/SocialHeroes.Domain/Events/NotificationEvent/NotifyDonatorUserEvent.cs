using SocialHeroes.Domain.Core.Events;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Events.NotificationEvent
{
    public class NotifyDonatorUserEvent : Event
    {
        public NotifyDonatorUserEvent(string hospital)
        {
            Hospital = hospital;
            DonatorUserNotificationsEvent = new List<DonatorUserNotificationEvent>();
        }

        public NotifyDonatorUserEvent(string hospital, 
                                      string street, 
                                      string number, 
                                      string city, 
                                      string state,
                                      string country)
        {
            Hospital = hospital;
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            DonatorUserNotificationsEvent = new List<DonatorUserNotificationEvent>();
        }

        public string Hospital { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ICollection<DonatorUserNotificationEvent> DonatorUserNotificationsEvent { get; private set; }

        public void AddDonatorUserNotificationEvent(DonatorUserNotificationEvent donatorUserNotificationEvent)
            => DonatorUserNotificationsEvent.Add(donatorUserNotificationEvent);
    }
}
