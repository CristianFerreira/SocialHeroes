using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class InstitutionUserMap : IEntityTypeConfiguration<InstitutionUser>
    {
        public void Configure(EntityTypeBuilder<InstitutionUser> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.CNPJ)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(h => h.FantasyName)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(h => h.SocialReason)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();


            builder.HasOne(h => h.User).WithOne(h => h.InstitutionUser);
    
            builder.ToTable("InstitutionUsers");
        }
    }
}
