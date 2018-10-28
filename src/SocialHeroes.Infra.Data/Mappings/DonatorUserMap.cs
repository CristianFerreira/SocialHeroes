using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class DonatorUserMap : IEntityTypeConfiguration<DonatorUser>
    {
        public void Configure(EntityTypeBuilder<DonatorUser> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.CPF)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);

            builder.Property(d => d.CellPhone)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14);

            builder.Property(d => d.DateBirth)
                .IsRequired();

            builder.Property(d => d.Genre)
                .IsRequired();

            builder.Property(d => d.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
               .IsRequired();

            builder.HasOne(d => d.User).WithMany(d => d.DonatorsUsers);
            builder.ToTable("DonatorUsers");
        }
    }
}
