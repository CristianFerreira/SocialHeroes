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
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new BloodMap());
            modelBuilder.ApplyConfiguration(new BloodNotificationMap());
            modelBuilder.ApplyConfiguration(new BreastMilkNotificationMap());
            modelBuilder.ApplyConfiguration(new DonatorUserBloodNotificationMap());
            modelBuilder.ApplyConfiguration(new DonatorUserBreastMilkNotificationMap());
            modelBuilder.ApplyConfiguration(new DonatorUserHairNotificationMap());
            modelBuilder.ApplyConfiguration(new HairNotificationMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new UserNotificationTypeMap());
            modelBuilder.ApplyConfiguration(new NotificationTypeMap());
            
            modelBuilder.ApplyConfiguration(new PhoneMap());
            
        }
    }
}
