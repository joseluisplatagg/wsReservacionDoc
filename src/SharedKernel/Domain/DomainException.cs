using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Domain
{
    public class DomainException(string messageKey, params object[]? args) : Exception(messageKey)
    {
        public object[]? Args { get; } = args;
        public string ErrorCode { get; } = messageKey;
    }
}
