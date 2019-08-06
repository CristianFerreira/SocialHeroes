using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Events.NotificationEvent;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SocialHeroes.Domain.EventHandlers
{
    public class NotificationEventHandler : INotificationHandler<NotifyDonatorUserEvent>
    {
        public Task Handle(NotifyDonatorUserEvent notification, CancellationToken cancellationToken)
        {
            foreach (var donatorUserNotification in notification.DonatorUserNotificationsEvent)
            {
                if (donatorUserNotification.NotificationType.Equals(NotificationsTypeConfiguration.TYPE_BLOOD))
                    NotifyBloodDonatorUser(donatorUserNotification, notification);

                if (donatorUserNotification.NotificationType.Equals(NotificationsTypeConfiguration.TYPE_HAIR))
                    NotifyHairDonatorUser(donatorUserNotification, notification);
            }

            return Task.CompletedTask;
        }

        private void NotifyHairDonatorUser(DonatorUserNotificationEvent donatorUserNotification, NotifyDonatorUserEvent notification)
        {
            try
            {
                const string accountSid = "AC36cd014add4fc202353fd1d272026aa4";
                const string authToken = "161cdde2b4d1f29888e3841eab5637f5";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(body: $@"Ola {donatorUserNotification.Name}, 
                                                            você recebeu uma solicitação de cabelo da instituição {notification.Hospital}. 
                                                            Para saber maiores informações: {new Uri("http://www.google.com.br")}",
                                                     from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                                     to: new Twilio.Types.PhoneNumber("whatsapp:+555198585486"));
            }
            catch (Exception ex) { throw ex; };
        }

        private void NotifyBloodDonatorUser(DonatorUserNotificationEvent donatorUserNotification, NotifyDonatorUserEvent notification)
        {
            try
            {
                const string accountSid = "AC36cd014add4fc202353fd1d272026aa4";
                const string authToken = "161cdde2b4d1f29888e3841eab5637f5";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(body: $@"Ola {donatorUserNotification.Name}, 
                                                            você recebeu uma solicitação de sangue da instituição {notification.Hospital}. 
                                                            Para saber maiores informações: {new Uri("http://www.google.com.br")}",
                                                     from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                                     to: new Twilio.Types.PhoneNumber("whatsapp:+555198585486")); 
            }
            catch (Exception ex) { throw ex; };
        }
    }
}
