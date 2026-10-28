using SharedKernel.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Infrastructure.Services.Permission
{
    public class AuthorizationHeaderHandler(ICurrentUserProvider currentUserProvider) : DelegatingHandler
    {
        private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _currentUserProvider.GetToken();

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
