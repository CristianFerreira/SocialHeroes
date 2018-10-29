using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Configurations;
using SocialHeroes.Infra.Data.Context;
using System;

namespace SocialHeroes.WebApi.Configurations
{
    public class IdentityConfigurationService
    {
        public static void RegisterIdentityService(IServiceCollection services)
        {

            #region Identity Context
            services.AddDbContext<SocialHeroesContext>(options =>
                    options.UseSqlServer(ConnectionStringConfiguration.ConnectionString()));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SocialHeroesContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region Identity Settings
            services
                   .Configure<IdentityOptions>(options =>
                   {
                       //Lockout
                       options.Lockout.AllowedForNewUsers = true;
                       options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                       options.Lockout.MaxFailedAccessAttempts = 5;

                       //Password
                       options.Password.RequireDigit = true;
                       options.Password.RequiredLength = 6;
                       options.Password.RequiredUniqueChars = 1;
                       options.Password.RequireLowercase = false;
                       options.Password.RequireUppercase = false;
                       options.Password.RequireNonAlphanumeric = false;

                       //SignIn
                       options.SignIn.RequireConfirmedEmail = false;
                       options.SignIn.RequireConfirmedPhoneNumber = false;

                       //Token
                       //options.Tokens.AuthenticatorTokenProvider
                       //options.Tokens.ChangeEmailTokenProvider
                       //options.Tokens.ChangePhoneNumberTokenProvider
                       //options.Tokens.EmailConfirmationTokenProvider
                       //options.Tokens.PasswordResetTokenProvider

                       //User
                       options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                       options.User.RequireUniqueEmail = false;
                   });
                  
            #endregion

        }
    }
}
