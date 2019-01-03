namespace SocialHeroes.Domain.Events.NotificationEvent
{
    public class DonatorUserNotificationEvent
    {
        public DonatorUserNotificationEvent(string name, 
                                            string email, 
                                            string notificationType)
        {
            Name = name;
            Email = email;
            NotificationType = notificationType;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string NotificationType { get; set; }
    }
}
