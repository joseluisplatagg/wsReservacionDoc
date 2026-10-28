using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Domain.ValueObjects
{
    public record Paciente
    {
        public string NombreCompletoPaciente { get; init; } = string.Empty;
        public string TelefonoPaciente { get; init; } = string.Empty;
        public int EdadPaciente { get; init; }
        private Paciente() { }

        public Paciente(string nombreCompleto,string telefonoPaciente, int edadPaciente)
        {
            if (string.IsNullOrEmpty(nombreCompleto)) throw new DomainException("El nombre del paciente debe ingresarse");
            if (nombreCompleto.Any(char.IsAsciiDigit)) throw new DomainException("El nombre del paciente no puede contener numeros");
            if (edadPaciente < 0) throw new DomainException("Ingresa una edad válida");
            
            NombreCompletoPaciente = nombreCompleto;
            TelefonoPaciente = telefonoPaciente;
            EdadPaciente = edadPaciente;
        }
    }
}
