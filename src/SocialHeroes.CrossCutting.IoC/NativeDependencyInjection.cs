﻿

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Infra.CrossCutting.Bus;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.CommandsHandler;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Validations;
using SocialHeroes.Infra.Data.Context;
using SocialHeroes.Infra.Data.Repository;
using SocialHeroes.Infra.Data.UoW;
using SocialHeroes.Domain.Core.Configurations;

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

            // Domain - Commands
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));
            services.AddScoped<IRequestHandler<RegisterNewHairCommand, CommandResult>, HairCommandHandler>();


            // Infra - Data
            services.AddScoped<IHairRepository, HairRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDonatorUserRepository, DonatorUserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SocialHeroesContext>();

            //TokenConfiguration
            services.AddSingleton(new SigningConfiguration());

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
