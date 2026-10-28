using SharedKernel.API.Middlewares;
using SharedKernel.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Infrastructure.Services.Permission
{
    public class IamPermissionService(
    ICurrentUserProvider currentUserProvider)
    : IPermissionService
    {
        private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;
        private const string CheckPermissionEndpoint = "/api/v1/user-context/check-permission";

        public async Task<bool> CheckPermissionAsync(string actionName)
        {
            var token = _currentUserProvider.GetToken();



            return true;
        }
    }
}
