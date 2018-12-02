

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Commands.AccountCommand;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.Configurations;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.EventHandlers;
using SocialHeroes.Domain.Events.AccountEvent;
using SocialHeroes.Domain.Handlers;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Services;
using SocialHeroes.Domain.Validations;
using SocialHeroes.Infra.CrossCutting.Bus;
using SocialHeroes.Infra.Data.Context;
using SocialHeroes.Infra.Data.Repository;
using SocialHeroes.Infra.Data.UoW;

namespace SocialHeroes.CrossCutting.IoC
{
    public class NativeDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<HospitalAccountRegisteredEvent>, AccountEventHandler>();

            // Domain - Commands
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));

            //HANDLER 

            //hair
            services.AddScoped<IRequestHandler<RegisterNewHairCommand, ICommandResult>, HairHandler>();
            //account
            services.AddScoped<IRequestHandler<TokenAccountCommand, ICommandResult>, AccountHandler>();
            services.AddScoped<IRequestHandler<RegisterNewDonatorAccountCommand, ICommandResult>, AccountHandler>();
            services.AddScoped<IRequestHandler<RegisterNewHospitalAccountCommand, ICommandResult>, AccountHandler>();

            //Token
            services.AddTransient<ITokenService, TokenService>();

            // Infra - Data
            services.AddScoped<IHairRepository, HairRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDonatorUserRepository, DonatorUserRepository>();
            services.AddScoped<IHospitalUserRepository, HospitalUserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SocialHeroesContext>();



            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
