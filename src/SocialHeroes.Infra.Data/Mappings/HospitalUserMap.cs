using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class HospitalUserMap : IEntityTypeConfiguration<HospitalUser>
    {
        public void Configure(EntityTypeBuilder<HospitalUser> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.CNPJ)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(h => h.Actived)
                .IsRequired();

            builder.Property(h => h.FantasyName)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(h => h.SocialReason)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();


            builder.HasOne(h => h.User).WithOne(h => h.HospitalUser);
            builder.ToTable("HospitalUsers");
        }
    }
}
