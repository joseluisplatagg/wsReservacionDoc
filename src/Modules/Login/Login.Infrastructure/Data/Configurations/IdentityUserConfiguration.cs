using Login.Domain.AggregateRoots;
using Login.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Infrastructure.Data.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.ToTable("IdentityUsers", schema: "security");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email)
                .HasConversion(
                emailObjeto => emailObjeto.Value,               // Cómo se guarda en Postgres (un string)
                stringDb => Email.Create(stringDb)             // Cómo se reconstruye en C# al leer de la BD
                ).IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.PasswordHash)
            .HasConversion(
                hash => hash.Value,                        // Al guardar en Postgres, extrae el string plano
                stringDb => PasswordHash.FromHash(stringDb) // Al leer de Postgres, reconstruye tu Value Object
            )
            .IsRequired();
        }
    }
}
