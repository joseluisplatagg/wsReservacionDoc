using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calendar.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "calendar");

            migrationBuilder.CreateTable(
                name: "cita_aggregate_root",
                schema: "calendar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre_paciente = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    telefono_paciente = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    edad_paciente = table.Column<int>(type: "integer", nullable: false),
                    motivo_cita = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    doctor = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    dia_cita = table.Column<DateOnly>(type: "date", nullable: false),
                    hora_cita = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita_aggregate_root", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cita_aggregate_root",
                schema: "calendar");
        }
    }
}
