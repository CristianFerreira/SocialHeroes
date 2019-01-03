using Microsoft.Extensions.DependencyInjection;
using SocialHeroes.Domain.Interfaces;
using SocialHeroes.Infra.Data.Repository;

namespace SocialHeroes.CrossCutting.IoC.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IHairRepository, HairRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserNotificationTypeRepository, UserNotificationTypeRepository>();
            services.AddScoped<IDonatorUserRepository, DonatorUserRepository>();
            services.AddScoped<IHospitalUserRepository, HospitalUserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IBloodNotificationRepository, BloodNotificationRepository>();
            services.AddScoped<IHairNotificationRepository, HairNotificationRepository>();
            services.AddScoped<IBreastMilkNotificationRepository, BreastMilkNotificationRepository>();
            services.AddScoped<IDonatorUserBloodNotificationRepository, DonatorUserBloodNotificationRepository>();
            services.AddScoped<IDonatorUserHairNotificationRepository, DonatorUserHairNotificationRepository>();
            services.AddScoped<IDonatorUserBreastMilkNotificationRepository, DonatorUserBreastMilkNotificationRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
        }
    }
}
