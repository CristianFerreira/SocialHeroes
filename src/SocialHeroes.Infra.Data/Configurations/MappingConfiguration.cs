using Microsoft.EntityFrameworkCore;
using SocialHeroes.Infra.Data.Mappings;

namespace SocialHeroes.Infra.Data.Configurations
{
    public static class MappingConfiguration
    {
        public static void RegisterMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HairMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DonatorUserMap());
            modelBuilder.ApplyConfiguration(new HospitalUserMap());
        }
    }
}
