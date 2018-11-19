using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.City)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Complement)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(a => a.Country)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.District)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Number)
                .HasColumnType("varchar(20)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.ZipCode)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(a => a.State)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Latitude)
                .HasColumnType("decimal(18, 9)")
                .IsRequired();

            builder.Property(a => a.Longitude)
                .HasColumnType("decimal(18, 9)")
                .IsRequired();

            builder.HasOne(a => a.User).WithOne(a => a.Address);

            builder.ToTable("Adresses");

        }
    }
}
