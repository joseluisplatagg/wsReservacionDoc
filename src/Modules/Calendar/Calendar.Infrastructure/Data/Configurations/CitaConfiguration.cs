using Calendar.Domain.AggregateRoots;
using Calendar.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Infrastructure.Data.Configurations
{
    public class CitaConfiguration :BaseConfiguration<CitaAggregateRoot>
    {
        public override void Configure(EntityTypeBuilder<CitaAggregateRoot> builder)
        {
            base.Configure(builder);
            builder.ToSnakeCaseTable(schema: "calendar");

            builder.OwnsOne(x => x.Paciente, pacienteBuilder =>
            {
                pacienteBuilder.Property(p => p.NombreCompletoPaciente)
                    .HasColumnName("nombre_paciente")
                    .HasMaxLength(75);

                pacienteBuilder.Property(p => p.TelefonoPaciente)
                    .HasColumnName("telefono_paciente")
                    .HasMaxLength(75);

                pacienteBuilder.Property(p => p.EdadPaciente)
                    .HasColumnName("edad_paciente")
                    .IsRequired();
            });

            builder.Property(x => x.MotivoCita)
                .HasColumnName("motivo_cita")
                .HasMaxLength(150);

            builder.Property(x => x.DoctorSeleccionadoCita)
                .HasColumnName("doctor")
                .HasMaxLength(75);

            builder.Property(x => x.DiaCita)
                .HasColumnName("dia_cita")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.HoraCita)
                .HasColumnName("hora_cita")
                .HasColumnType("time")
                .IsRequired();
        }
    }
}
