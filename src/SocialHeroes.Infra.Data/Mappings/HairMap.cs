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
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
