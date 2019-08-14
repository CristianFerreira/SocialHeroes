using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.EventHandlers;
using SocialHeroes.Domain.Events.AccountEvent;
using SocialHeroes.Domain.Events.NotificationEvent;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class EventConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<InstitutionUserAccountRegisteredEvent>, AccountEventHandler>();
            services.AddScoped<INotificationHandler<NotifyDonatorUserEvent>, NotificationEventHandler>();
        }
    }
}
