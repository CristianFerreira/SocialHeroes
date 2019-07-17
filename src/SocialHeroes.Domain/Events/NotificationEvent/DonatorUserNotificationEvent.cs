namespace SocialHeroes.Domain.Events.NotificationEvent
{
    public class DonatorUserNotificationEvent
    {
        public DonatorUserNotificationEvent(string name, 
                                            string email,                                         
                                            string notificationType,
                                            string type = null)
        {
            Name = name;
            Email = email;         
            NotificationType = notificationType;
            Type = type;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string NotificationType { get; set; }
        public string Type { get; set; }


    }
}
