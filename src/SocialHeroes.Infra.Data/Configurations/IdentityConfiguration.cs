using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Configurations;
using SocialHeroes.Infra.Data.Context;
using System;

namespace SocialHeroes.Infra.Data
{
    public class IdentityConfiguration
    {
        public static IConfiguration Configuration { get; set; }

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
                   .AddIdentity<User, Role>(options =>
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
                   .AddEntityFrameworkStores<SocialHeroesContext>()
                   .AddDefaultTokenProviders(); 
            #endregion

        }

        public static void ConfigurationIdentityTables(ModelBuilder builder)
        {
            builder.Entity<User>(entity => entity.ToTable("Users"));

            builder.Entity<Role>(entity => entity.ToTable("Roles"));

            builder.Entity<IdentityUserClaim<Guid>>(entity => entity.ToTable("UserClaims"));

            builder.Entity<IdentityUserRole<Guid>>(entity => entity.ToTable("UserRoles"));

            builder.Entity<IdentityUserLogin<Guid>>(entity => entity.ToTable("UserLogins"));

            builder.Entity<IdentityRoleClaim<Guid>>(entity => entity.ToTable("RoleClaims"));

            builder.Entity<IdentityUserToken<Guid>>(entity => entity.ToTable("UserTokens"));
        }
    }
}
