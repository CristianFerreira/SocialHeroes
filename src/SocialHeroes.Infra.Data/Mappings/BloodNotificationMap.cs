using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class BloodNotificationMap : IEntityTypeConfiguration<BloodNotification>
    {
        public void Configure(EntityTypeBuilder<BloodNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Actived)
                .IsRequired();

            builder.Property(a => a.AmountBlood)
                .IsRequired();

            builder.Property(a => a.BloodId)
                .IsRequired();

            builder.Property(a => a.NotificationId)
                .IsRequired();

            builder.HasOne(a => a.Notification).WithMany(a => a.BloodNotifications);
            builder.HasOne(a => a.Blood).WithMany(a => a.BloodNotifications);
            builder.ToTable("BloodNotifications");

        }
    }
}
