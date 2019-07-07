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

            builder.Property(x => x.InstitutionUserId)
                .IsRequired();

            builder.Property(a => a.DateNotification)
                .IsRequired();

            builder.HasMany(a => a.InstitutionUsers).WithOne(a => a.Notification);

            builder.ToTable("Notifications");
        }
    }
}
