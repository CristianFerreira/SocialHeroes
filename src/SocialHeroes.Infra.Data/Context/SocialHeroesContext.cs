using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Configurations;
using System;

namespace SocialHeroes.Infra.Data.Context
{
    public class SocialHeroesContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Hair> Hairs { get; set; }
        public DbSet<DonatorUser> DonatorUsers { get; set; }
        public DbSet<InstitutionUser> InstitutionUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<BloodNotification> BloodNotifications { get; set; }
        public DbSet<BreastMilkNotification> BreastMilkNotifications { get; set; }
        public DbSet<DonatorUserBloodNotification> DonatorUserBloodNotifications { get; set; }
        public DbSet<DonatorUserBreastMilkNotification> DonatorUserBreastMilkNotifications { get; set; }
        public DbSet<DonatorUserHairNotification> DonatorUserHairNotifications { get; set; }
        public DbSet<HairNotification> HairNotifications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<UserNotificationType> UserNotificationTypes { get; set; }

        public DbSet<UserSocialNotificationType> UserSocialNotificationTypes { get; set; }

        public DbSet<SocialNotificationType> SocialNotificationTypes { get; set; }

        public SocialHeroesContext(DbContextOptions<SocialHeroesContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);

            ConventionsRemoveConfiguration.ConventionsRemove(modelBuilder.Model.GetEntityTypes());
            IdentityConfiguration.ConfigurationIdentityTables(modelBuilder);
            MappingConfiguration.RegisterMappings(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionStringConfiguration.ConnectionString());
        
    }
}
