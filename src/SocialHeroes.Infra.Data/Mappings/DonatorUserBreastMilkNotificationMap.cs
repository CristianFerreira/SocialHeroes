using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class DonatorUserBreastMilkNotificationMap : IEntityTypeConfiguration<DonatorUserBreastMilkNotification>
    {
        public void Configure(EntityTypeBuilder<DonatorUserBreastMilkNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Appear)
                .IsRequired();

            builder.Property(a => a.BreastMilkNotificationId)
                .IsRequired();

            builder.Property(a => a.DonatorUserId)
                .IsRequired();

            builder.HasOne(a => a.BreastMilkNotification).WithMany(a => a.DonatorUserBreastMilkNotifications);
            builder.HasOne(a => a.DonatorUser).WithMany(a => a.DonatorUserBreastMilkNotifications);
            builder.ToTable("DonatorUserBreastMilkNotifications");

        }
    }
}
