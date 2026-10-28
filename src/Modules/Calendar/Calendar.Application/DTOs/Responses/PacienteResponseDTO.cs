using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.DTOs.Responses
{
    public class PacienteResponseDTO
    {
        public string NombreCompletoPaciente { get; set;  } = string.Empty;
        public string TelefonoPaciente { get; set;  } = string.Empty;
        public short EdadPaciente { get; set; }
    }
}
