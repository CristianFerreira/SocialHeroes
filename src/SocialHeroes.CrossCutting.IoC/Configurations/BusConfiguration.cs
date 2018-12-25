using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Infra.CrossCutting.Bus;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class BusConfiguration
    {
        public static void Register(IServiceCollection services)
          =>  services.AddScoped<IMediatorHandler, InMemoryBus>();
        
    }
}
