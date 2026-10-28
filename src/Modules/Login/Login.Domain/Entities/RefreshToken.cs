using Login.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.Entities
{
    public class RefreshToken : BaseDomainModel
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiryTime { get; private set; }
        public bool IsRevoked { get; private set; }

        public RefreshToken(Guid id, string token, DateTime expiryTime)
        {
            Id = id;
            Token = token;
            ExpiryTime = expiryTime;
            IsRevoked = false;
        }

        public void Revoke() => IsRevoked = true;
        public bool IsExpired(DateTime now) => now >= ExpiryTime;
    }
}
