using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Services;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class ServiceConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
