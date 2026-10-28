using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Application.Exceptions
{
    public class UseCaseException(string message, string errorCode) : Exception(message)
    {
        public string Message { get; } = message;
        public string ErrorCode { get; } = errorCode;
    }
}
