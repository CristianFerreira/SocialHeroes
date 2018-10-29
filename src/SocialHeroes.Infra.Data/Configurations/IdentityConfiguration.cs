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
