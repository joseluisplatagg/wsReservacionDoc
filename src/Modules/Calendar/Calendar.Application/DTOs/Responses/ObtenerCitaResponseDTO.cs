using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.DTOs.Responses
{
    public class ObtenerCitaResponseDTO
    {
        public string hora { get; set; } = string.Empty;
        public string medicoNombre { get; set; } = string.Empty;
        public string pacienteNombre { get; set; } = string.Empty;
    }
}
