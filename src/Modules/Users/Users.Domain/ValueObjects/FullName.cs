using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Domain.ValueObjects
{
    public record FullName(string FirstName, string LastName)
    {
        public static FullName Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("El nombre y apellido son obligatorios.");
            return new FullName(firstName.Trim(), lastName.Trim());
        }
    }
}
