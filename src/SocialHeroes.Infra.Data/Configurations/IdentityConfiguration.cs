using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Models;
using System;

namespace SocialHeroes.Infra.Data
{
    public class IdentityConfiguration
    {
        public static void ConfigurationIdentityTables(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");

            builder.Entity<Role>().ToTable("Roles");

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
        }
    }
}
