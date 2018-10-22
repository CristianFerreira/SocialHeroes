﻿

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.CrossCutting.Bus;
using SocialHeroes.Domain.Commands.HairCommand;
using SocialHeroes.Domain.CommandsHandler;
using SocialHeroes.Domain.Core.Bus;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Events;
using SocialHeroes.Domain.Core.Notifications;
using SocialHeroes.Domain.Events;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Domain.Interfaces.MirrorRepository;
using SocialHeroes.Domain.MirroringHandler;
using SocialHeroes.Domain.Models;
using SocialHeroes.Domain.Validations;
using SocialHeroes.Infra.Data.Context;
using SocialHeroes.Infra.Data.EventDataBase;
using SocialHeroes.Infra.Data.MirrorRepository;
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
            services.AddScoped<IEventDataBase, EventDataBase>();

            //services.AddScoped<IRequestHandler<HairRegisteredEvent>, HairMirroringHandler>();

            // Domain - Commands
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidator<,>));
            services.AddScoped<IRequestHandler<RegisterNewHairCommand, CommandResult>, HairCommandHandler>();


            // Infra - Data
            services.AddScoped<IHairRepository, HairRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SocialHeroesContext>();

            services.AddScoped<IEventDataBase, EventDataBase>();
            services.AddScoped<IMirrorRepository<Hair>, MirrorRepository<Hair>>();
            services.AddScoped<SocialHeroesMirrorContext>();
            
           

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}