using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Application.Exceptions
{
    public class ConflictException(string errorCode, string detail) : Exception(detail)
    {
        public string ErrorCode { get; } = errorCode;
    }
}
