using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.AggregateRoots;

namespace Users.Infrastructure.Data.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles", schema: "users");
            builder.HasKey(x => x.Id);

            // MAPEO DE VALUE OBJECTS USANDO COMPLEX TYPES (.NET 10)
            builder.ComplexProperty(x => x.Name, nameBuilder => {
                nameBuilder.Property(n => n.FirstName).HasColumnName("first_name").HasMaxLength(100);
                nameBuilder.Property(n => n.LastName).HasColumnName("last_name").HasMaxLength(100);
            });

            builder.ComplexProperty(x => x.Phone, phoneBuilder => {
                phoneBuilder.Property(p => p.Value).HasColumnName("phone_number").HasMaxLength(20);
            });
        }
    }
}
