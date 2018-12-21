using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class DonatorUserBloodNotificationMap : IEntityTypeConfiguration<DonatorUserBloodNotification>
    {
        public void Configure(EntityTypeBuilder<DonatorUserBloodNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Appear)
                .IsRequired();

            builder.Property(a => a.BloodNotificationId)
                .IsRequired();

            builder.Property(a => a.DonatorUserId)
                .IsRequired();

            builder.HasOne(a => a.BloodNotification).WithMany(a => a.DonatorUserBloodNotifications).HasForeignKey(a => a.BloodNotificationId);
            builder.HasOne(a => a.DonatorUser).WithMany(a => a.DonatorUserBloodNotifications).HasForeignKey(a => a.DonatorUserId);
            builder.ToTable("DonatorUserBloodNotifications");

        }
    }
}
