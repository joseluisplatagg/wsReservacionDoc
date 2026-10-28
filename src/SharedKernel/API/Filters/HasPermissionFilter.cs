using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Contracts.Services;
using SharedKernel.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Filters
{
    public class HasPermissionFilter(string actionName) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var securityService = context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();

            var hasPermission = await securityService.CheckPermissionAsync(actionName);

            if (!hasPermission)
                throw new ForbiddenException(actionName,"");

            await next();
        }
    }
}
