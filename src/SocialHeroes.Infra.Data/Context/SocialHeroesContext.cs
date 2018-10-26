

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialHeroes.Domain.Models;
using SocialHeroes.Infra.Data.Mappings;
using System.IO;

namespace SocialHeroes.Infra.Data.Context
{
    public class SocialHeroesContext :DbContext
    {
        public DbSet<Hair> Hair { get; set; }
        public DbSet<DonatorUser> DonatorUser { get; set; }
        public DbSet<HospitalUser> HospitalUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HairMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DonatorUserMap());
            modelBuilder.ApplyConfiguration(new HospitalUserMap());       

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
