using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Common;
using Users.Domain.ValueObjects;

namespace Users.Domain.AggregateRoots
{
    public class UserProfile : BaseDomainModel
    {
        public Guid Id { get; private set; } // Vinculado al Id de Security
        public FullName Name { get; private set; } // Value Object complejo
        public SystemPhoneNumber? Phone { get; private set; } // Value Object

        private UserProfile() { }

        public static UserProfile Create(Guid id, FullName name, SystemPhoneNumber? phone)
        {
            return new UserProfile
            {
                Id = id,
                Name = name,
                Phone = phone
            };
        }

        public void UpdateContactInformation(FullName newName, SystemPhoneNumber newPhone)
        {
            // Validación de negocio del perfil
            Name = newName;
            Phone = newPhone;
        }
    }
}
