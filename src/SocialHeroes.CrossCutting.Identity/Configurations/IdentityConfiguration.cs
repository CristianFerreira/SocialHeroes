using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Infra.CrossCutting.Identity.Data;
using SocialHeroes.Infra.CrossCutting.Identity.Models;
using System;
using System.IO;

namespace SocialHeroes.CrossCutting.Identity.Configurations
{
    public class IdentityConfiguration
    {
        public static IConfiguration Configuration { get; set; }

        public static void RegisterIdentity(IServiceCollection services)
        {


            #region Identity Context
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(GetConfiguration().GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            #endregion


            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
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
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        }

        private static IConfigurationRoot GetConfiguration()
            => new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

    }
}
