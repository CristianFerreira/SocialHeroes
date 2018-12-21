using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class UserNotificationTypeMap : IEntityTypeConfiguration<UserNotificationType>
    {
        public void Configure(EntityTypeBuilder<UserNotificationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TypeId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(a => a.NotificationType).WithMany(a => a.UserNotificationTypes);
            builder.HasOne(a => a.User).WithMany(a => a.UserNotificationTypes);
            builder.ToTable("UserNotificationTypes");

        }
    }
}
