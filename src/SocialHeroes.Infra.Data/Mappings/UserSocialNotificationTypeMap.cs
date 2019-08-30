using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class UserSocialNotificationTypeMap : IEntityTypeConfiguration<UserSocialNotificationType>
    {
        public void Configure(EntityTypeBuilder<UserSocialNotificationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SocialNotificationTypeId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(a => a.SocialNotificationType).WithMany(a => a.UserSocialNotificationTypes);
            builder.HasOne(a => a.User).WithMany(a => a.UserSocialNotificationTypes);
            builder.ToTable("UserSocialNotificationTypes");
        }
    }
}
