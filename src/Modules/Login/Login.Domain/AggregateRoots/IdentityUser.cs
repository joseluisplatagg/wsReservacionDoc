using Login.Domain.Common;
using Login.Domain.Entities;
using Login.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.AggregateRoots
{
    public class IdentityUser : BaseDomainModel
    {
        public Email Email { get; private set; } // Value Object
        public PasswordHash PasswordHash { get; private set; } // Value Object

        private readonly List<RefreshToken> _refreshTokens = new();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        // Las reglas de negocio se ejecutan mediante métodos de la raíz
        public void GenerateSessionToken(string tokenStr, DateTime expiry)
        {
            if (!IsActive) throw new InvalidOperationException("El usuario está inactivo.");

            // Controlamos la colección interna de forma segura
            _refreshTokens.Add(new RefreshToken(Guid.NewGuid(), tokenStr, expiry));
        }

        // El constructor es privado para forzar el uso de métodos de creación limpios
        private IdentityUser() { }
        public static IdentityUser Create(Guid id, Email email, PasswordHash hash)
        {
            return new IdentityUser
            {
                Id = id,
                Email = email,
                PasswordHash = hash,
                IsActive = true
            };
        }

    }
}