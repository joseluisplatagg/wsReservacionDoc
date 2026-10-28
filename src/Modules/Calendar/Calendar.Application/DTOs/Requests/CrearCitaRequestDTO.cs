using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.DTOs.Requests
{
    public record CrearCitaRequestDTO
    {
        public PacienteRequestDTO Paciente { get; set; } = null!;
        public string MotivoCita { get; set; } = string.Empty;
        public string DoctorSeleccionado {  get; set; } = string.Empty; 
        public DateOnly FechaCita { get; set;  } = new DateOnly();
        public TimeOnly HoraCita { get; set; } = new TimeOnly();
    }

    public record PacienteRequestDTO
    {
        public string PacienteNombre { get; set; } = string.Empty;
        public string PacienteTelefono { get; set; } = string.Empty;
        public short PacienteEdad { get; set; }
    }
}
