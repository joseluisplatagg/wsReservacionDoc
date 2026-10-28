using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Middlewares
{
    public interface ICurrentUserProvider
    {
        Guid UserId { get; }
        string Name { get; }
        string Email { get; }
        string Department { get; }
        string OfficeLocation { get; }
        string? GetToken();
    }
}
