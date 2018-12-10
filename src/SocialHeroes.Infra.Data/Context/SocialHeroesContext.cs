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
        public DbSet<HospitalUser> HospitalUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Blood> Bloods { get; set; }

        public SocialHeroesContext(DbContextOptions<SocialHeroesContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IdentityConfiguration.ConfigurationIdentityTables(modelBuilder);
            MappingConfiguration.RegisterMappings(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionStringConfiguration.ConnectionString());
        
    }
}
