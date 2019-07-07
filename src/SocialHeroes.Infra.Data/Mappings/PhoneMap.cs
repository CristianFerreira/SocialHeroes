using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.InstitutionUserId)
                .IsRequired();

            builder.HasOne(a => a.InstitutionUser).WithMany(a => a.Phones);
            builder.ToTable("Phones");
        }
    }
}
