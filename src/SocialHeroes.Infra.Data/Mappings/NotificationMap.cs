using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HospitalUserId)
                .IsRequired();

            builder.Property(a => a.DateNotification)
                .IsRequired();

            builder.HasOne(a => a.HospitalUser).WithOne(a => a.Notification);

            builder.ToTable("Notifications");
        }
    }
}
