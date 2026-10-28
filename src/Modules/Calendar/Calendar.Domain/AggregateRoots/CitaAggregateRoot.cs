using Calendar.Domain.Common;
using Calendar.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Domain.AggregateRoots
{
    public class CitaAggregateRoot : BaseDomainModel
    {
        public Paciente Paciente { get; set; } = null!;
        public string   MotivoCita { get; set; } = string.Empty;
        public string   DoctorSeleccionadoCita {  get; set; } = string.Empty;
        public DateOnly DiaCita { get; set; }
        public TimeOnly HoraCita { get; set;  }

    }
}
