using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Events.NotificationEvent;
using SocialHeroes.Domain.Services;
using SocialHeroes.Domain.Services.Extensions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SocialHeroes.Domain.EventHandlers
{
    public class NotificationEventHandler : INotificationHandler<NotifyDonatorUserEvent>
    {
        public Task Handle(NotifyDonatorUserEvent notification, CancellationToken cancellationToken)
        {
            var index = 0;

            foreach (var donatorUserNotification in notification.DonatorUserNotificationsEvent)
            {
                if (donatorUserNotification.NotificationType.Equals(NotificationsTypeConfiguration.TYPE_BLOOD))
                    NotifyBloodDonatorUser(donatorUserNotification, notification, index);

                if (donatorUserNotification.NotificationType.Equals(NotificationsTypeConfiguration.TYPE_HAIR))
                    NotifyHairDonatorUser(donatorUserNotification, notification, index);
            }

            return Task.CompletedTask;
        }

        private void NotifyHairDonatorUser(DonatorUserNotificationEvent donatorUserNotification, NotifyDonatorUserEvent notification, int index)
        {
            if (index == 0)
                new WhatsappService().SendWhatsappDonator(notification.Hospital, donatorUserNotification.Name, "cabelo", "");

            new EmailService().SendEmail("socialheroes_comunicacao@outlook.com",
                                          donatorUserNotification.Email,
                                          $"Solicitação de cabelo",
                                          EmailTemplate.EmailDonatorNotification("cabelo", notification.Hospital));
        }

        private void NotifyBloodDonatorUser(DonatorUserNotificationEvent donatorUserNotification, NotifyDonatorUserEvent notification, int index)
        {
            if (index == 0)
                new WhatsappService().SendWhatsappDonator(notification.Hospital, donatorUserNotification.Name, "sangue", "");

            new EmailService().SendEmail("socialheroes_comunicacao@outlook.com", 
                                          donatorUserNotification.Email, 
                                          $"Solicitação de sangue", 
                                          EmailTemplate.EmailDonatorNotification("sangue", notification.Hospital));
        }


    }
}
