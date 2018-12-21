using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class HairNotificationMap : IEntityTypeConfiguration<HairNotification>
    {
        public void Configure(EntityTypeBuilder<HairNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Actived)
                .IsRequired();

            builder.Property(a => a.AmountHair)
                .IsRequired();

            builder.Property(a => a.HairId)
                .IsRequired();

            builder.Property(a => a.NotificationId)
                .IsRequired();

            builder.HasOne(a => a.Notification).WithMany(a => a.HairNotifications);
            builder.HasOne(a => a.Hair).WithMany(a => a.HairNotifications);
            builder.ToTable("HairNotifications");

        }
    }
}
