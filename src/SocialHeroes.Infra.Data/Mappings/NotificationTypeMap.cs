using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class NotificationTypeMap : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("NotificationTypes");
        }
    }
}
