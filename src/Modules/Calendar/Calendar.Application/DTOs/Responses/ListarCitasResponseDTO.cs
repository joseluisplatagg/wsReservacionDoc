using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.DTOs.Responses
{
    public class ListarCitasResponseDTO
    {
        public List<CitaResponseDTO> Citas { get; set; } = new List<CitaResponseDTO>();
        public Dictionary<DateOnly, TimeOnly[]> Reservaciones { get; set; } = new();
    }
}