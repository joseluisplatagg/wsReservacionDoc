using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Domain.ValueObjects
{
    public record SystemPhoneNumber
    {
        public string Value { get; init; }
        private SystemPhoneNumber(string value) => Value = value;

        public static SystemPhoneNumber Create(string value)
        {
            // Tu lógica de validación de teléfonos (ej: Regex)
            return new SystemPhoneNumber(value);
        }
    }
}
