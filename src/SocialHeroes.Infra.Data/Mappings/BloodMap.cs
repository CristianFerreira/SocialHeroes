using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class BloodMap : IEntityTypeConfiguration<Blood>
    {
        public void Configure(EntityTypeBuilder<Blood> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.Type)
                .HasColumnType("Varchar(3)")
                .IsRequired();

            builder.ToTable("Bloods")
                .HasIndex(c => new { c.Type })
                .IsUnique();
        }
    }
}
