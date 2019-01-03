using SocialHeroes.Domain.Core.Events;
using System.Collections.Generic;

namespace SocialHeroes.Domain.Events.NotificationEvent
{
    public class NotifyDonatorUserEvent : Event
    {
        public NotifyDonatorUserEvent()
        {
            DonatorUserNotificationsEvent = new List<DonatorUserNotificationEvent>();
        }
        public string Hospital { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public ICollection<DonatorUserNotificationEvent> DonatorUserNotificationsEvent { get; private set; }

        public void AddDonatorUserNotificationEvent(DonatorUserNotificationEvent donatorUserNotificationEvent)
            => DonatorUserNotificationsEvent.Add(donatorUserNotificationEvent);
    }
}
