using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class BreastMilkNotificationMap : IEntityTypeConfiguration<BreastMilkNotification>
    {
        public void Configure(EntityTypeBuilder<BreastMilkNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Actived)
                .IsRequired();

            builder.Property(a => a.AmountBreastMilk)
                .IsRequired();

            builder.Property(a => a.NotificationId)
                .IsRequired();

            builder.HasOne(a => a.Notification).WithMany(a => a.BreastMilkNotifications);
            builder.ToTable("BreastMilkNotifications");

        }
    }
}
