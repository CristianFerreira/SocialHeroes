using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHeroes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
