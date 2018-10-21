

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HairMap());

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
