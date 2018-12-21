using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class DonatorUserHairNotificationMap : IEntityTypeConfiguration<DonatorUserHairNotification>
    {
        public void Configure(EntityTypeBuilder<DonatorUserHairNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Appear)
                .IsRequired();

            builder.Property(a => a.HairNotificationId)
                .IsRequired();

            builder.Property(a => a.DonatorUserId)
                .IsRequired();


            builder.HasOne(a => a.HairNotification).WithMany(a => a.DonatorUserHairNotifications);
            builder.HasOne(a => a.DonatorUser).WithMany(a => a.DonatorUserHairNotifications);
            builder.ToTable("DonatorUserHairNotifications");
        }
    }
}
