using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Validations;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class ValidationConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));
        }
    }
}
