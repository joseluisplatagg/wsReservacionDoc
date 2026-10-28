using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.ValueObjects
{
    public record PasswordHash
    {
        public string Value { get; init; }
        private PasswordHash(string value) => Value = value;

        public static PasswordHash FromHash(string hash) => new(hash);
    }
}
