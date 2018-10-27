using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class DonatorUserMap : IEntityTypeConfiguration<DonatorUser>
    {
        public void Configure(EntityTypeBuilder<DonatorUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.CPF)
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.DonatorsUsers);

            builder.ToTable("DonatorUsers");
        }
    }
}
