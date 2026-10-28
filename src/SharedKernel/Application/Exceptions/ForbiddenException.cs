using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Application.Exceptions
{
    public class ForbiddenException(string message, string permissions) : Exception(message)
    {
        public string Permission {  get; } = permissions;
    }
}
