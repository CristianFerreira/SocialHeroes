using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;

namespace SocialHeroes.Infra.Data.Mappings
{
    public class UserMap: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.UserName)
                .HasMaxLength(256);

            builder.Property(u => u.UserType)
                .IsRequired();

            builder.Property(u => u.UserStatus)
                .IsRequired();

            builder.HasOne(u => u.Address).WithOne(u => u.User);
            builder.HasOne(u => u.HospitalUser).WithOne(u => u.User);
            builder.HasOne(u => u.DonatorUser).WithOne(u => u.User);

            builder.ToTable("Users");
        }
    }
}
