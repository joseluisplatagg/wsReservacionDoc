using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.DTOs.Responses
{
    public class CitaResponseDTO
    {
        public PacienteResponseDTO Paciente { get; set; } = null!;
        public string DoctorAsignado { get; set; } = string.Empty;
        public DateOnly DiaCita { get; set; }
        public TimeOnly HoraCita { get; set;  }
    }
}
