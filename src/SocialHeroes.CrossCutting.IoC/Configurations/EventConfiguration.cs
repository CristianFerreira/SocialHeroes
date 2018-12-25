using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.EventHandlers;
using SocialHeroes.Domain.Events.AccountEvent;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class EventConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<HospitalAccountRegisteredEvent>, AccountEventHandler>();

        }
    }
}
