using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.CrossCutting.IoC.Configurations;

namespace SocialHeroes.CrossCutting.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            
            ContextConfiguration.Register(services);
            BusConfiguration.Register(services);
            EventConfiguration.Register(services);
            ValidationConfiguration.Register(services);
            HandlerConfiguration.Register(services);
            ServiceConfiguration.Register(services);
            RepositoryConfiguration.Register(services);

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
