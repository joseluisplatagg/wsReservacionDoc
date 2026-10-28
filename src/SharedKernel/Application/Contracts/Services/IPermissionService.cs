using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Application.Contracts.Services
{
    public interface IPermissionService
    {
        Task<bool> CheckPermissionAsync(string actionName);
    }
}
