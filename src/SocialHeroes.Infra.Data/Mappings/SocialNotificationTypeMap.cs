using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class SocialNotificationTypeMap : IEntityTypeConfiguration<SocialNotificationType>
    {
        public void Configure(EntityTypeBuilder<SocialNotificationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("SocialNotificationTypes");
        }
    }
}
