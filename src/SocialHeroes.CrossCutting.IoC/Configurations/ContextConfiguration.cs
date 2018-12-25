using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Infra.Data.Context;
using SocialHeroes.Infra.Data.UoW;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class ContextConfiguration
    {
        
        public static void Register(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SocialHeroesContext>();
        }
    }
}
