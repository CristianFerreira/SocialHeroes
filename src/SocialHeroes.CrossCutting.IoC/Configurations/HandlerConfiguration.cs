using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Commands.Account.RequestCommand;
using SocialHeroes.Domain.Commands.Blood.RequestCommand;
using SocialHeroes.Domain.Commands.Hair.RequestCommand;
using SocialHeroes.Domain.Commands.Notification.RequestCommand;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Handlers;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class HandlerConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            //hair
            services.AddScoped<IRequestHandler<RegisterNewHairCommand, ICommandResult>, HairHandler>();

            //account
            services.AddScoped<IRequestHandler<TokenUserCommand, ICommandResult>, AccountHandler>();
            services.AddScoped<IRequestHandler<RegisterNewDonatorUserCommand, ICommandResult>, AccountHandler>();
            services.AddScoped<IRequestHandler<RegisterNewInstitutionUserCommand, ICommandResult>, AccountHandler>();
            services.AddScoped<IRequestHandler<ActiveUserCommand, ICommandResult>, AccountHandler>();

            //notification
            services.AddScoped<IRequestHandler<NotifyDonatorUserCommand, ICommandResult>, NotificationHandler>();

            //blood
            services.AddScoped<IRequestHandler<RegisterNewBloodCommand, ICommandResult>,BloodHandler>();

        }
    }
}
