using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class HospitalUserMap : IEntityTypeConfiguration<HospitalUser>
    {
        public void Configure(EntityTypeBuilder<HospitalUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.CNPJ)
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.HospitalsUsers);

            builder.ToTable("HospitalUsers");
        }
    }
}
