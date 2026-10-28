using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Domain.ValueObjects
{
    public record TimeRange
    {
        public TimeOnly Start { get; init; }
        public TimeOnly End { get; init; }

        public TimeRange(TimeOnly start, TimeOnly end)
        {
            if (end <= start)
                throw new DomainException("La hora de finalización debe ser posterior a la de inicio.");

            Start = start;
            End = end;
        }

        public bool Overlaps(TimeRange other) => Start < other.End && other.Start < End;
    }
}
