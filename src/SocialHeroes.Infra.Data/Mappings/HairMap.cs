using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class HairMap : IEntityTypeConfiguration<Hair>
    {
        public void Configure(EntityTypeBuilder<Hair> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.Color)
                .HasColumnType("Varchar(50)")
                .IsRequired();

            builder.Property(c => c.Type)
                .HasColumnType("Varchar(25)")
                .IsRequired();

            builder.ToTable("Hairs")
                .HasIndex(c => new { c.Color, c.Type })
                .IsUnique();
        }
    }
}
