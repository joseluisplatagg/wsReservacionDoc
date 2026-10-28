using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; init; }
        private Email(string value) => Value = value;

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Formato de correo electrónico inválido.");
            return new Email(value.ToLowerInvariant().Trim());
        }
    }
}
